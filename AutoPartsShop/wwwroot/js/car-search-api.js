const apiBaseUrl = "https://localhost:7205/api/Car"; 



function fetchMakes() {
    $.getJSON(apiBaseUrl + "/Get-makes", function (data) {
        const makes = data.Makes;
        const makesDropdown = document.getElementById("makes");

        makes.forEach(make => {
            const option = document.createElement("option");
            option.value = make.make_id;
            option.textContent = make.make_display;
            makesDropdown.appendChild(option);
        });
    }).fail(function (error) {
        console.error("Error fetching makes:", error);
    });
}



function getModels() {
    const selectedMake = document.getElementById("makes").value;

    if (!selectedMake) {
        alert("Please select a make first!");
        return;
    }

    $.getJSON(apiBaseUrl + `/get-models/${selectedMake}`, function (data) {
        const models = data.Models;
        const modelsDropdown = document.getElementById("models");

        modelsDropdown.innerHTML = '<option value="" selected disabled>Select Model</option>';

        models.forEach(model => {
            const option = document.createElement("option");
            option.value = model.model_name;
            option.textContent = model.model_name;
            modelsDropdown.appendChild(option);
        });
    }).fail(function (error) {
        console.error("Error fetching models:", error);
    });
}



function getYears() {
    const selectedMake = document.getElementById("makes").value;
    const selectedModel = document.getElementById("models").value;

    if (!selectedMake || !selectedModel) {
        alert("Please select both make and model first!");
        return;
    }

    $.getJSON(apiBaseUrl + `/get-years?make=${selectedMake}&model=${selectedModel}`, function (data) {
        const years = data.Years;
        const yearsDropdown = document.getElementById("years");

        yearsDropdown.innerHTML = '<option value="" selected disabled>Select Year</option>';

        if (years) {
            const minYear = parseInt(years.min_year);
            const maxYear = parseInt(years.max_year);

            for (let year = maxYear; year >= minYear; year--) {
                const option = document.createElement("option");
                option.value = year;
                option.textContent = year;
                yearsDropdown.appendChild(option);
            }
        } else {
            alert("No years found for this model.");
        }
    }).fail(function (error) {
        console.error("Error fetching years:", error);
    });
}



function getTrims() {
    const selectedMake = document.getElementById("makes").value;
    const selectedModel = document.getElementById("models").value;
    const selectedYear = document.getElementById("years").value;

    if (!selectedMake || !selectedModel || !selectedYear) {
        alert("Please select make, model, and year first!");
        return;
    }

    $.getJSON(apiBaseUrl + `/get-engine-sizes?make=${selectedMake}&model=${selectedModel}&year=${selectedYear}`, function (data) {
        const trims = data.Trims;
        const trimsDropdown = document.getElementById("trims");

        trimsDropdown.innerHTML = '<option value="" selected disabled>Select Engine/Trim</option>';

        trims.forEach(trim => {
            const option = document.createElement("option");
            option.value = trim.model_id;
            option.textContent = `${trim.model_trim || "Standard"}`;
            trimsDropdown.appendChild(option);
        });
    }).fail(function (error) {
        console.error("Error fetching trims:", error);
    });
}



function searchCar() {
    const selectedTrimId = document.getElementById("trims").value;

    if (!selectedTrimId) {
        alert("Please select a trim to search!");
        return;
    }

    $.getJSON(apiBaseUrl + `/get-model?model=${selectedTrimId}`, function (data) {
        const details = data[0];
        const carDetailsDiv = document.getElementById("carDetails");

        if (!details) {
            carDetailsDiv.innerHTML = "<p>No details found for the selected trim.</p>";
            return;
        }

        carDetailsDiv.innerHTML = `
            <h5>Details for ${details.make_display} ${details.model_name}</h5>
            <ul>
                <li><strong>Top Speed:</strong> ${details.model_top_speed_kph || "N/A"} km/h</li>
                <li><strong>Weight:</strong> ${details.model_weight_kg || "N/A"} kg</li>
                <li><strong>Acceleration (0-100 km/h):</strong> ${details.model_0_to_100_kph || "N/A"} s</li>
                <li><strong>Oil Capacity:</strong> ${details.oil_capacity || "N/A"} liters</li>
                <li><strong>Fuel Consumption:</strong> ${details.model_fuel_cons || "N/A"}</li>
            </ul>
        `;
    }).fail(function (error) {
        console.error("Error fetching car details:", error);
    });
}


document.addEventListener("DOMContentLoaded", fetchMakes);
