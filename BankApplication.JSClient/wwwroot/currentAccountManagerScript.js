let currentAccounts = [];
let fetchAddress = 'http://localhost:10928/currentaccount';
let connection = null;
let accountIdToUpdate = -1;

getData();
setupSignalR();

async function getData() {
    await fetch(fetchAddress)
        .then(x => x.json())
        .then(y => {
            currentAccounts = y;
            console.log(y);
            display();
        });
}

function display() {
    document.getElementById('currentAccountTable').innerHTML = "";
    currentAccounts.forEach(t => {
        document.getElementById('currentAccountTable').innerHTML +=
            "<tr>" +
                "<td>" + t.accountId + "</td>" +
                "<td>" + t.accountNumber + "</td>" +
                "<td>" + t.accountBalance + "</td>" +
                "<td>" + t.accountCurrency + "</td><td>" +
                `<button type="button" onclick="removeAccount(${t.accountId})">Delete</button>` +
                `<button type="button" onclick="showUpdateAccountForm(${t.accountId})">Update</button>` +
            "</td></tr>";
        
    })
}

function createCurrentAccount() {
    let accountNum = document.getElementById('accountNum').value;
    let accountBal = document.getElementById('accountBal').value; 
    let accountCurr = document.getElementById('accountCurr').value; 
    
    fetch(fetchAddress, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                accountNumber: accountNum,
                accountBalance: accountBal,
                accountCurrency: accountCurr
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getData();
        })
        .catch((error) => {
            console.error('Error:', error);
            alert(error);
        });
}

function showUpdateAccountForm(id) {
    document.getElementById("accountNumToUpdate").value = currentAccounts.find(x => x["accountId"] == id)["accountNumber"];
    document.getElementById("accountBalToUpdate").value = currentAccounts.find(x => x["accountId"] == id)["accountBalance"];
    document.getElementById("accountCurrToUpdate").value = currentAccounts.find(x => x["accountId"] == id)["accountCurrency"];

    document.getElementById("currentAccountUpdateDiv").style.display = 'flex';
    accountIdToUpdate = id;
}

function updateAccount() {

    document.getElementById("currentAccountUpdateDiv").style.display = 'none';
    let accountNum = document.getElementById('accountNumToUpdate').value;
    let accountBal = document.getElementById('accountBalToUpdate').value;
    let accountCurr = document.getElementById('accountCurrToUpdate').value;

    fetch(fetchAddress, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                accountId: accountIdToUpdate,
                accountNumber: accountNum,
                accountBalance: accountBal,
                accountCurrency: accountCurr
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

function removeAccount(id) {
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

    connection.on("CurrentAccountCreated", (user, message) => {
        getdata();
    });

    connection.on("CurrentAccountDeleted", (user, message) => {
        getdata();
    });

    connection.on("CurrentAccountUpdated", (user, message) => {
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

