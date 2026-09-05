function getAccountMenuElements() {
    const menu = document.querySelector(".account-menu");
    const dropdown = menu?.querySelector(".account-dropdown");
    if (!menu || !dropdown) {
        return null;
    }
    return {
        menu,
        button: menu.querySelector(".account-button"),
        dropdown
    };
}
function setAccountMenuState(elements, isOpen) {
    elements.dropdown.classList.toggle("hidden", !isOpen);
    elements.menu.classList.toggle("is-open", isOpen);
    elements.button?.setAttribute("aria-expanded", String(isOpen));
}
function openAccountMenu(elements) {
    setAccountMenuState(elements, true);
}
function closeAccountMenu(elements) {
    setAccountMenuState(elements, false);
}
function bindPointerAndFocusEvents(elements) {
    elements.menu.addEventListener("mouseenter", () => openAccountMenu(elements));
    elements.menu.addEventListener("mouseleave", () => closeAccountMenu(elements));
    elements.menu.addEventListener("focusin", () => openAccountMenu(elements));
    elements.menu.addEventListener("focusout", (event) => {
        if (!elements.menu.contains(event.relatedTarget)) {
            closeAccountMenu(elements);
        }
    });
}
function bindEscapeKey(elements) {
    document.addEventListener("keydown", (event) => {
        if (event.key === "Escape") {
            closeAccountMenu(elements);
        }
    });
}
export function initializeAccountMenu() {
    const elements = getAccountMenuElements();
    if (!elements) {
        return;
    }
    bindPointerAndFocusEvents(elements);
    bindEscapeKey(elements);
}
//# sourceMappingURL=accountMenu.js.map