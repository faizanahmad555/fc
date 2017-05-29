var dateFormat = '%d-%m-%Y';
var tooltipDateFormat = '%d-%m-%Y';
dateFormat = '%b %y';

function parseDate(jsonDate) {
    var re = /-?\d+/;
    var m = re.exec(jsonDate);
    var d = new Date(parseInt(m[0]));
    return d;
}

Highcharts.setOptions({
    colors: [
        'rgba( 0,   204, 205, 1 )', //bright blue
        'rgba( 255, 101,  1,   1 )', //bright orange
        'rgba( 40,  40,  56,  0.9 )', //dark
        'rgba( 253, 0,   154, 0.9 )', //bright pink
        'rgba( 154, 253, 0,   0.9 )', //bright green
        'rgba( 145, 44,  138, 0.9 )', //mid purple
        'rgba( 45,  47,  238, 0.9 )', //mid blue
        'rgba( 177, 69,  0,   0.9 )', //dark orange
        'rgba( 140, 140, 156, 0.9 )', //mid
        'rgba( 238, 46,  47,  0.9 )', //mid red
        'rgba( 44,  145, 51,  0.9 )', //mid green
        'rgba( 103, 16,  192, 0.9 )'  //dark purple
    ],
    lang: {

    }

});


function CreateOrderChart(OrderData, title) {
    var seriesData = [];

    var itemData = [];
    $.each(OrderData, function (idx, item) {

        var theDt = parseDate(item.CreatedOn);
        itemData.push(new Array(Date.UTC(theDt.getFullYear(), theDt.getMonth(), theDt.getDate(), theDt.getHours(), theDt.getMinutes(), theDt.getSeconds()), item.Count));
    });

    seriesData.push({ "name": "New Orders", "data": itemData });

    if (title == null || title == undefined)
        title = 'New Orders';
    CreateChart('ChartNewOrdersContainer', title, '', seriesData, null, 1, '(Orders)', null);
}


function CreateNewProductsChart(NewUsersData, title) {
  
    var seriesData = [];

    var itemData = [];
    $.each(NewUsersData, function (idx, item) {

        var theDt = parseDate(item.CreatedOn);
        itemData.push(new Array(Date.UTC(theDt.getFullYear(), theDt.getMonth(), theDt.getDate(), theDt.getHours(), theDt.getMinutes(), theDt.getSeconds()), item.Count));
    });

    seriesData.push({ "name": "New Products", "data": itemData });

    if (title == null || title == undefined)
        title = 'New Products';
    CreateChart('ChartNewProductsContainer', title, '', seriesData, null, 1, '(Products)', null);
}


function CreateNewSuppliersChart(NewUsersData, title) {

    var seriesData = [];

    var itemData = [];
    $.each(NewUsersData, function (idx, item) {

        var theDt = parseDate(item.CreatedOn);
        itemData.push(new Array(Date.UTC(theDt.getFullYear(), theDt.getMonth(), theDt.getDate(), theDt.getHours(), theDt.getMinutes(), theDt.getSeconds()), item.Count));
    });

    seriesData.push({ "name": "New Suppliers", "data": itemData });

    if (title == null || title == undefined)
        title = 'New Suppliers';
    CreateChart('ChartNewSuppliersContainer', title, '', seriesData, null, 1, '(Suppliers)', null);
}


function CreateNewCustomersChart(NewUsersData, title) {

    var seriesData = [];

    var itemData = [];
    $.each(NewUsersData, function (idx, item) {

        var theDt = parseDate(item.CreatedOn);
        itemData.push(new Array(Date.UTC(theDt.getFullYear(), theDt.getMonth(), theDt.getDate(), theDt.getHours(), theDt.getMinutes(), theDt.getSeconds()), item.Count));
    });

    seriesData.push({ "name": "New Customers", "data": itemData });

    if (title == null || title == undefined)
        title = 'New Customers';
    CreateChart('ChartNewCustomersContainer', title, '', seriesData, null, 1, '(Customers)', null);
}






function CreateNewProductChartSs(NewUsersData, title) {

    var seriesData = [];

    var itemData = [];
    $.each(NewUsersData, function (idx, item) {

        var theDt = parseDate(item.CreatedOn);
        itemData.push(new Array(Date.UTC(theDt.getFullYear(), theDt.getMonth(), theDt.getDate(), theDt.getHours(), theDt.getMinutes(), theDt.getSeconds()), item.Count));
    });

    seriesData.push({ "name": "New Products", "data": itemData });

    if (title == null || title == undefined)
        title = 'New Products';
    CreateChart('ChartNewProductsContainerSs', title, '', seriesData, null, 1, '(Products)', null);
}


function CreateNewOrderChart(OrderData, title) {
    var seriesData = [];

    var itemData = [];
    $.each(OrderData, function (idx, item) {

        var theDt = parseDate(item.CreatedOn);
        itemData.push(new Array(Date.UTC(theDt.getFullYear(), theDt.getMonth(), theDt.getDate(), theDt.getHours(), theDt.getMinutes(), theDt.getSeconds()), item.Count));
    });

    seriesData.push({ "name": "New Orders", "data": itemData });

    if (title == null || title == undefined)
        title = 'New Orders';
    CreateChart('ChartNewOrdersContainerSs', title, '', seriesData, null, 1, '(Orders)', null);
}









function CreateNewUsersChart(NewUsersData, title) {

    var seriesData = [];

    var itemData = [];
    $.each(NewUsersData, function (idx, item) {

        var theDt = parseDate(item.CreatedOn);
        itemData.push(new Array(Date.UTC(theDt.getFullYear(), theDt.getMonth(), theDt.getDate(), theDt.getHours(), theDt.getMinutes(), theDt.getSeconds()), item.Count));
    });

    seriesData.push({ "name": "New Users", "data": itemData });

    if (title == null || title == undefined)
        title = 'New Users';
    CreateChart('ChartNewUsersContainer', title, '', seriesData, null, 1, '(Users)', null);
}



function CreateChart(holder, title, yAxisText, seriesData, categoriesData, rangeSelected, unit, decimalpointUpto) {
    $('#' + holder).highcharts('StockChart', {

        chart: {
            type: '',
            backgroundColor: '#edf6fb'
        },
        rangeSelector: {
            selected: rangeSelected
        },

        yAxis: {
            opposite: false,
            lineWidth: 1,
            allowDecimals: false
            //labels: {
            //    formatter: function () {
            //        return (this.value > 0 ? ' + ' : '') + this.value + '%';
            //    }
            //},
            //plotLines: [{
            //    value: 0,
            //    width: 2,
            //    color: 'silver'
            //}]
        },

        //plotOptions: {
        //    series: {
        //        compare: 'percent'
        //    }
        //},
        rangeSelector: {
            enabled: true
        },
        scrollbar: {
            enabled: false
        },
        legend: {
            enabled: true//,

        },
        tooltip: {
            pointFormat: '<span style="color:{series.color}">{series.name}</span>: <b>{point.y} ' + unit + '</b><br/>',// ({point.change}%)
            valueDecimals: decimalpointUpto
        },
        navigator: {
            enabled: true
        },
        series: seriesData
    }, function (chart) {

        // apply the date pickers
        setTimeout(function () {
            //$('input.highcharts-range-selector', $(chart.container).parent())
            //    .datepicker({
            //        format: 'yy-mm-dd',
            //        autoclose: true,
            //        todayHighlight: true
            //    });
        }, 0);
    });
    // Set the datepicker's date format
//    $.datepicker({
//    format: 'dd-mm-yyyy',
//    autoclose: true,
//    todayHighlight: true
//});

}

