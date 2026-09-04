import { bindOverlayCloseEvents, closeOverlay, openOverlay } from "../shared/overlay.js";
import { addCartItems } from "../cart/cart.js";
import type { ProductOverlayElements } from "./ProductOverlayElementsInterface.js";
import {formOverlayTimeout} from "../SystemSettings.js";

function getProductOverlayElements(): ProductOverlayElements | null {
    const productOverlay = document.querySelector<HTMLElement>("[data-product-overlay]");
    const productPopup = productOverlay?.querySelector<HTMLElement>(".product-popup");
    const productForm = productOverlay?.querySelector<HTMLFormElement>("[data-product-form]");
    const detailImage = productOverlay?.querySelector<HTMLImageElement>("[data-product-detail-image]");
    const detailName = productOverlay?.querySelector<HTMLElement>("[data-product-detail-name]");
    const detailPrice = productOverlay?.querySelector<HTMLElement>("[data-product-detail-price]");
    const detailSalePrice = productOverlay?.querySelector<HTMLElement>("[data-product-detail-sale-price]");
    const detailDiscount = productOverlay?.querySelector<HTMLElement>("[data-product-detail-discount]");
    const detailDescription = productOverlay?.querySelector<HTMLElement>("[data-product-detail-description]");
    const detailAddButton = productOverlay?.querySelector<HTMLButtonElement>("[data-product-detail-add]");

    if (!productOverlay || !productPopup || !productForm || !detailImage || !detailName ||
        !detailPrice || !detailSalePrice || !detailDiscount || !detailDescription || !detailAddButton) {
        return null;
    }

    return {
        productOverlay,
        productPopup,
        productCards: document.querySelectorAll<HTMLElement>("[data-product-card]"),
        productCloseButton: productOverlay.querySelector<HTMLButtonElement>("[data-product-close]"),
        productForm,
        detailImage,
        detailName,
        detailPrice,
        detailSalePrice,
        detailDiscount,
        detailDescription,
        detailAddButton,
        detailBuyButton: productOverlay.querySelector<HTMLButtonElement>("[data-product-detail-buy]")
    };
}

function updateProductDetails(elements: ProductOverlayElements, card: HTMLElement): void {
    const { detailImage, detailName, detailPrice, detailSalePrice, detailDiscount, detailDescription } = elements;

    detailImage.src = card.dataset.productImage ?? "";
    detailImage.alt = card.dataset.productName ?? "";
    detailName.textContent = card.dataset.productName ?? "";
    detailPrice.textContent = card.dataset.productPrice ?? "";
    detailSalePrice.textContent = card.dataset.productSalePrice ?? "";
    detailDiscount.textContent = card.dataset.productDiscount ?? "";
    detailDescription.textContent = card.dataset.productDescription ?? "";
}

function resetProductForm(elements: ProductOverlayElements): void {
    elements.productForm.reset();
    elements.detailAddButton.textContent = "Add to cart";
}


function openProductPopup(
    elements: ProductOverlayElements,
    card: HTMLElement,
    closeTimer: number | undefined
): number | undefined {
    if (closeTimer) {
        window.clearTimeout(closeTimer);
    }

    updateProductDetails(elements, card);
    resetProductForm(elements);
    openOverlay(elements.productOverlay);
    return undefined;
}

function closeProductPopup(elements: ProductOverlayElements, closeTimer: number | undefined): number {
    return closeOverlay(elements.productOverlay, closeTimer);
}

function handleProductCardClick(
    event: MouseEvent,
    card: HTMLElement,
    openPopup: (card: HTMLElement) => void
): void {
    if (!(event.target as Element).closest("button")) {
        openPopup(card);
    }
}

function handleAddToCart(event: MouseEvent): void {
    event.stopPropagation();
    addCartItems();
    (event.currentTarget as HTMLButtonElement).textContent = "Added";
}

function handleBuyNow(
    event: MouseEvent,
    card: HTMLElement,
    openPopup: (card: HTMLElement) => void
): void {
    event.stopPropagation();
    openPopup(card);
}

function bindProductCards(
    elements: ProductOverlayElements,
    openPopup: (card: HTMLElement) => void
): void {
    elements.productCards.forEach((card) => {
        card.addEventListener("click", (event: MouseEvent) => {
            handleProductCardClick(event, card, openPopup);
        });

        card.querySelector<HTMLButtonElement>("[data-product-add]")?.addEventListener("click", handleAddToCart);
        card.querySelector<HTMLButtonElement>("[data-product-buy]")?.addEventListener("click", (event: MouseEvent) => {
            handleBuyNow(event, card, openPopup);
        });
    });
}

function bindProductForm(elements: ProductOverlayElements, closePopup: () => void): void {
    elements.productForm.addEventListener("submit", (event: SubmitEvent) => {
        event.preventDefault();
        const quantityInput = elements.productForm.elements.namedItem("quantity") as HTMLInputElement | null;
        const quantity = Number(quantityInput?.value ?? 1);
        addCartItems(Number.isFinite(quantity) && quantity > 0 ? quantity : 1);
        elements.detailAddButton.textContent = "Added to cart";
        window.setTimeout(closePopup, formOverlayTimeout);
    });

    elements.detailBuyButton?.addEventListener("click", closePopup);
}

function bindEscapeKey(elements: ProductOverlayElements, closePopup: () => void): void {
    document.addEventListener("keydown", (event: KeyboardEvent) => {
        if (event.key === "Escape" && !elements.productOverlay.hidden) {
            closePopup();
        }
    });
}

export function initializeProductOverlay(): void {
    const elements = getProductOverlayElements();

    if (!elements) {
        return;
    }

    let closeTimer: number | undefined;
    const openPopup = (card: HTMLElement): void => {
        closeTimer = openProductPopup(elements, card, closeTimer);
    };
    const closePopup = (): void => {
        closeTimer = closeProductPopup(elements, closeTimer);
    };

    bindProductCards(elements, openPopup);
    bindOverlayCloseEvents(elements.productOverlay, elements.productPopup, elements.productCloseButton, closePopup);
    bindProductForm(elements, closePopup);
    bindEscapeKey(elements, closePopup);
}
