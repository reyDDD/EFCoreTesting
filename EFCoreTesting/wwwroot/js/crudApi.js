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
            console.log(datas.Id , datas.Country , datas.City)
        })
        .catch(error => console.error('не получилось добавить адрес', error));
}

async function getAddress() {

    let forInsert = document.getElementById('setAddress');
    let uris = 'https://localhost:44356/api/ApiWork1910/';
    let id = document.getElementById('get-id-address');
    //fetch(uris + id.value)
    //    .then(status => console.log('статус ответа: ' + status.status))
    //    .then(response => response.json())
    //    .then(data => forInsert.innerText = data.id + ' ' + data.country + ' ' + data.city)
    //    .catch(error => console.error('ошибка получения записи из таблицы', error));


    let response = await fetch(uris + id.value);

    console.log('статус ответа: ' + response.status);

    let result = await response.json();

    forInsert.innerText = result.id + ' ' + result.country + ' ' + result.city;
}