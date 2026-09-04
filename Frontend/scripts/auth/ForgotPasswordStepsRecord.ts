export const visibleSteps: Record<string, string[]> = {
    email: ["email"],
    code: ["email", "code"],
    reset: ["email", "code", "reset"]
};

export type ForgotPasswordStage = "email" | "code" | "reset";
