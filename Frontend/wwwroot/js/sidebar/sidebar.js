function getSidebarElements() {
    const appShell = document.querySelector("[data-app-shell]");
    const sidebarToggle = document.querySelector("[data-sidebar-toggle]");
    if (!appShell || !sidebarToggle) {
        return null;
    }
    return { appShell, sidebarToggle };
}
function setSidebarState(elements, isCollapsed) {
    elements.appShell.classList.toggle("sidebar-collapsed", isCollapsed);
    elements.sidebarToggle.setAttribute("aria-expanded", String(!isCollapsed));
}
function toggleSidebar(elements) {
    const isCollapsed = elements.appShell.classList.contains("sidebar-collapsed");
    setSidebarState(elements, !isCollapsed);
}
function bindSidebarToggle(elements) {
    elements.sidebarToggle.addEventListener("click", () => toggleSidebar(elements));
}
export function initializeSidebar() {
    const elements = getSidebarElements();
    if (!elements) {
        return;
    }
    bindSidebarToggle(elements);
}
//# sourceMappingURL=sidebar.js.map