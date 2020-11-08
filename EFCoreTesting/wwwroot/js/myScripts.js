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
const uri = 'https://localhost:44356/api/ApiWork1910';

function addCity() {

    const inputTextBoxCity = document.getElementById('add-city');
    const inputTextBoxCountry = document.getElementById('add-country');

    const address = {
        country: inputTextBoxCountry.value,
        city: inputTextBoxCity.value
    };


    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(address)
    })
        .then(response => response.json())
        .then(datas => {


            inputTextBoxCountry.value = '',
                inputTextBoxCity.value = '',
                console.log(datas.Id, datas.Country, datas.City)
        })
        .catch(error => console.error('не получилось добавить адрес', error));
}

async function getAddress() {

    let forInsert = document.getElementById('setAddress');
    let uris = 'https://localhost:44356/api/ApiWork1910/';
    let id = document.getElementById('get-id-address');


    let response = await fetch(uris + id.value);

    console.log('статус ответа: ' + response.status);
    if (response.status === 404) {
        forInsert.innerText = 'запись с таким id не найдена';
    }
    else {
        let result = await response.json();
        forInsert.innerText = result.id + ' ' + result.country + ' ' + result.city;
        document.getElementById('add-id').value = result.id;
        document.getElementById('add-city').value = result.city;
        document.getElementById('add-country').value = result.country;
    }
}


async function updateCity() {
    let id = document.getElementById('add-id').value;
    var city = document.getElementById('add-city');
    let country = document.getElementById('add-country');

    let bodys = {
        id: Number(id),
        city: city.value,
        country: country.value
    }
    let response = await fetch(`${uri}/${id}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(bodys)
    });

    //let result = await response.status;
    //console.log(result + ' - статус ответа');
}


async function getUser() {
    let url = "https://localhost:44356/api/Api2810/getuser/";
    let id = document.getElementById("getUserForId").value;
    let response = await fetch(url + id);

    var result = await response.json();
    vstavkaDannich(result);
};

async function addUser() {
    let url = "https://localhost:44356/api/Api2810/";
    var first = document.getElementById("adUserForId-FirstName");
    var last = document.getElementById("adUserForId-LastName");
    var idA = document.getElementById("adUserForId-NumAddress");
    var datas = {
        firstName: first.value,
        lastName: last.value,
       // age: Number(document.getElementById("adUserForId-Age").value),
        addressId: Number(idA.value)
    };

    console.log("yyyy");

    try {
    var response = await fetch(url, {
        method: "POST",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
        withCredentials: true,
        body: JSON.stringify(datas)
    });
 

        var result = await response.status;
        console.log(result);
    } catch (e) {
        console.log(e);
    }
};

function updateUser() {
    let url = "https://localhost:44356/api/Api2810/one/";

};


function deletetUserForId() {
    let url = "https://localhost:44356/api/Api2810/";

};

function vstavkaDannich(data) {
    document.getElementById("updateUserForId-Id").value = data.id;
    document.getElementById("updateUserForId-FirstName").value = data.firstName;
    document.getElementById("updateUserForId-LastName").value = data.lastName;
    document.getElementById("updateUserForId-Age").value = data.age;
    document.getElementById("updateUserForId-NumAddress").value = data.addressId;
}