import {AccountMenuElements} from "./AccountMenuElementsInterface.js";

const authStateStorageKey = "frontend.authenticated";

function getAccountMenuElements(): AccountMenuElements | null {
    const menu = document.querySelector<HTMLElement>(".account-menu");
    const dropdown = menu?.querySelector<HTMLElement>(".account-dropdown");

    if (!menu || !dropdown) {
        return null;
    }

    return {
        menu,
        button: menu.querySelector<HTMLButtonElement>(".account-button"),
        dropdown,
        guestActions: menu.querySelectorAll<HTMLButtonElement>("[data-auth-guest]"),
        authenticatedAction: menu.querySelector<HTMLButtonElement>("[data-authenticated-action]")
    };
}

function setAuthenticatedState(elements: AccountMenuElements, isAuthenticated: boolean): void {
    elements.guestActions.forEach((action) => {
        action.hidden = isAuthenticated;
    });

    if (elements.authenticatedAction) {
        elements.authenticatedAction.hidden = !isAuthenticated;
    }
}

function getStoredAuthState(): boolean {
    return sessionStorage.getItem(authStateStorageKey) === "true";
}

function setStoredAuthState(isAuthenticated: boolean): void {
    if (isAuthenticated) {
        sessionStorage.setItem(authStateStorageKey, "true");
        return;
    }

    sessionStorage.removeItem(authStateStorageKey);
}

function setAccountMenuState(elements: AccountMenuElements, isOpen: boolean): void {
    elements.dropdown.classList.toggle("hidden", !isOpen);
    elements.menu.classList.toggle("is-open", isOpen);
    elements.button?.setAttribute("aria-expanded", String(isOpen));
}

function openAccountMenu(elements: AccountMenuElements): void {
    setAccountMenuState(elements, true);
}

function closeAccountMenu(elements: AccountMenuElements): void {
    setAccountMenuState(elements, false);
}

function bindPointerAndFocusEvents(elements: AccountMenuElements): void {
    elements.menu.addEventListener("mouseenter", () => openAccountMenu(elements));
    elements.menu.addEventListener("mouseleave", () => closeAccountMenu(elements));
    elements.menu.addEventListener("focusin", () => openAccountMenu(elements));
    elements.menu.addEventListener("focusout", (event: FocusEvent) => {
        if (!elements.menu.contains(event.relatedTarget as Node | null)) {
            closeAccountMenu(elements);
        }
    });
}

function bindEscapeKey(elements: AccountMenuElements): void {
    document.addEventListener("keydown", (event: KeyboardEvent) => {
        if (event.key === "Escape") {
            closeAccountMenu(elements);
        }
    });
}

function bindAuthStateEvents(elements: AccountMenuElements): void {
    setAuthenticatedState(elements, getStoredAuthState());

    window.addEventListener("auth-state-changed", (event: Event) => {
        const customEvent = event as CustomEvent<{isAuthenticated: boolean}>;
        const isAuthenticated = customEvent.detail?.isAuthenticated;
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

export function initializeAccountMenu(): void {
    const elements = getAccountMenuElements();

    if (!elements) {
        return;
    }

    bindPointerAndFocusEvents(elements);
    bindEscapeKey(elements);
    bindAuthStateEvents(elements);
}
