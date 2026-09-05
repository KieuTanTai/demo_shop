import { bindOverlayCloseEvents, closeOverlay, openOverlay } from "../shared/overlay.js";
import { loginRequest } from "../requests/auths/loginRequest.js";
import { visibleSteps } from "./ForgotPasswordStepsRecord.js";
function getAuthOverlayElements() {
    const authOverlay = document.querySelector("[data-auth-overlay]");
    if (!authOverlay) {
        return null;
    }
    return {
        authOverlay,
        authPopup: authOverlay.querySelector(".auth-popup"),
        authForms: document.querySelectorAll("[data-auth-form]"),
        authOpenButtons: document.querySelectorAll("[data-auth-open]"),
        authCloseButton: authOverlay.querySelector("[data-auth-close]"),
        authSwitchButtons: document.querySelectorAll("[data-auth-switch]"),
        forgotForm: document.querySelector("[data-forgot-form]"),
        forgotNextButtons: document.querySelectorAll("[data-forgot-next]"),
        forgotSubmitButton: document.querySelector("[data-forgot-submit]")
    };
}
function getFormInput(form, name) {
    return form.elements.namedItem(name);
}
function setAuthMessage(form, message) {
    const messageBox = form?.querySelector("[data-auth-message]");
    if (!messageBox) {
        return;
    }
    messageBox.textContent = message;
    messageBox.hidden = !message;
}
function clearAuthMessages(elements) {
    elements.authForms.forEach((form) => setAuthMessage(form, ""));
}
function setForgotStage(elements, stage) {
    const { forgotForm, forgotNextButtons, forgotSubmitButton } = elements;
    if (!forgotForm) {
        return;
    }
    forgotForm.querySelectorAll("[data-forgot-step]").forEach((field) => {
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
function resetForgotForm(elements) {
    elements.forgotForm?.reset();
    setForgotStage(elements, "email");
}
function setActiveAuthForm(elements, formName) {
    elements.authForms.forEach((form) => {
        form.classList.toggle("active", form.dataset.authForm === formName);
    });
    clearAuthMessages(elements);
    if (formName === "forgot") {
        resetForgotForm(elements);
    }
}
function focusActiveAuthInput(elements) {
    elements.authOverlay.querySelector(".auth-form.active input")?.focus();
}
function openAuthPopup(elements, formName, closeTimer) {
    if (closeTimer) {
        window.clearTimeout(closeTimer);
    }
    setActiveAuthForm(elements, formName);
    openOverlay(elements.authOverlay);
    focusActiveAuthInput(elements);
    return undefined;
}
async function handleAuthSubmit(form, closePopup, event) {
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
    if (form.dataset.authForm === "login") {
        const email = getFormInput(form, "email")?.value.trim() ?? "";
        const password = getFormInput(form, "password")?.value ?? "";
        try {
            await loginRequest(email, password);
            window.dispatchEvent(new CustomEvent("auth-state-changed", {
                detail: { isAuthenticated: true }
            }));
            form.reset();
            closePopup();
        }
        catch (error) {
            const message = error instanceof Error ? error.message : "Login failed.";
            setAuthMessage(form, message);
        }
        return;
    }
    setAuthMessage(form, "");
}
function handleForgotNext(elements, button) {
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
function bindAuthOpenButtons(elements, updateCloseTimer, getCloseTimer) {
    elements.authOpenButtons.forEach((button) => {
        button.addEventListener("click", () => {
            const formName = (button.dataset.authOpen ?? "login");
            updateCloseTimer(openAuthPopup(elements, formName, getCloseTimer()));
        });
    });
}
function bindAuthSwitchButtons(elements) {
    elements.authSwitchButtons.forEach((button) => {
        button.addEventListener("click", () => {
            setActiveAuthForm(elements, (button.dataset.authSwitch ?? "login"));
            focusActiveAuthInput(elements);
        });
    });
}
function bindAuthForms(elements, closePopup) {
    elements.authForms.forEach((form) => {
        form.addEventListener("submit", (event) => {
            void handleAuthSubmit(form, closePopup, event);
        });
    });
}
function bindForgotPasswordButtons(elements) {
    elements.forgotNextButtons.forEach((button) => {
        button.addEventListener("click", () => handleForgotNext(elements, button));
    });
}
function bindEscapeKey(elements, closePopup) {
    document.addEventListener("keydown", (event) => {
        if (event.key === "Escape" && !elements.authOverlay.hidden) {
            closePopup();
        }
    });
}
export function initializeAuthOverlay() {
    const elements = getAuthOverlayElements();
    if (!elements) {
        return;
    }
    let closeTimer;
    const getCloseTimer = () => closeTimer;
    const updateCloseTimer = (timer) => {
        closeTimer = timer;
    };
    const closePopup = () => {
        closeTimer = closeOverlay(elements.authOverlay, closeTimer);
    };
    bindAuthOpenButtons(elements, updateCloseTimer, getCloseTimer); // first form open
    bindAuthSwitchButtons(elements);
    bindOverlayCloseEvents(elements.authOverlay, elements.authPopup, elements.authCloseButton, closePopup);
    bindAuthForms(elements, closePopup);
    bindForgotPasswordButtons(elements);
    bindEscapeKey(elements, closePopup);
}
//# sourceMappingURL=authOverlay.js.map