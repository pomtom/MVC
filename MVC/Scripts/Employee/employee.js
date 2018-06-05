/// <reference path="../jquery-3.3.1.js" />

$(document).ready(function () {

    $('#btngetemployee').click(function () {
        GetAllEmployee();
    });

    function GetAllEmployee() {
        $.ajax({
            url: '/JqueryApp/GetAllEmployee',
            dataType: 'json',
            method: 'get',
            success: function (data) {
                var employeetable = $('table tbody');
                employeetable.empty();
                $(data).each(function (index, emp) {
                    employeetable.append('<tr><td>' + emp.Id + '</td><td>' + emp.Name + '</td><td>' + emp.Gender +
                        '</td><td>' + emp.Email + '</td><td>' + emp.Salary + '</td></tr>');
                });
            },
            error: function (err) {
                alert(err.statusText);
                console.log(err.responseText);
            }
        });
    }

    $('#btncreate').click(function () {
        var employee = {};
        employee.Name = $('#txtname').val();
        employee.Salary = $('#txtsalary').val();
        employee.Email = $('#txtemail').val();
        employee.Gender = $('#txtgender').val();
        debugger;
        $.ajax({
            url: '/JqueryApp/Create',
            contentType: 'application/json; charset=utf-8',
            method: 'post',
            data: '{emp:' + JSON.stringify(employee) + '}',
            success: function (data) {
                GetAllEmployee();
            },
            error: function (err) {
                alert(err.responseText);
            }
        });
    });

});
