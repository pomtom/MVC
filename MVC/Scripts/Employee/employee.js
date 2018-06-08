/// <reference path="../jquery-3.3.1.js" />

$(document).ready(function () {

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
        employee.SelectedDepartmentId = $('#ddlvalue').val();

        $.ajax({
            url: '/JqueryApp/Create',
            contentType: 'application/json; charset=utf-8',
            method: 'post',
            data: '{emp:' + JSON.stringify(employee) + '}',
            success: function (data) {
                LoadIndexView();
            },
            error: function (err) {
                alert(err.responseText);
            }
        });
    });

    function LoadIndexView() {
        $.ajax({
            url: '/JqueryApp/_EmpList',
            method: 'get',
            success: function (data) {
                $('#LoadData').html(data);
            },

            error: function (err) {
                alert(err.statusText);
            }
        });


    }
});
