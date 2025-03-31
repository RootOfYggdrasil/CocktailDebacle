async function getUserId() {
    const userIdElement = document.getElementById("userId");
    const userId = (userIdElement as HTMLInputElement).value;
    if (!userId) {
        alert("Inserisci un ID!");
        return;
    }
    
    try {
        const response = await fetch(`https://localhost:7042/User/${userId}`, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        });
        if (!response.ok) throw new Error("Utente non trovato");
        const user = await response.json();
        const outputElement = document.getElementById("output");
        if (!outputElement) throw new Error("Output element not found");
        outputElement.textContent = JSON.stringify(user, null, 2);
    } catch (error) {
        const outputElement = document.getElementById("output");
        if (outputElement) {
            outputElement.textContent = error instanceof Error ? error.message : "An unknown error occurred";
        }
    }
}
