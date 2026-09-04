import { bindOverlayCloseEvents, closeOverlay, openOverlay } from "../shared/overlay.js";
import { visibleSteps, ForgotPasswordStage } from "./ForgotPasswordStepsRecord.js";
import type { AuthFormName } from "./AuthFormType.js";
import type { AuthOverlayElements } from "./AuthOverlayElementsInterface.js";


function getAuthOverlayElements(): AuthOverlayElements | null {
    const authOverlay = document.querySelector<HTMLElement>("[data-auth-overlay]");

    if (!authOverlay) {
        return null;
    }

    return {
        authOverlay,
        authPopup: authOverlay.querySelector<HTMLElement>(".auth-popup"),
        authForms: document.querySelectorAll<HTMLFormElement>("[data-auth-form]"),
        authOpenButtons: document.querySelectorAll<HTMLButtonElement>("[data-auth-open]"),
        authCloseButton: authOverlay.querySelector<HTMLButtonElement>("[data-auth-close]"),
        authSwitchButtons: document.querySelectorAll<HTMLButtonElement>("[data-auth-switch]"),
        forgotForm: document.querySelector<HTMLFormElement>("[data-forgot-form]"),
        forgotNextButtons: document.querySelectorAll<HTMLButtonElement>("[data-forgot-next]"),
        forgotSubmitButton: document.querySelector<HTMLButtonElement>("[data-forgot-submit]")
    };
}

function getFormInput(form: HTMLFormElement, name: string): HTMLInputElement | null {
    return form.elements.namedItem(name) as HTMLInputElement | null;
}

function setAuthMessage(form: HTMLFormElement | null, message: string): void {
    const messageBox = form?.querySelector<HTMLElement>("[data-auth-message]");

    if (!messageBox) {
        return;
    }

    messageBox.textContent = message;
    messageBox.hidden = !message;
}

function clearAuthMessages(elements: AuthOverlayElements): void {
    elements.authForms.forEach((form) => setAuthMessage(form, ""));
}

function setForgotStage(elements: AuthOverlayElements, stage: ForgotPasswordStage): void {
    const { forgotForm, forgotNextButtons, forgotSubmitButton } = elements;

    if (!forgotForm) {
        return;
    }

    forgotForm.querySelectorAll<HTMLElement>("[data-forgot-step]").forEach((field) => {
        field.hidden = visibleSteps[stage].indexOf(field.dataset.forgotStep ?? "") === -1;
    });

    const nextAction = stage === "email" ? "code" : stage === "code" ? "reset" : "";
    forgotNextButtons.forEach((button) => {
        button.hidden = button.dataset.forgotNext !== nextAction;
    });

    if (forgotSubmitButton) {
        forgotSubmitButton.hidden = stage !== "reset";
    }
}

function resetForgotForm(elements: AuthOverlayElements): void {
    elements.forgotForm?.reset();
    setForgotStage(elements, "email");
}

function setActiveAuthForm(elements: AuthOverlayElements, formName: AuthFormName): void {
    elements.authForms.forEach((form) => {
        form.classList.toggle("active", form.dataset.authForm === formName);
    });

    clearAuthMessages(elements);
    if (formName === "forgot") {
        resetForgotForm(elements);
    }
}

function focusActiveAuthInput(elements: AuthOverlayElements): void {
    elements.authOverlay.querySelector<HTMLInputElement>(".auth-form.active input")?.focus();
}

function openAuthPopup(
    elements: AuthOverlayElements,
    formName: AuthFormName,
    closeTimer: number | undefined
): number | undefined {
    if (closeTimer) {
        window.clearTimeout(closeTimer);
    }

    setActiveAuthForm(elements, formName);
    openOverlay(elements.authOverlay);
    focusActiveAuthInput(elements);
    return undefined;
}

