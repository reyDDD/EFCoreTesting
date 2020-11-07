window.onload = ()=>{
    //да нихуя оно не работает
 
}

async function getAddressTo() {
    let id = document.getElementById("numberAddr");
    let url = "https://localhost:44356/api/Api0711/ReturnDto/dto/22";
    var request = await fetch(url);
    let response = await request.json();

    var kuda = document.getElementById("insertgettingAddress");
    kuda.innerHTML = "<em>" + response.city + "</em>";
    alert(response.city);
}
