"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
function getUserId() {
    return __awaiter(this, void 0, void 0, function* () {
        const userIdElement = document.getElementById("userId");
        const userId = userIdElement.value;
        if (!userId) {
            alert("Inserisci un ID!");
            return;
        }
        try {
            const response = yield fetch(`https://localhost:7042/User/${userId}`, {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json'
                }
            });
            if (!response.ok)
                throw new Error("Utente non trovato");
            const user = yield response.json();
            const outputElement = document.getElementById("output");
            if (!outputElement)
                throw new Error("Output element not found");
            outputElement.textContent = JSON.stringify(user, null, 2);
        }
        catch (error) {
            const outputElement = document.getElementById("output");
            if (outputElement) {
                outputElement.textContent = error instanceof Error ? error.message : "An unknown error occurred";
            }
        }
    });
}
