/// <reference path="C:\Users\Administrator\Documents\Visual Studio 2015\Projects\SampleProject\SampleProject\scripts/angular.js" />
var app = angular.module("myapp", []);
app.controller("Registrationctrl", function ($scope, $http, UniqueEmail,uniquePhno, $window) {
    $scope.Insertuser = function () {
        debugger;
        $scope.userdata = {};
        $scope.userdata.Fullname = $scope.Reg_fullname;
        $scope.userdata.Email = $scope.Reg_Email;
        $scope.userdata.PhoneNo = $scope.Reg_phoneNo;
        $scope.userdata.Username = $scope.Reg_UserName;
        $scope.userdata.Password = $scope.Reg_password;
        $scope.userdata.Gender = $scope.Reg_gender;

        $http({
            method: "post",
            url: "/Register/Register_userdata",
            datatype: "json",
            data: JSON.stringify($scope.userdata)
        })
        $scope.msg = "register succfelly";
    };


    $scope.login = function () {
        //$('#myModal').modal('hide');
        alert("Login method hitting");
        //$scope.showModal = false;
        $scope.logindata = {};
        $scope.logindata.Username = $scope.uname;
        $scope.logindata.Password = $scope.pwd;
        $http({
            method: "post",
            url: "/Register/checkuserlogin",
            datatype: "json",
            data: JSON.stringify($scope.logindata)
        }).then(function (responce) {
            debugger;
            $('#myModal').modal('hide');
            console.log(responce.data);
            alert(responce.data);
            if (responce.data == 0) {
                //$('#myModal').modal('hide');
                //$scope.showModal = false;
                alert('login failed');
                $scope.showModal = false;
            }
            else {
                $('#myModal').modal('show');
                $scope.showModal = true;
                $window.location.href = "/Registration.html";
                $scope.showModal = true;
                $scope.msg = 'Login success';
                navigate();
                $window.location("/Registration.html");
                //$location.path("/Registration.html");
                //$location.url('http://localhost:49531/Registration.html');
            }
        }
        )
        $scope.msg = "register succfelly";
    };
    $scope.chech_Email = function () {
        UniqueEmail.Checkemail($scope.Reg_Email).then(function (responce) {
            console.log(responce.data);
            alert(responce.data);
            if (responce.data == 1) {
                alert("Email Is already Exist");
                $scope.emailspan = "Email Is already Exist";
            }
            else {
                $scope.emailspan = "";
            }
        })
    };
    $scope.check_phno = function () {
        uniquePhno.uniquePhno($scope.Reg_phoneNo).then(function (responce) {
            alert(responce.data);
            console.log(responce.data);
            if (responce.data == 1) {
                alert("Phono Is already Exist");
                $scope.phonespan = "Phono Is already Exist";
            }
            else {

                $scope.phonespan = "";
            }
        })
    }


    //$scope.UniqueEmail = function ($scope) {

    //    alert($scope.Email);
    //    $scope.
    //    Unique_email.checkemail($scope.Email).then(function (responce) {

    //        alert(responce.data);
    //        if (responce.data == 1)
    //            $scope.emailmsg = "Email Already Exixt Give another email";
    //        else
    //            $scope.emailmsg = "";
    //    });
    //    //    UniqueEmail.Check($scope.email).then(function (response) {
    //    //        console.log(response.data);


    //    //        if (response.data ==0) {
    //    //            //  return "Email is already Exist";
    //    //            $scope.emailspan = "";

    //    //        }
    //    //        else {
    //    //            $scope.emailspan = "Email is already Exist Please Login";
    //    //            //alert();
    //    //        }


    //    //};
    //}
    //$scope.ButtonClick = function ($scope) {

    //    alert('ButtonClick method called');
    //    //$http({
    //    //    method: "GET",
    //    //    url: "/Register/unique_Email",
    //    //    datatype: 'json',
    //    //    data: { Email: $scope.Email },
    //    $http({
    //        method: "GET",
    //        url: "/Register/unique_Email?email=" + $scope.Email,
    //        datatype: "json",
    //        //data: JSON.stringify($scope.Email)

    //    }).then(function (response) {
    //        debugger;
    //        alert(response.data);
    //        $window.alert("Hello: " + response.Email );
    //        //$scope.employees = response.data;
    //        //console.log($scope.employees);
    //    }, function () {
    //        alert("Error Occur");
    //        $scope.emailspan = "Error Occur";
    //    })
    //};
    ////app.factory('Unique_email', function ($http) {

    ////    var objEmail = {};
    ////    debugger;
    ////    objEmail.checkemail = function (Email) {
    ////        alert("hi unique email");
    ////        $http.get("/Register/unique_Email?Email=" + Email);
    ////    };
    ////    return objEmail;

    ////});
});
app.factory('UniqueEmail', function ($http) {
    alert("UniQUEEmail");
    var fac = {};

    fac.Checkemail = function (Email) {
        return $http.get("/Register/unique_Email?email=" + Email);
    }
    return fac;
})
app.factory('uniquePhno', function ($http) {
    alert('unique Phno no');
    var fac = {};
    fac.uniquePhno = function (phno) {
        return $http.get("/Register/unique_Email" + phno);

    }
    return fac;
})