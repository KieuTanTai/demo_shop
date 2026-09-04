import { animationDuration } from "../SystemSettings.js";
export function openOverlay(overlay) {
    overlay.hidden = false;
    overlay.classList.remove("is-closing");
    requestAnimationFrame(() => {
        overlay.classList.add("is-visible");
    });
}
export function closeOverlay(overlay, closeTimer) {
    if (overlay.hidden) {
        return closeTimer ?? 0;
    }
    if (closeTimer) {
        window.clearTimeout(closeTimer);
    }
    overlay.classList.remove("is-visible");
    overlay.classList.add("is-closing");
    return window.setTimeout(() => {
        overlay.hidden = true;
        overlay.classList.remove("is-closing");
    }, animationDuration);
}
export function bindOverlayCloseEvents(overlay, popup, closeButton, closePopup) {
    closeButton?.addEventListener("click", closePopup);
    overlay.addEventListener("click", (event) => {
        if (!popup?.contains(event.target)) {
            closePopup();
        }
    });
}
//# sourceMappingURL=overlay.js.map