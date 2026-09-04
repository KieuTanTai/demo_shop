document.addEventListener("DOMContentLoaded", () => {
    const appShell = document.querySelector("[data-app-shell]");
    const sidebarToggle = document.querySelector("[data-sidebar-toggle]");
    const authOverlay = document.querySelector("[data-auth-overlay]");
    const authPopup = document.querySelector(".auth-popup");
    const accountMenu = document.querySelector(".account-menu");
    const accountButton = accountMenu?.querySelector(".account-button");
    const accountDropdown = document.querySelector(".account-dropdown");
    const authOpenButtons = document.querySelectorAll("[data-auth-open]");
    const authCloseButton = document.querySelector("[data-auth-close]");
    const authSwitchButtons = document.querySelectorAll("[data-auth-switch]");
    const authForms = document.querySelectorAll("[data-auth-form]");
    const forgotForm = document.querySelector("[data-forgot-form]");
    const forgotNextButtons = document.querySelectorAll("[data-forgot-next]");
    const forgotSubmitButton = document.querySelector("[data-forgot-submit]");
    const productOverlay = document.querySelector("[data-product-overlay]");
    const productPopup = productOverlay?.querySelector(".product-popup");
    const productCards = document.querySelectorAll("[data-product-card]");
    const productCloseButton = productOverlay?.querySelector("[data-product-close]");
    const productForm = productOverlay?.querySelector("[data-product-form]");
    const productDetailImage = productOverlay?.querySelector("[data-product-detail-image]");
    const productDetailName = productOverlay?.querySelector("[data-product-detail-name]");
    const productDetailPrice = productOverlay?.querySelector("[data-product-detail-price]");
    const productDetailSalePrice = productOverlay?.querySelector("[data-product-detail-sale-price]");
    const productDetailDiscount = productOverlay?.querySelector("[data-product-detail-discount]");
    const productDetailDescription = productOverlay?.querySelector("[data-product-detail-description]");
    const productDetailAddButton = productOverlay?.querySelector("[data-product-detail-add]");
    const productDetailBuyButton = productOverlay?.querySelector("[data-product-detail-buy]");
    const authAnimationDuration = 180;
    let authCloseTimer;
    let productCloseTimer;

    function closeAccountDropdown() {
        if (!accountDropdown) {
            return;
        }

        accountDropdown.classList.add("hidden");
        accountMenu?.classList.remove("is-open");
        accountButton?.setAttribute("aria-expanded", "false");
    }

    function openAccountDropdown() {
        if (!accountDropdown) {
            return;
        }

        accountDropdown.classList.remove("hidden");
        accountMenu?.classList.add("is-open");
        accountButton?.setAttribute("aria-expanded", "true");
    }

    if (accountMenu && accountDropdown) {
        accountButton?.addEventListener("click", () => {
            const isOpen = accountMenu.classList.contains("is-open");
            isOpen ? closeAccountDropdown() : openAccountDropdown();
        });
        accountMenu.addEventListener("mouseenter", openAccountDropdown);
        accountMenu.addEventListener("mouseleave", closeAccountDropdown);
        accountMenu.addEventListener("focusin", openAccountDropdown);
        accountMenu.addEventListener("focusout", (event) => {
            if (!accountMenu.contains(event.relatedTarget)) {
                closeAccountDropdown();
            }
        });
    }

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

        clearTimeout(authCloseTimer);
        setActiveAuthForm(formName);
        authOverlay.hidden = false;
        authOverlay.classList.remove("is-closing");
        requestAnimationFrame(() => {
            authOverlay.classList.add("is-visible");
        });

        const activeInput = authOverlay.querySelector(".auth-form.active input");
        activeInput?.focus();
    }

    function closeAuthPopup() {
        if (!authOverlay || authOverlay.hidden) {
            return;
        }

        clearTimeout(authCloseTimer);
        authOverlay.classList.remove("is-visible");
        authOverlay.classList.add("is-closing");

        authCloseTimer = setTimeout(() => {
            authOverlay.hidden = true;
            authOverlay.classList.remove("is-closing");
        }, authAnimationDuration);
    }

    function openProductPopup(card) {
        if (!productOverlay || !card) {
            return;
        }

        clearTimeout(productCloseTimer);
        productDetailImage.src = card.dataset.productImage;
        productDetailImage.alt = card.dataset.productName;
        productDetailName.textContent = card.dataset.productName;
        productDetailPrice.textContent = card.dataset.productPrice;
        productDetailSalePrice.textContent = card.dataset.productSalePrice;
        productDetailDiscount.textContent = card.dataset.productDiscount;
        productDetailDescription.textContent = card.dataset.productDescription;
        productForm?.reset();
        productDetailAddButton.textContent = "Add to cart";
        productOverlay.hidden = false;
        productOverlay.classList.remove("is-closing");
        requestAnimationFrame(() => {
            productOverlay.classList.add("is-visible");
        });
        productForm?.querySelector("input")?.focus();
    }

    function closeProductPopup() {
        if (!productOverlay || productOverlay.hidden) {
            return;
        }

        clearTimeout(productCloseTimer);
        productOverlay.classList.remove("is-visible");
        productOverlay.classList.add("is-closing");
        productCloseTimer = setTimeout(() => {
            productOverlay.hidden = true;
            productOverlay.classList.remove("is-closing");
        }, authAnimationDuration);
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

    productCards.forEach((card) => {
        card.addEventListener("click", (event) => {
            if (!event.target.closest("button")) {
                openProductPopup(card);
            }
        });

        card.addEventListener("keydown", (event) => {
            if ((event.key === "Enter" || event.key === " ") && event.target === card) {
                event.preventDefault();
                openProductPopup(card);
            }
        });

        card.querySelector("[data-product-add]")?.addEventListener("click", (event) => {
            event.stopPropagation();
            event.currentTarget.textContent = "Added";
        });

        card.querySelector("[data-product-buy]")?.addEventListener("click", (event) => {
            event.stopPropagation();
            openProductPopup(card);
        });
    });

    productCloseButton?.addEventListener("click", closeProductPopup);

    productOverlay?.addEventListener("click", (event) => {
        if (!productPopup?.contains(event.target)) {
            closeProductPopup();
        }
    });

    productForm?.addEventListener("submit", (event) => {
        event.preventDefault();
        productDetailAddButton.textContent = "Added to cart";
        window.setTimeout(closeProductPopup, 450);
    });

    productDetailBuyButton?.addEventListener("click", closeProductPopup);

    document.addEventListener("keydown", (event) => {
        if (event.key === "Escape" && authOverlay && !authOverlay.hidden) {
            closeAuthPopup();
        }

        if (event.key === "Escape") {
            closeAccountDropdown();
        }

        if (event.key === "Escape" && productOverlay && !productOverlay.hidden) {
            closeProductPopup();
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
});
