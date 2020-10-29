

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
