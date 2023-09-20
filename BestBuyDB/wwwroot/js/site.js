// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener('DOMContentLoaded', () => {
filterForm.addEventListener('submit', async (event) => {
    event.preventDefault();

    const CategoryID = document.getElementById('CategoryID').value;
    const response = await fetch(`/Product/CategoryProducts/?CategoryID=${CategoryID}`);
    const products = await response.json();

    productsDiv.innerHTML = `
    <h1>Products ${CategoryID} </h1>
    <ul>
        ${products.map(Product => `<li>${Product}</li>`).join('')}
    </ul>`;

});

})
