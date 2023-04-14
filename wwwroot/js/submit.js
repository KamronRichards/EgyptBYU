$(document).ready(function () {
    $('#makeitgo').click(function (event) {
        event.preventDefault();
        submitForm();
    });
});

async function submitForm() {
    // Get the form data
    var form = $('#makeitgoform')[0];
    var formData = new FormData(form);

    // Convert the form data to JSON
    var jsonFormData = {};
    var easykeys = ['squarenorthsouth', 'squareeastwest', 'depth'];
    for (const key in easykeys) {
        var num = parseFloat(formData.get(easykeys[key]));
        if (!num) {
            num = 0
        }
        jsonFormData[easykeys[key]] = num;
    }



    var sex = formData.get("sex");
    if (sex === 'M') {
        jsonFormData["sex_F"] = 0;
        jsonFormData["sex_M"] = 1;
    } else if (sex === 'F') {
        jsonFormData["sex_F"] = 1;
        jsonFormData["sex_M"] = 0;
    } else {
        // Set default values in case of invalid input
        jsonFormData["sex_F"] = 0;
        jsonFormData["sex_M"] = 0;
    }


    var adultsubadult = formData.get("adultsubadult");

    if (adultsubadult === 'A') {
        jsonFormData["adultsubadult_A"] = 1;
        jsonFormData["adultsubadult_C"] = 0;
        jsonFormData["adultsubadult_NLL"] = 0;
    } else if (adultsubadult === 'C') {
        jsonFormData["adultsubadult_A"] = 0;
        jsonFormData["adultsubadult_C"] = 1;
        jsonFormData["adultsubadult_NLL"] = 0;
    } else if (adultsubadult === 'N LL') {
        jsonFormData["adultsubadult_A"] = 0;
        jsonFormData["adultsubadult_C"] = 0;
        jsonFormData["adultsubadult_NLL"] = 1;
    } else {
        // Set default values in case of invalid input
        jsonFormData["adultsubadult_A"] = 0;
        jsonFormData["adultsubadult_C"] = 0;
        jsonFormData["adultsubadult_NLL"] = 0;
    }

    var facebundles = formData.get("facebundles");

    if (facebundles === 'TR E') {
        jsonFormData["facebundles_TR_E"] = 1;
        jsonFormData["facebundles_Y"] = 0;
    } else if (facebundles === 'Y') {
        jsonFormData["facebundles_TR_E"] = 0;
        jsonFormData["facebundles_Y"] = 1;
    } else {
        // Set default values in case of invalid input
        jsonFormData["facebundles_TR_E"] = 0;
        jsonFormData["facebundles_Y"] = 0;
    }
    var haircolor = formData.get("haircolor");

    if (haircolor === 'A') {
        jsonFormData["haircolor_A"] = 1;
        jsonFormData["haircolor_B"] = 0;
        jsonFormData["haircolor_D"] = 0;
        jsonFormData["haircolor_K"] = 0;
        jsonFormData["haircolor_R"] = 0;
        jsonFormData["haircolor_T"] = 0;
        jsonFormData["haircolor_Y"] = 0;
    } else if (haircolor === 'B') {
        jsonFormData["haircolor_A"] = 0;
        jsonFormData["haircolor_B"] = 1;
        jsonFormData["haircolor_D"] = 0;
        jsonFormData["haircolor_K"] = 0;
        jsonFormData["haircolor_R"] = 0;
        jsonFormData["haircolor_T"] = 0;
        jsonFormData["haircolor_Y"] = 0;
    } else if (haircolor === 'D') {
        jsonFormData["haircolor_A"] = 0;
        jsonFormData["haircolor_B"] = 0;
        jsonFormData["haircolor_D"] = 1;
        jsonFormData["haircolor_K"] = 0;
        jsonFormData["haircolor_R"] = 0;
        jsonFormData["haircolor_T"] = 0;
        jsonFormData["haircolor_Y"] = 0;
    } else if (haircolor === 'K') {
        jsonFormData["haircolor_A"] = 0;
        jsonFormData["haircolor_B"] = 0;
        jsonFormData["haircolor_D"] = 0;
        jsonFormData["haircolor_K"] = 1;
        jsonFormData["haircolor_R"] = 0;
        jsonFormData["haircolor_T"] = 0;
        jsonFormData["haircolor_Y"] = 0;
    } else if (haircolor === 'R') {
        jsonFormData["haircolor_A"] = 0;
        jsonFormData["haircolor_B"] = 0;
        jsonFormData["haircolor_D"] = 0;
        jsonFormData["haircolor_K"] = 0;
        jsonFormData["haircolor_R"] = 1;
        jsonFormData["haircolor_T"] = 0;
        jsonFormData["haircolor_Y"] = 0;
    } else if (haircolor === 'T') {
        jsonFormData["haircolor_A"] = 0;
        jsonFormData["haircolor_B"] = 0;
        jsonFormData["haircolor_D"] = 0;
        jsonFormData["haircolor_K"] = 0;
        jsonFormData["haircolor_R"] = 0;
        jsonFormData["haircolor_T"] = 1;
        jsonFormData["haircolor_Y"] = 0;
    } else if (haircolor === 'Y') {
        jsonFormData["haircolor_A"] = 0;
        jsonFormData["haircolor_B"] = 0;
        jsonFormData["haircolor_D"] = 0;
        jsonFormData["haircolor_K"] = 0;
        jsonFormData["haircolor_R"] = 0;
        jsonFormData["haircolor_T"] = 0;
        jsonFormData["haircolor_Y"] = 1;
    } else {
        jsonFormData["haircolor_A"] = 0;
        jsonFormData["haircolor_B"] = 0;
        jsonFormData["haircolor_D"] = 0;
        jsonFormData["haircolor_K"] = 0;
        jsonFormData["haircolor_R"] = 0;
        jsonFormData["haircolor_T"] = 0;
        jsonFormData["haircolor_Y"] = 0;
    }

    var area = formData.get("area");
    if (area === 'NE') {
        jsonFormData["area_NE"] = 1;
        jsonFormData["area_NNW"] = 0;
        jsonFormData["area_NW"] = 0;
        jsonFormData["area_SE"] = 0;
        jsonFormData["area_SW"] = 0;
    } else if (area === 'NNW') {
        jsonFormData["area_NE"] = 0;
        jsonFormData["area_NNW"] = 1;
        jsonFormData["area_NW"] = 0;
        jsonFormData["area_SE"] = 0;
        jsonFormData["area_SW"] = 0;
    } else if (area === 'NW') {
        jsonFormData["area_NE"] = 0;
        jsonFormData["area_NNW"] = 0;
        jsonFormData["area_NW"] = 1;
        jsonFormData["area_SE"] = 0;
        jsonFormData["area_SW"] = 0;
    } else if (area === 'SE') {
        jsonFormData["area_NE"] = 0;
        jsonFormData["area_NNW"] = 0;
        jsonFormData["area_NW"] = 0;
        jsonFormData["area_SE"] = 1;
        jsonFormData["area_SW"] = 0;
    } else {
        jsonFormData["area_NE"] = 0;
        jsonFormData["area_NNW"] = 0;
        jsonFormData["area_NW"] = 0;
        jsonFormData["area_SE"] = 0;
        jsonFormData["area_SW"] = 0;
    }


    var ageatdeath = formData.get("ageatdeath");

    if (ageatdeath === 'A') {
        jsonFormData["ageatdeath_A"] = 1;
        jsonFormData["ageatdeath_C"] = 0;
        jsonFormData["ageatdeath_I"] = 0;
        jsonFormData["ageatdeath_IN"] = 0;
        jsonFormData["ageatdeath_In"] = 0;
        jsonFormData["ageatdeath_N"] = 0;
    } else if (ageatdeath === 'C') {
        jsonFormData["ageatdeath_A"] = 0;
        jsonFormData["ageatdeath_C"] = 1;
        jsonFormData["ageatdeath_I"] = 0;
        jsonFormData["ageatdeath_IN"] = 0;
        jsonFormData["ageatdeath_In"] = 0;
        jsonFormData["ageatdeath_N"] = 0;
    } else if (ageatdeath === 'I') {
        jsonFormData["ageatdeath_A"] = 0;
        jsonFormData["ageatdeath_C"] = 0;
        jsonFormData["ageatdeath_I"] = 1;
        jsonFormData["ageatdeath_IN"] = 0;
        jsonFormData["ageatdeath_In"] = 0;
        jsonFormData["ageatdeath_N"] = 0;
    } else if (ageatdeath === 'IN') {
        jsonFormData["ageatdeath_A"] = 0;
        jsonFormData["ageatdeath_C"] = 0;
        jsonFormData["ageatdeath_I"] = 0;
        jsonFormData["ageatdeath_IN"] = 1;
        jsonFormData["ageatdeath_In"] = 0;
        jsonFormData["ageatdeath_N"] = 0;
    } else if (ageatdeath === 'In') {
        jsonFormData["ageatdeath_A"] = 0;
        jsonFormData["ageatdeath_C"] = 0;
        jsonFormData["ageatdeath_I"] = 0;
        jsonFormData["ageatdeath_IN"] = 0;
        jsonFormData["ageatdeath_In"] = 1;
        jsonFormData["ageatdeath_N"] = 0;
    } else if (ageatdeath === 'N') {
        jsonFormData["ageatdeath_A"] = 0;
        jsonFormData["ageatdeath_C"] = 0;
        jsonFormData["ageatdeath_I"] = 0;
        jsonFormData["ageatdeath_IN"] = 0;
        jsonFormData["ageatdeath_In"] = 0;
        jsonFormData["ageatdeath_N"] = 1;
    } else {
        jsonFormData["ageatdeath_A"] = 0;
        jsonFormData["ageatdeath_C"] = 0;
        jsonFormData["ageatdeath_I"] = 0;
        jsonFormData["ageatdeath_IN"] = 0;
        jsonFormData["ageatdeath_In"] = 0;
        jsonFormData["ageatdeath_N"] = 0;
    }



    fetch('/prediction', {
        method: 'POST',
    headers:
    {
        'Content-Type': 'application/json',
    },
    body: JSON.stringify(jsonFormData)
    })
    .then(response => {
        if (response.ok) {
            // Handle successful response
            return response.json(); // Extract the response data as JSON
         }
        else {
            // Handle error response
            console.error('Error submitting data');
             }
        })
        .then(data => {
            // Update the DOM with the returned value
            document.getElementById('resultContainer').innerHTML = data['predictedValue'];
        })
        .catch(error => {
            // Handle fetch error
            console.error('Error fetching data:', error);
        });
}
