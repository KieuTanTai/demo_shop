const cartUpdatedEvent = "cart:updated";

export function addCartItems(quantity = 1): void {
    if (quantity < 1) {
        return;
    }

    document.dispatchEvent(new CustomEvent(cartUpdatedEvent, {
        detail: {quantity}
    }));
}

function updateCartBadge(badge: HTMLElement, count: number): void {
    badge.textContent = count > 99 ? "99+" : String(count);
    badge.classList.toggle("hidden", count === 0);
}

export function initializeCartBadge(): void {
    const cartBadge = document.querySelector<HTMLElement>("[data-cart-count]");

    if (!cartBadge) {
        return;
    }

    let cartCount = 0;
    updateCartBadge(cartBadge, cartCount);

    document.addEventListener(cartUpdatedEvent, (event: Event) => {
        const quantity = (event as CustomEvent<{ quantity?: number }>).detail?.quantity ?? 0;
        cartCount += quantity;
        updateCartBadge(cartBadge, cartCount);
    });
}
