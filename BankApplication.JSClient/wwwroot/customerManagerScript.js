let customers = [];
let fetchAddress = 'http://localhost:10928/customer';
let connection = null;
let customerIdToUpdate = -1;

getData();
setupSignalR();

async function getData() {
    await fetch(fetchAddress)
        .then(x => x.json())
        .then(y => {
            customers = y;
            display();
        });
}

function display() {
    document.getElementById('customerTable').innerHTML = "";
    customers.forEach(t => {
        document.getElementById('customerTable').innerHTML +=
            "<tr>" +
                "<td>" + t.custId + "</td>" +
                "<td>" + t.custName + "</td>" +
                "<td>" + t.yearOfBirth + "</td>" +
                "<td>" + t.cust_XSell_score + "</td>" +
                "<td>" + t.averageIncome + "</td>" +
                "<td>" + t.country + "</td><td>" +
                `<button type="button" onclick="removeCustomer(${t.custId})">Delete</button>` +
                `<button type="button" onclick="showUpdateCustomerForm(${t.custId})">Update</button>` +
            "</td></tr>";
        
    })
}

function createCustomer() {
    let customerName = document.getElementById('custName').value;
    let customerYearOfBirth = document.getElementById('custYearOfBirth').value; 
    let customerxSellScore = document.getElementById('custXSell').value; 
    let customerAvgIncome = document.getElementById('custAvgIncome').value; 
    let customerCountry = document.getElementById('custCountry').value; 

    fetch(fetchAddress, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                custName: customerName,
                yearOfBirth: customerYearOfBirth,
                cust_XSell_score: customerxSellScore,
                averageIncome: customerAvgIncome,
                country: customerCountry
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

function showUpdateCustomerForm(id) {
    document.getElementById("custNameToUpdate").value = customers.find(x => x["custId"] == id)["custName"];
    document.getElementById("custYearOfBirthToUpdate").value = customers.find(x => x["custId"] == id)["yearOfBirth"];
    document.getElementById("custXSellToUpdate").value = customers.find(x => x["custId"] == id)["cust_XSell_score"];
    document.getElementById("custAvgIncomeToUpdate").value = customers.find(x => x["custId"] == id)["averageIncome"];
    document.getElementById("custCountryToUpdate").value = customers.find(x => x["custId"] == id)["country"];


    document.getElementById("customerUpdateDiv").style.display = 'flex';
    customerIdToUpdate = id;
}

function updateCustomer() {
    document.getElementById("customerUpdateDiv").style.display = 'none';
    let customerName = document.getElementById('custNameToUpdate').value;
    let customerYearOfBirth = document.getElementById('custYearOfBirthToUpdate').value;
    let customerxSellScore = document.getElementById('custXSellToUpdate').value;
    let customerAvgIncome = document.getElementById('custAvgIncomeToUpdate').value;
    let customerCountry = document.getElementById('custCountryToUpdate').value;

    fetch(fetchAddress, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                custId: customerIdToUpdate,
                custName: customerName,
                yearOfBirth: customerYearOfBirth,
                cust_XSell_score: customerxSellScore,
                averageIncome: customerAvgIncome,
                country: customerCountry
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

function removeCustomer(id) {
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

    connection.on("CustomerCreated", (user, message) => {
        getdata();
    });

    connection.on("CustomerDeleted", (user, message) => {
        getdata();
    });

    connection.on("CustomerUpdated", (user, message) => {
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

