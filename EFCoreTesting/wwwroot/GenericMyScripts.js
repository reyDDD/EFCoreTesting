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
};

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
};


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