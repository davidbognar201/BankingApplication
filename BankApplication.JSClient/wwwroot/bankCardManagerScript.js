let bankCards = [];
let fetchAddress = 'http://localhost:10928/bankcard';
let connection = null;
let cardIdToUpdate = -1;

getData();
setupSignalR();

async function getData() {
    await fetch(fetchAddress)
        .then(x => x.json())
        .then(y => {
            bankCards = y;
            console.log(bankCards);
            display();
        });
}

function display() {

    document.getElementById('bankCardTable').innerHTML = "";

    bankCards.forEach(t => {
        document.getElementById('bankCardTable').innerHTML +=
            "<tr>" +
                "<td>" + t.cardId + "</td>" +
                "<td>" + t.cardNumber + "</td>" +
                "<td>" + t.type + "</td>" +
                "<td>" + t.cvcCode + "</td><td>" +
                `<button type="button" onclick="removeCard(${t.cardId})">Delete</button>` +
                `<button type="button" onclick="showUpdateCardForm(${t.cardId})">Update</button>` +
            "</td></tr>";
    })
}

function createBankCard() {
    let cardNumber = document.getElementById('cardNum').value;
    let cardType = document.getElementById('cardType').value; 
    let cardCVC = document.getElementById('cardCvc').value; 

    fetch(fetchAddress, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                cardNumber: cardNumber,
                type: cardType,
                cvcCode: cardCVC
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getData();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

function showUpdateCardForm(id) {
    document.getElementById("cardNumToUpdate").value = bankCards.find(x => x["cardId"] == id)["cardNumber"];
    document.getElementById("cardTypeToUpdate").value = bankCards.find(x => x["cardId"] == id)["type"];
    document.getElementById("cardCvcToUpdate").value = bankCards.find(x => x["cardId"] == id)["cvcCode"];

    document.getElementById("bankCardUpdateDiv").style.display = 'flex';
    cardIdToUpdate = id;
}

function updateBankCard() {
    document.getElementById("bankCardUpdateDiv").style.display = 'none';

    let cardNumber = document.getElementById('cardNumToUpdate').value;
    let cardType = document.getElementById('cardTypeToUpdate').value;
    let cardCVC = document.getElementById('cardCvcToUpdate').value;

    fetch(fetchAddress, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                cardId: cardIdToUpdate,
                cardNumber: cardNumber,
                type: cardType,
                cvcCode: cardCVC
                
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getData();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

function removeCard(id) {
    fetch(fetchAddress + '/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl(fetchAddress + "/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("BankCardCreated", (user, message) => {
        getdata();
    });

    connection.on("BankCardDeleted", (user, message) => {
        getdata();
    });

    connection.on("BankCardUpdated", (user, message) => {
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
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

