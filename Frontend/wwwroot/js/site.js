const appShell = document.querySelector("[data-app-shell]");
const sidebarToggle = document.querySelector("[data-sidebar-toggle]");
const authOverlay = document.querySelector("[data-auth-overlay]");
const authPopup = document.querySelector(".auth-popup");
const authOpenButtons = document.querySelectorAll("[data-auth-open]");
const authCloseButton = document.querySelector("[data-auth-close]");
const authSwitchButtons = document.querySelectorAll("[data-auth-switch]");
const authForms = document.querySelectorAll("[data-auth-form]");
const forgotForm = document.querySelector("[data-forgot-form]");
const forgotNextButtons = document.querySelectorAll("[data-forgot-next]");
const forgotSubmitButton = document.querySelector("[data-forgot-submit]");

if (appShell && sidebarToggle) {
    sidebarToggle.addEventListener("click", () => {
        const isCollapsed = appShell.classList.toggle("sidebar-collapsed");
        sidebarToggle.setAttribute("aria-expanded", String(!isCollapsed));
    });
}

function setAuthMessage(form, message) {
    const messageBox = form?.querySelector("[data-auth-message]");

    if (!messageBox) {
        return;
    }

    messageBox.textContent = message;
    messageBox.hidden = !message;
}

function clearAuthMessages() {
    authForms.forEach((form) => setAuthMessage(form, ""));
}

function resetForgotForm() {
    if (!forgotForm) {
        return;
    }

    forgotForm.reset();
    setForgotStage("email");
}

function setActiveAuthForm(formName) {
    authForms.forEach((form) => {
        form.classList.toggle("active", form.dataset.authForm === formName);
    });

    clearAuthMessages();

    if (formName === "forgot") {
        resetForgotForm();
    }
}

function openAuthPopup(formName) {
    if (!authOverlay) {
        return;
    }

    setActiveAuthForm(formName);
    authOverlay.hidden = false;

    const activeInput = authOverlay.querySelector(".auth-form.active input");
    activeInput?.focus();
}

function closeAuthPopup() {
    if (!authOverlay) {
        return;
    }

    authOverlay.hidden = true;
}

authOpenButtons.forEach((button) => {
    button.addEventListener("click", () => {
        openAuthPopup(button.dataset.authOpen);
    });
});

authSwitchButtons.forEach((button) => {
    button.addEventListener("click", () => {
        setActiveAuthForm(button.dataset.authSwitch);
        authOverlay?.querySelector(".auth-form.active input")?.focus();
    });
});

authCloseButton?.addEventListener("click", closeAuthPopup);

authOverlay?.addEventListener("click", (event) => {
    if (!authPopup?.contains(event.target)) {
        closeAuthPopup();
    }
});

document.addEventListener("keydown", (event) => {
    if (event.key === "Escape" && authOverlay && !authOverlay.hidden) {
        closeAuthPopup();
    }
});

authForms.forEach((form) => {
    form.addEventListener("submit", (event) => {
        event.preventDefault();

        if (form.dataset.authForm === "forgot") {
            const newPassword = form.elements.newPassword?.value.trim();
            const confirmNewPassword = form.elements.confirmNewPassword?.value.trim();

            if (!newPassword || !confirmNewPassword) {
                setAuthMessage(form, "Please enter and confirm the new password.");
                return;
            }

            if (newPassword !== confirmNewPassword) {
                setAuthMessage(form, "New password and confirmation do not match.");
                return;
            }

            setAuthMessage(form, "");
            closeAuthPopup();
            return;
        }

        if (!form.checkValidity()) {
            setAuthMessage(form, "Please fill in all required fields correctly.");
            return;
        }

        setAuthMessage(form, "");
    });
});

function setForgotStage(stage) {
    if (!forgotForm) {
        return;
    }

    const visibleSteps = {
        email: ["email"],
        code: ["email", "code"],
        reset: ["email", "code", "reset"]
    };

    forgotForm.querySelectorAll("[data-forgot-step]").forEach((field) => {
        field.hidden = !visibleSteps[stage].includes(field.dataset.forgotStep);
    });

    const nextAction = stage === "email" ? "code" : stage === "code" ? "reset" : "";

    forgotNextButtons.forEach((button) => {
        button.hidden = button.dataset.forgotNext !== nextAction;
    });

    if (forgotSubmitButton) {
        forgotSubmitButton.hidden = stage !== "reset";
    }
}

forgotNextButtons.forEach((button) => {
    button.addEventListener("click", () => {
        if (!forgotForm) {
            return;
        }

        if (button.dataset.forgotNext === "code") {
            const registeredEmail = forgotForm.elements.registeredEmail?.value.trim();

            if (!registeredEmail || !forgotForm.elements.registeredEmail?.checkValidity()) {
                setAuthMessage(forgotForm, "Please enter the registered email.");
                forgotForm.elements.registeredEmail?.focus();
                return;
            }

            setAuthMessage(forgotForm, "");
            setForgotStage("code");
            forgotForm.elements.passcode?.focus();
            return;
        }

        const passcode = forgotForm.elements.passcode?.value.trim();

        if (!passcode) {
            setAuthMessage(forgotForm, "Please enter the passcode.");
            forgotForm.elements.passcode?.focus();
            return;
        }

        setAuthMessage(forgotForm, "");
        setForgotStage("reset");
        forgotForm.elements.newPassword?.focus();
    });
});
