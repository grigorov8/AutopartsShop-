document.getElementById('show-parts-btn').addEventListener('click', function () {
    var partsDiv = document.getElementById('car-parts');
    if (partsDiv.style.display === 'none') {
        partsDiv.style.display = 'block';
        this.textContent = 'Скрий всички части за тази кола';
    } else {
        partsDiv.style.display = 'none';
        this.textContent = 'Покажи всички части за тази кола';
    }
});