function handleAuthSubmit(
    form: HTMLFormElement,
    closePopup: () => void,
    event: SubmitEvent
): void {
    event.preventDefault();

    if (form.dataset.authForm === "forgot") {
        const newPassword = getFormInput(form, "newPassword")?.value.trim();
        const confirmNewPassword = getFormInput(form, "confirmNewPassword")?.value.trim();

        if (!newPassword || !confirmNewPassword) {
            setAuthMessage(form, "Please enter and confirm the new password.");
            return;
        }

        if (newPassword !== confirmNewPassword) {
            setAuthMessage(form, "New password and confirmation do not match.");
            return;
        }

        setAuthMessage(form, "");
        closePopup();
        return;
    }

    if (!form.checkValidity()) {
        setAuthMessage(form, "Please fill in all required fields correctly.");
        return;
    }

    setAuthMessage(form, "");
}

function handleForgotNext(elements: AuthOverlayElements, button: HTMLButtonElement): void {
    const { forgotForm } = elements;

    if (!forgotForm) {
        return;
    }

    if (button.dataset.forgotNext === "code") {
        const email = getFormInput(forgotForm, "registeredEmail");

        if (!email?.value.trim() || !email.checkValidity()) {
            setAuthMessage(forgotForm, "Please enter the registered email.");
            email?.focus();
            return;
        }

        setAuthMessage(forgotForm, "");
        setForgotStage(elements, "code");
        getFormInput(forgotForm, "passcode")?.focus();
        return;
    }

    const passcode = getFormInput(forgotForm, "passcode");
    if (!passcode?.value.trim()) {
        setAuthMessage(forgotForm, "Please enter the passcode.");
        passcode?.focus();
        return;
    }

    setAuthMessage(forgotForm, "");
    setForgotStage(elements, "reset");
    getFormInput(forgotForm, "newPassword")?.focus();
}

function bindAuthOpenButtons(
    elements: AuthOverlayElements,
    updateCloseTimer: (timer: number | undefined) => void,
    getCloseTimer: () => number | undefined
): void {
    elements.authOpenButtons.forEach((button) => {
        button.addEventListener("click", () => {
            const formName = (button.dataset.authOpen ?? "login") as AuthFormName;
            updateCloseTimer(openAuthPopup(elements, formName, getCloseTimer()));
        });
    });
}

function bindAuthSwitchButtons(elements: AuthOverlayElements): void {
    elements.authSwitchButtons.forEach((button) => {
        button.addEventListener("click", () => {
            setActiveAuthForm(elements, (button.dataset.authSwitch ?? "login") as AuthFormName);
            focusActiveAuthInput(elements);
        });
    });
}

function bindAuthForms(elements: AuthOverlayElements, closePopup: () => void): void {
    elements.authForms.forEach((form) => {
        form.addEventListener("submit", (event: SubmitEvent) => {
            handleAuthSubmit(form, closePopup, event);
        });
    });
}

function bindForgotPasswordButtons(elements: AuthOverlayElements): void {
    elements.forgotNextButtons.forEach((button) => {
        button.addEventListener("click", () => handleForgotNext(elements, button));
    });
}

function bindEscapeKey(elements: AuthOverlayElements, closePopup: () => void): void {
    document.addEventListener("keydown", (event: KeyboardEvent) => {
        if (event.key === "Escape" && !elements.authOverlay.hidden) {
            closePopup();
        }
    });
}

export function initializeAuthOverlay(): void {
    const elements = getAuthOverlayElements();

    if (!elements) {
        return;
    }

    let closeTimer: number | undefined;
    const getCloseTimer = (): number | undefined => closeTimer;
    const updateCloseTimer = (timer: number | undefined): void => {
        closeTimer = timer;
    };
    const closePopup = (): void => {
        closeTimer = closeOverlay(elements.authOverlay, closeTimer);
    };

    bindAuthOpenButtons(elements, updateCloseTimer, getCloseTimer); // first form open
    bindAuthSwitchButtons(elements);
    bindOverlayCloseEvents(elements.authOverlay, elements.authPopup, elements.authCloseButton, closePopup);
    bindAuthForms(elements, closePopup);
    bindForgotPasswordButtons(elements);
    bindEscapeKey(elements, closePopup);
}
