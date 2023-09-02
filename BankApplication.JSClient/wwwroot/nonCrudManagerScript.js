let fetchResult = [];
let fetchAdressBase = 'http://localhost:10928';


async function getData(fetchAddress, reportType) {
    await fetch(fetchAddress)
        .then(x => x.json())
        .then(y => {
            fetchResult = y;
            console.log(y);
            display(reportType);
        });
}

function display(reportType) {
    if (reportType == "customersByCountry") {
        
        document.getElementById('nonCrudTable').innerHTML = "";
        document.getElementById('nonCrudTable').innerHTML +=
            "<thead><tr>" +
                "<th>" + "Country Name" + "</th>" +
                "<th>" + "Customer Count" + "</th>" +
                "<th>" + "Average Balance" + "</th>" +
            "</tr></thead><tbody>";
        fetchResult.forEach(t => {
            document.getElementById('nonCrudTable').innerHTML +=
                "<tr>" +
                    "<td>" + t.countryName + "</td>" +
                    "<td>" + t.customerCount + "</td>" +
                    "<td>" + t.avgBalance + "</td>" +
                "</tr>";

        })
        document.getElementById('nonCrudTable').innerHTML += "</tbody>";
    }
    else if (reportType == "cardsByCurrency") {
        document.getElementById('nonCrudTable').innerHTML = "";
        document.getElementById('nonCrudTable').innerHTML +=
            "<thead><tr>" +
                "<th>" + "Country Name" + "</th>" +
                "<th>" + "Customer Count" + "</th>" +
                "<th>" + "Average Balance" + "</th>" +
            "</tr></thead><tbody>";
        fetchResult.forEach(t => {
            document.getElementById('nonCrudTable').innerHTML +=
                "<tr>" +
                    "<td>" + t.accountCurrencyType + "</td>" +
                    "<td>" + t.cardType + "</td>" +
                    "<td>" + t.cardCnt + "</td>" +
                "</tr>";

        })
        document.getElementById('nonCrudTable').innerHTML += "</tbody>";
    }
    else if (reportType == "customersByBalance") {
        document.getElementById('nonCrudTable').innerHTML = "";
        document.getElementById('nonCrudTable').innerHTML +=
            "<thead><tr>" +
                "<th>" + "Customer Name" + "</th>" +
                "<th>" + "Average Income" + "</th>" +
                "<th>" + "Country" + "</th>" +
            "</tr></thead><tbody>";
        fetchResult.forEach(t => {
            document.getElementById('nonCrudTable').innerHTML +=
                "<tr>" +
                    "<td>" + t.custName + "</td>" +
                    "<td>" + t.averageIncome + "</td>" +
                    "<td>" + t.country + "</td>" +
                "</td></tr>";

        })
        document.getElementById('nonCrudTable').innerHTML += "</tbody>";
    }
    else if (reportType == "cardsByCountry") {
        document.getElementById('nonCrudTable').innerHTML = "";
        document.getElementById('nonCrudTable').innerHTML +=
            "<thead><tr>" +
                "<th>" + "Country Name" + "</th>" +
                "<th>" + "Card Count" + "</th>" +
            "</tr></thead><tbody>";
        fetchResult.forEach(t => {
            document.getElementById('nonCrudTable').innerHTML +=
                "<tr>" +
                    "<td>" + t.countryName + "</td>" +
                    "<td>" + t.allCardAmount + "</td>" +
                "</tr>";
        })
        document.getElementById('nonCrudTable').innerHTML += "</tbody>";
    }
    else if (reportType == "customersByCardCount") {
        document.getElementById('nonCrudTable').innerHTML = "";
        document.getElementById('nonCrudTable').innerHTML +=
            "<thead><tr>" +
                "<th>" + "Customer Name" + "</th>" +
                "<th>" + "Average Income" + "</th>" +
                "<th>" + "Country" + "</th>" +
            "</tr></thead><tbody>";
        fetchResult.forEach(t => {
            document.getElementById('nonCrudTable').innerHTML +=
                "<tr>" +
                    "<td>" + t.custName + "</td>" +
                    "<td>" + t.averageIncome + "</td>" +
                    "<td>" + t.country + "</td>" +
                "</tr>";

        })
        document.getElementById('nonCrudTable').innerHTML += "</tbody>";
    }
} 

function getReportType(reportType) {
    if (reportType == "customersByCountry") {
        getData(fetchAdressBase + '/NonCrud/AggregateCustomersByCountry', reportType);
    }
    else if (reportType == "cardsByCurrency") {
        getData(fetchAdressBase + '/NonCrud/AggregateCardByCurrency', reportType);
    }
    else if (reportType == "customersByBalance") {
        let defaultValue = 1000;
        let manualValue = document.getElementById('minimumBalance').value;
        if (manualValue > 0) {
            getData(fetchAdressBase + '/NonCrud/GetCustomersByMinBalance?min=' + manualValue, reportType);
        }
        else { getData(fetchAdressBase + '/NonCrud/GetCustomersByMinBalance?min=' + defaultValue, reportType); }
    }
    else if (reportType == "cardsByCountry") {
        let defaultValue = document.getElementById('cardTypeSelect').value;
        getData(fetchAdressBase + '/NonCrud/AggregateCardsByCountry?cardType=' + defaultValue, reportType);
    } 
    else if (reportType == "customersByCardCount") {
        let manualValue = document.getElementById('minimumCardAmount').value;
        getData(fetchAdressBase + '/NonCrud/GetCustomersByCardCount?cardCnt=' + manualValue, reportType);
    }
}


