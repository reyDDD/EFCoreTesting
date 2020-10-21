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