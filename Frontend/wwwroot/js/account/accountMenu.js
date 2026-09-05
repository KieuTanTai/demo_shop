const authStateStorageKey = "frontend.authenticated";
function getAccountMenuElements() {
    const menu = document.querySelector(".account-menu");
    const dropdown = menu?.querySelector(".account-dropdown");
    if (!menu || !dropdown) {
        return null;
    }
    return {
        menu,
        button: menu.querySelector(".account-button"),
        dropdown,
        guestActions: menu.querySelectorAll("[data-auth-guest]"),
        authenticatedAction: menu.querySelector("[data-authenticated-action]")
    };
}
function setAuthenticatedState(elements, isAuthenticated) {
    elements.guestActions.forEach((action) => {
        action.hidden = isAuthenticated;
    });
    if (elements.authenticatedAction) {
        elements.authenticatedAction.hidden = !isAuthenticated;
    }
}
function getStoredAuthState() {
    return sessionStorage.getItem(authStateStorageKey) === "true";
}
function setStoredAuthState(isAuthenticated) {
    if (isAuthenticated) {
        sessionStorage.setItem(authStateStorageKey, "true");
        return;
    }
    sessionStorage.removeItem(authStateStorageKey);
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
function bindAuthStateEvents(elements) {
    setAuthenticatedState(elements, getStoredAuthState());
    window.addEventListener("auth-state-changed", (event) => {
        const customEvent = event;
        const isAuthenticated = customEvent.detail?.isAuthenticated === true;
        setStoredAuthState(isAuthenticated);
        setAuthenticatedState(elements, isAuthenticated);
        closeAccountMenu(elements);
    });
    elements.authenticatedAction?.addEventListener("click", () => {
        setStoredAuthState(false);
        setAuthenticatedState(elements, false);
        closeAccountMenu(elements);
    });
}
export function initializeAccountMenu() {
    const elements = getAccountMenuElements();
    if (!elements) {
        return;
    }
    bindPointerAndFocusEvents(elements);
    bindEscapeKey(elements);
    bindAuthStateEvents(elements);
}
//# sourceMappingURL=accountMenu.js.map