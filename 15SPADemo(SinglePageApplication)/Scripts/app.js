//$(document).ready(function () {
//    var nameElement = $("#name");
//    var ageElement = $("#age");
//    var idElement = $("#employee-id");
//    var tablebBodyElement = $("#employee-tablebody");

//    var createbtn = $("#create-btn");
//    var updatebtn = $("#update-btn");
//    var cancelbtn = $("#cancel-btn");

//    var employees = [];

//    // IIFY immediately invokable function expression
//    (function () {
//        getEmployees();
//        updateButtonDisplay(true, false, false);
//        createbtn.on('click', createEmployee);
//        addEvents();
//    })();

//    function onEdit() {
//        var id = $(this).attr('data-id');

//        employees.forEach(function (item, index) {
//            if (item.Id == id) {
//                nameElement.val(item.Name);
//                ageElement.val(item.Age);
//                idElement.val(item.Id);
//                updateButtonDisplay(false, true, true);
//                return 0;
//            }
//        });
//    }

//    function addEvents() {
//        $('.employee-id').each(function () {
//            $(this).on('click', onEdit);
//        });
//    }
//    function getEmployees() {
//        $.ajax({
//            method: "GET",
//            url: "/home/GetAll",
//            success: function (data) {
//                employees = data;
//                populateTable();
//            }
//        });
//        addEvents();
//    }

//    function populateTable() {
//        tablebBodyElement.empty();
//        employees.forEach(function (item, index) {
//            var row = '<tr><td><span class="employee-id" data-id="' + item.Id + '">' + item.Id + '</span></td><td>' + item.Name + '</td><td>' + item.Age + '</td><td><i class="glyphicon glyphicon-trash" data-id"' + item.Id + '></i></td></tr>';
//            tablebBodyElement.append(row);
//       });
//    }


//    function updateButtonDisplay(showCreate, showUpdate, showCancel) {
//        showCreate ? createbtn.show() : createbtn.hide();
//        showUpdate ? updatebtn.show() : updatebtn.hide();
//        showCancel ? cancelbtn.show() : cancelbtn.hide();
//    }
//    function createEmployee() {
//        $.ajax({
//            method: "POST",
//            data: { name: nameElement.val(), age: ageElement.val() },
//            url: "/home/save",
//            success: function (data) {
//                employees.push(data);
//                console.log(employees);
//            }
//        });
//    }

//    $.ajaxSetup({
//        beforeSend: function () {
//            $('#loader').show();
//        },
//        complete: function () {
//            $('#loader').hide();
//        }
//    });
//});


$(document).ready(function () {
    var nameElement = $("#name");
    var ageElement = $("#age");
    var idElement = $("#employee-id");
    var tablebBodyElement = $("#employee-tablebody");
    var createbtn = $("#create-btn");
    var updatebtn = $("#update-btn");
    var cancelbtn = $("#cancel-btn");

    var employees = [];

    // IIFY immediately invokable function expression
    (function () {
        getEmployees();
        updateButtonDisplay(true, false, false);

        createbtn.on('click', createEmployee);
        updatebtn.on('click', updateEmployee);
        cancelbtn.on('click', cancel);

        addEvents();
    })();


    function updateEmployee() {
        $.ajax({
            method: "POST",
            data: { id: idElement.val(), name: nameElement.val(), age: ageElement.val() },
            url: "/home/save",
            success: function (data) {
                getEmployees();
                cancel();
            }
        });
    }

    function cancel() {
        nameElement.val('');
        ageElement.val('');
        updateButtonDisplay(true, false, false);
    }

    function onEdit() {
        var id = $(this).attr('data-id');

        employees.forEach(function (item, index) {
            if (item.Id == id) {
                nameElement.val(item.Name);
                ageElement.val(item.Age);
                idElement.val(item.Id);
                updateButtonDisplay(false, true, true);
                return 0;
            }
        });
    }

    function onDelete() {
        var id = $(this).attr('data-id');
        //$.ajax({
        //    method: "GET",  /*get*/
        //    url: "/home/delete?id=" + id,
        //    success: function (data) {
        //        getEmployees();
        //    }
        //});
        $.get("/home/delete?id=" + id, function (data) {
            getEmployees();
        });
    }

    function addEvents() {
        $('.employee-id').each(function () {
            $(this).on('click', onEdit);
        });

        $('.glyphicon-trash').each(function () {
            $(this).on('click', onDelete);
        });
    }

    function getEmployees() {
        //$.ajax({
        //    method: "GET",/*get*/
        //    url: "/home/GetAll",
        //    success: function (data) {
        //        employees = data;
        //        populateTable();
        //    }
        //});
        $.get("/home/GetAll", function (data) {
            employees = data;
            populateTable();
        });
        $.get()
    }

    function populateTable() {
        tablebBodyElement.empty();
        employees.forEach(function (item, index) {
            var row = '<tr><td><span class="employee-id" data-id="' + item.Id + '">' + item.Id + '</span></td><td>' + item.Name + '</td><td>' + item.Age + '</td><td><i class="glyphicon glyphicon-trash" data-id="' + item.Id + '"></i></td></tr>';
            tablebBodyElement.append(row);
        });
        addEvents();
    }

    function updateButtonDisplay(showCreate, showUpdate, showCancel) {
        showCreate ? createbtn.show() : createbtn.hide();
        showUpdate ? updatebtn.show() : updatebtn.hide();
        showCancel ? cancelbtn.show() : cancelbtn.hide();
    }

    function createEmployee() {
        $.ajax({
            method: "POST",/*post*/
            data: { name: nameElement.val(), age: ageElement.val() },
            url: "/home/save",
            success: function (data) {
                employees.push(data);
                console.log(employees);
                getEmployees();
            }
        });
    }

    $.ajaxSetup({
        beforeSend: function () {
            $('#loader').show();
        },
        complete: function () {
            $('#loader').hide();
        }
    });
});

