function initPage() {
    const brandField = document.getElementById("brand");
    const categoryField = document.getElementById("category");
    const url = [window.location.origin, "/Product/", "All", "/", "All"];

    brandField.onchange = () => {
        url[2] = brandField.value;
        setupProducts(url.join(""));
    }

    categoryField.onchange = () => {
        url[4] = categoryField.value;
        setupProducts(url.join(""));
    }
}

function setupProducts(url) {
    if (url !== "https://localhost:44368/Product/All/All") {
        window.fetch(url)
            .then((response) => { return response.text(); })
            .then((result) => {
                const productContent = document.getElementById("products");
                productContent.innerHTML = result;
            });
    }
    else {
        window.location.href = "Product";
    }
}

initPage();