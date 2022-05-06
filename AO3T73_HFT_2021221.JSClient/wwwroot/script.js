let shops = [];
let shopNameToUpdate = "";
let connection = null;

getdata();
setupSignalR();

async function getdata() {
    await fetch('http://localhost:54068/aruhaz')
        .then(x => x.json())
        .then(y => {
            shops = y;
            display();
        });
}

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:54068/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("AruhazCreated", (user, message) => {
        getdata();
    });

    connection.on("AruhazDeleted", (user, message) => {
        getdata();
    });

    connection.on("AruhazUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR kapcsolódása sikeres");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

function display() {
    document.getElementById('results').innerHTML = "";
    shops.forEach(shop => {
        document.getElementById('results').innerHTML +=
            "<tr><td>" + shop.aruhazNeve + "</td><td>" + shop.eMail + "</td><td>" + shop.honlap + "</td><td>" + shop.kozpont + "</td><td>" + shop.telefon + "</td><td>" + shop.adoszam + "</td><td>" +
        `<button type="button" onclick="remove('${shop.aruhazNeve}')">Törlés</button>` +
        `<button type="button" onclick="showupdate('${shop.aruhazNeve}')">Módosítás</button>` + "</td></tr>";
        console.log(shop);
    });
}

function remove(id) {
    fetch('http://localhost:54068/aruhaz/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Sikeres:', data);
            getdata();
        })
        .catch((error) => { console.error('Hiba:', error); });
}

function showupdate(shopName) {
    document.getElementById('shopEmailUpdate').value = shops.find(t => t['aruhazNeve'] == shopName)['eMail'];
    document.getElementById('shopPageUpdate').value = shops.find(t => t['aruhazNeve'] == shopName)['honlap'];
    document.getElementById('shopCenterUpdate').value = shops.find(t => t['aruhazNeve'] == shopName)['kozpont'];
    document.getElementById('shopNumberUpdate').value = shops.find(t => t['aruhazNeve'] == shopName)['telefon'];
    document.getElementById('shopTaxUpdate').value = shops.find(t => t['aruhazNeve'] == shopName)['adoszam'];
    document.getElementById('updateformdiv').style.display = 'flex';
    shopNameToUpdate = shopName;
}

function updateShop() {
    document.getElementById('updateformdiv').style.display = 'none';
    let email = document.getElementById('shopEmailUpdate').value;
    let page = document.getElementById('shopPageUpdate').value;
    let center = document.getElementById('shopCenterUpdate').value;
    let number = document.getElementById('shopNumberUpdate').value;
    let tax = document.getElementById('shopTaxUpdate').value;

    fetch('http://localhost:54068/aruhaz', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                AruhazNeve: name,
                Honlap: page,
                EMail: email,
                Telefon: number,
                Kozpont: center,
                Adoszam: tax
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Sikeres:', data);
            getdata();
        })
        .catch((error) => { console.error('Hiba:', error); });
}

function createShop() {
    let name = document.getElementById('shopname').value;
    let email = document.getElementById('shopemail').value;
    let page = document.getElementById('shoppage').value;
    let center = document.getElementById('shopcenter').value;
    let number = document.getElementById('shopnumber').value;
    let tax = document.getElementById('shoptax').value;
    fetch('http://localhost:54068/aruhaz', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                AruhazNeve: name,
                Honlap: page,
                EMail: email,
                Telefon: number,
                Kozpont: center,
                Adoszam: tax
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Sikeres:', data);
            getdata();
        })
        .catch((error) => { console.error('Hiba:', error); });
}