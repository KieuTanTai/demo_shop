import {animationDuration} from "../SystemSettings.js";

export function openOverlay(overlay: HTMLElement): void {
        overlay.hidden = false;
        overlay.classList.remove("is-closing");

        requestAnimationFrame(() => {
            overlay.classList.add("is-visible");
        });
}

export function closeOverlay(overlay: HTMLElement, closeTimer: number | undefined): number {
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

export function bindOverlayCloseEvents(
        overlay: HTMLElement,
        popup: HTMLElement | null,
        closeButton: HTMLButtonElement | null,
        closePopup: () => void
): void {
        closeButton?.addEventListener("click", closePopup);
        overlay.addEventListener("click", (event: MouseEvent) => {
                if (!popup?.contains(event.target as Node)) {
                        closePopup();
                }
        });
}
