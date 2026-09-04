const cartUpdatedEvent = "cart:updated";
export function addCartItems(quantity = 1) {
    if (quantity < 1) {
        return;
    }
    document.dispatchEvent(new CustomEvent(cartUpdatedEvent, {
        detail: { quantity }
    }));
}
function updateCartBadge(badge, count) {
    badge.textContent = count > 99 ? "99+" : String(count);
    badge.classList.toggle("hidden", count === 0);
}
export function initializeCartBadge() {
    const cartBadge = document.querySelector("[data-cart-count]");
    if (!cartBadge) {
        return;
    }
    let cartCount = 0;
    updateCartBadge(cartBadge, cartCount);
    document.addEventListener(cartUpdatedEvent, (event) => {
        const quantity = event.detail?.quantity ?? 0;
        cartCount += quantity;
        updateCartBadge(cartBadge, cartCount);
    });
}
//# sourceMappingURL=cart.js.map