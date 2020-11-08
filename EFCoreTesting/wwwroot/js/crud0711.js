window.onload = function () {
    id = document.getElementById("numberAddr");
    ids = document.getElementById("numberAddr");
    kuda = document.getElementById("insertgettingAddress");
    cityAddr = document.getElementById("cityAddr");
    countryAddr = document.getElementById("countryAddr");
}
var id, kuda, cityAddr, countryAddr, ids;



async function getAddressTo() {
    let url = "https://localhost:44356/api/Api0711/ReturnDto/dto/" + parseInt(id.value);
    var request = await fetch(url);
    let response = await request.json();

    kuda.innerHTML = "<em>" + response.city + "</em>";
    //alert(response.city);
}

async function addAddress() {
    let url = "https://localhost:44356/api/Api0711/AddAddress/xx/";
    var addr = {
        city: cityAddr.value,
        country: countryAddr.value
    }

    var reques = await fetch(url, {
        method: "POST",
        body: JSON.stringify(addr),
        headers: {
            "Content-Type": "application/json",
            "Accept": "application/json"
        }
    });

    var dat = await reques.json();
    var response = await reques.status;
    kuda.innerHTML = "<em>response status is: " + response + ' ' + dat.city + "</em>";
}

async function updateAddress() {
    let url = "https://localhost:44356/api/Api0711/UpdateAddress";
    var body = {
        id: parseInt(ids.value),
        city: cityAddr.value,
        country: countryAddr.value
    };

    var request = await fetch(`${url}/${id.value}`, {
        method: "PUT",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
        body: JSON.stringify(body)
    });

    var response = await request.status;
    kuda.innerHTML = "<em>response status is: " + response + "</em>";
}