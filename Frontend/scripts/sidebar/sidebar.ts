import type {SidebarElements} from "./SidebarElementsInterface.js";

function getSidebarElements(): SidebarElements | null {
    const appShell = document.querySelector<HTMLElement>("[data-app-shell]");
    const sidebarToggle = document.querySelector<HTMLButtonElement>("[data-sidebar-toggle]");

    if (!appShell || !sidebarToggle) {
        return null;
    }

    return {appShell, sidebarToggle};
}

function setSidebarState(elements: SidebarElements, isCollapsed: boolean): void {
    elements.appShell.classList.toggle("sidebar-collapsed", isCollapsed);
    elements.sidebarToggle.setAttribute("aria-expanded", String(!isCollapsed));
}

function toggleSidebar(elements: SidebarElements): void {
    const isCollapsed = elements.appShell.classList.contains("sidebar-collapsed");
    setSidebarState(elements, !isCollapsed);
}

function bindSidebarToggle(elements: SidebarElements): void {
    elements.sidebarToggle.addEventListener("click", () => toggleSidebar(elements));
}

export function initializeSidebar(): void {
    const elements = getSidebarElements();

    if (!elements) {
        return;
    }

    bindSidebarToggle(elements);
}
