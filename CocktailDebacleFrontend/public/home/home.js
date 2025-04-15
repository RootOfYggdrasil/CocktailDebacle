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
const container = document.getElementById("cocktail-grid");
const namesSeen = new Set();
let isLoading = false;
function fetchRandomCocktail() {
    return __awaiter(this, void 0, void 0, function* () {
        const response = yield fetch("https://www.thecocktaildb.com/api/json/v1/1/random.php");
        const data = yield response.json();
        return data.drinks[0];
    });
}
function loadCocktails() {
    return __awaiter(this, arguments, void 0, function* (count = 10) {
        if (isLoading)
            return;
        isLoading = true;
        let loaded = 0;
        while (loaded < count) {
            const cocktail = yield fetchRandomCocktail();
            if (!namesSeen.has(cocktail.strDrink)) {
                namesSeen.add(cocktail.strDrink);
                const col = document.createElement("div");
                col.className = "col";
                col.innerHTML = `
                <div class="card h-100 shadow-sm border-0 rounded-lg overflow-hidden shadow-lg transform transition-transform hover:scale-105">
                    <img src="${cocktail.strDrinkThumb}" class="card-img-top" alt="${cocktail.strDrink}">
                    <div class="card-body bg-dark text-white">
                        <h5 class="card-title">${cocktail.strDrink}</h5>
                    </div>
                </div>
            `;
                if (container) {
                    container.appendChild(col);
                }
                loaded++;
            }
        }
        isLoading = false;
    });
}
document.addEventListener("DOMContentLoaded", () => {
    loadCocktails();
});
window.addEventListener("scroll", () => {
    if (window.innerHeight + window.scrollY >= document.body.offsetHeight - 300) {
        loadCocktails(5);
    }
});
