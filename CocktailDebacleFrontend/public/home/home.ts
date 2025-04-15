"use strict";

const container = document.getElementById("cocktail-grid");
const namesSeen = new Set();
let isLoading = false;

async function fetchRandomCocktail() {
    const response = await fetch("https://www.thecocktaildb.com/api/json/v1/1/random.php");
    const data = await response.json();
    return data.drinks[0];
}

async function loadCocktails(count = 10) {
    if (isLoading) return;
    isLoading = true;

    let loaded = 0;
    while (loaded < count) {
        const cocktail = await fetchRandomCocktail();
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
}

document.addEventListener("DOMContentLoaded", () => {
    loadCocktails();
});

window.addEventListener("scroll", () => {
    if (window.innerHeight + window.scrollY >= document.body.offsetHeight - 300) {
        loadCocktails(5);
    }
});
