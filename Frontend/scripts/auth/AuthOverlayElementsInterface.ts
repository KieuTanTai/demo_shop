export interface AuthOverlayElements {
    authOverlay: HTMLElement;
    authPopup: HTMLElement | null;
    authForms: NodeListOf<HTMLFormElement>;
    authOpenButtons: NodeListOf<HTMLButtonElement>;
    authCloseButton: HTMLButtonElement | null;
    authSwitchButtons: NodeListOf<HTMLButtonElement>;
    forgotForm: HTMLFormElement | null;
    forgotNextButtons: NodeListOf<HTMLButtonElement>;
    forgotSubmitButton: HTMLButtonElement | null;
}
