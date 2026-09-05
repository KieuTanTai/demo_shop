export async function login(email, password) {
    if (!email || !password || email.trim().length === 0 || password.trim().length === 0) {
        return;
    }
    try {
        const response = await fetch("/Auth/Login", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({ email, password })
        });
        if (response.ok) {
        }
    }
    catch (error) {
        console.error("Error during loginRequest:", error);
    }
}
//# sourceMappingURL=loginRequest.js.map