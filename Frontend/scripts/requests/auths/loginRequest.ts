export async function loginRequest(email: string, password: string): Promise<unknown> {
    if (!email || !password || email.trim().length === 0 || password.trim().length === 0) {
        throw new Error("Email and password are required.");
    }

    const response = await fetch("/Auth/Login", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({email: email.trim(), password})
    });

    const responseBody = await response.text();
    if (!response.ok) {
        throw new Error(responseBody || "Login failed.");
    }

    return responseBody ? JSON.parse(responseBody) : null;
}
