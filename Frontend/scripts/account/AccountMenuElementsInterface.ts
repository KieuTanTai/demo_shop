export interface AccountMenuElements {
    menu: HTMLElement;
    button: HTMLButtonElement | null;
    dropdown: HTMLElement;
    guestActions: NodeListOf<HTMLButtonElement>;
    authenticatedAction: HTMLButtonElement | null;
}
