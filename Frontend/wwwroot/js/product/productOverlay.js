import { bindOverlayCloseEvents, closeOverlay, openOverlay } from "../shared/overlay.js";
import { addCartItems } from "../cart/cart.js";
import { formOverlayTimeout } from "../SystemSettings.js";
function getProductOverlayElements() {
    const productOverlay = document.querySelector("[data-product-overlay]");
    const productPopup = productOverlay?.querySelector(".product-popup");
    const productForm = productOverlay?.querySelector("[data-product-form]");
    const detailImage = productOverlay?.querySelector("[data-product-detail-image]");
    const detailName = productOverlay?.querySelector("[data-product-detail-name]");
    const detailPrice = productOverlay?.querySelector("[data-product-detail-price]");
    const detailSalePrice = productOverlay?.querySelector("[data-product-detail-sale-price]");
    const detailDiscount = productOverlay?.querySelector("[data-product-detail-discount]");
    const detailDescription = productOverlay?.querySelector("[data-product-detail-description]");
    const detailAddButton = productOverlay?.querySelector("[data-product-detail-add]");
    if (!productOverlay || !productPopup || !productForm || !detailImage || !detailName ||
        !detailPrice || !detailSalePrice || !detailDiscount || !detailDescription || !detailAddButton) {
        return null;
    }
    return {
        productOverlay,
        productPopup,
        productCards: document.querySelectorAll("[data-product-card]"),
        productCloseButton: productOverlay.querySelector("[data-product-close]"),
        productForm,
        detailImage,
        detailName,
        detailPrice,
        detailSalePrice,
        detailDiscount,
        detailDescription,
        detailAddButton,
        detailBuyButton: productOverlay.querySelector("[data-product-detail-buy]")
    };
}
function updateProductDetails(elements, card) {
    const { detailImage, detailName, detailPrice, detailSalePrice, detailDiscount, detailDescription } = elements;
    detailImage.src = card.dataset.productImage ?? "";
    detailImage.alt = card.dataset.productName ?? "";
    detailName.textContent = card.dataset.productName ?? "";
    detailPrice.textContent = card.dataset.productPrice ?? "";
    detailSalePrice.textContent = card.dataset.productSalePrice ?? "";
    detailDiscount.textContent = card.dataset.productDiscount ?? "";
    detailDescription.textContent = card.dataset.productDescription ?? "";
}
function resetProductForm(elements) {
    elements.productForm.reset();
    elements.detailAddButton.textContent = "Add to cart";
}
function openProductPopup(elements, card, closeTimer) {
    if (closeTimer) {
        window.clearTimeout(closeTimer);
    }
    updateProductDetails(elements, card);
    resetProductForm(elements);
    openOverlay(elements.productOverlay);
    return undefined;
}
function closeProductPopup(elements, closeTimer) {
    return closeOverlay(elements.productOverlay, closeTimer);
}
function handleProductCardClick(event, card, openPopup) {
    if (!event.target.closest("button")) {
        openPopup(card);
    }
}
function handleAddToCart(event) {
    event.stopPropagation();
    addCartItems();
    event.currentTarget.textContent = "Added";
}
function handleBuyNow(event, card, openPopup) {
    event.stopPropagation();
    openPopup(card);
}
function bindProductCards(elements, openPopup) {
    elements.productCards.forEach((card) => {
        card.addEventListener("click", (event) => {
            handleProductCardClick(event, card, openPopup);
        });
        card.querySelector("[data-product-add]")?.addEventListener("click", handleAddToCart);
        card.querySelector("[data-product-buy]")?.addEventListener("click", (event) => {
            handleBuyNow(event, card, openPopup);
        });
    });
}
function bindProductForm(elements, closePopup) {
    elements.productForm.addEventListener("submit", (event) => {
        event.preventDefault();
        const quantityInput = elements.productForm.elements.namedItem("quantity");
        const quantity = Number(quantityInput?.value ?? 1);
        addCartItems(Number.isFinite(quantity) && quantity > 0 ? quantity : 1);
        elements.detailAddButton.textContent = "Added to cart";
        window.setTimeout(closePopup, formOverlayTimeout);
    });
    elements.detailBuyButton?.addEventListener("click", closePopup);
}
function bindEscapeKey(elements, closePopup) {
    document.addEventListener("keydown", (event) => {
        if (event.key === "Escape" && !elements.productOverlay.hidden) {
            closePopup();
        }
    });
}
export function initializeProductOverlay() {
    const elements = getProductOverlayElements();
    if (!elements) {
        return;
    }
    let closeTimer;
    const openPopup = (card) => {
        closeTimer = openProductPopup(elements, card, closeTimer);
    };
    const closePopup = () => {
        closeTimer = closeProductPopup(elements, closeTimer);
    };
    bindProductCards(elements, openPopup);
    bindOverlayCloseEvents(elements.productOverlay, elements.productPopup, elements.productCloseButton, closePopup);
    bindProductForm(elements, closePopup);
    bindEscapeKey(elements, closePopup);
}
//# sourceMappingURL=productOverlay.js.map