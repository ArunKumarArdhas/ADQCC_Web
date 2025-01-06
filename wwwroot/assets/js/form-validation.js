$(function () {
    "use strict";
    $(function () {
        $("#usersignupForm").validate({
            rules: {
                sel_Account_Type: {
                    required: !0
                },
                name: {
                    required: !0,
                    minlength: 3
                },
                Lastname: {
                    required: !0,
                    minlength: 1
                },
                MobileNumber: {
                    required: !0,
                    minlength: 10
                },
                PassportNumber: {
                    required: !0,
                    minlength: 10
                },
                password: {
                    required: !0,
                    minlength: 5
                },
                confirm_password: {
                    required: !0,
                    minlength: 5,
                    equalTo: "#password"
                },
                email: {
                    required: !0,
                    email: !0
                }
            },
            messages: {
                sel_Account_Type: {
                    required: "Please Select Account Type"
                },
                name: {
                    required: "Please enter a name",
                    minlength: "Name must consist of at least 3 characters"
                },
                Lastname: {
                    required: "Please enter a last name",
                    minlength: "Name must consist of at least 1 characters"
                },
                MobileNumber: {
                    required: "Please enter a Mobile Number",
                    minlength: "Name must consist of at least 10 characters"
                },
                PassportNumber: {
                    required: "Please enter a Passport Number",
                    minlength: "Name must consist of at least 10 characters"
                },
                password: {
                    required: "Please provide a password",
                    minlength: "Your password must be at least 5 characters long"
                },
                confirm_password: {
                    required: "Please provide a password",
                    minlength: "Your password must be at least 5 characters long",
                    equalTo: "Please enter the same password as above"
                },
                email: "Please enter a valid email address"
            },
            errorPlacement: function (e, a) {
                e.addClass("mt-2 text-danger"), e.insertAfter(a)
            },
            highlight: function (e, a) {
                $(e).parent().addClass("has-danger"), $(e).addClass("form-control-danger")
            },
            submitHandler: function () {
                var e = $("#USER_ID"),
                    a = $("#name"),
                    r = $("#Lastname"),
                    n = $("#MobileNumber"),
                    t = $("#PassportNumber"),
                    o = $("#email"),
                    s = $("#password"),
                    i = $("#confirm_password"),
                    l = $("#sel_Account_Type");
                $.ajax({
                    type: "POST",
                    url: "/Account/AddUserRegister",
                    cache: !1,
                    data: '{FIRST_NAME: "' + a.val() + '", LAST_NAME: "' + r.val() + '", MOBILE_NUMBER: "' + n.val() + '", EMAIL_ID: "' + o.val() + '", PASSPORT_NUMBER: "' + t.val() + '", PASSWORD: "' + s.val() + '", CONFIRM_PASSWORD: "' + i.val() + '", ACCOUNT_TYPE_ID: "' + l.val() + '", USER_ID: "' + e.val() + '" }',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (e) {
                        "200" == e.STATUS_CODE ? Swal.fire({
                            position: "top-end",
                            icon: "success",
                            title: e.MESSAGE,
                            showConfirmButton: !1,
                            timer: 1500
                        }).then(function () {
                            window.location.href = "/Account/Login/"
                        }) : ("400" == e.STATUS_CODE ? Swal.fire({
                            position: "top-end",
                            icon: "error",
                            title: "Email Already Exist",
                            showConfirmButton: !1,
                            timer: 1500
                        }) : Swal.fire({
                            position: "top-end",
                            icon: "error",
                            title: e.MESSAGE,
                            showConfirmButton: !1,
                            timer: 1500
                        })).then(function () {
                            window.location.href = "/Account/UserRegister/"
                        })
                    }
                })
            }
        }), $("#agentsignupForm").validate({
            rules: {
                sel_Account_Type: {
                    required: !0
                },
                Companyname: {
                    required: !0,
                    minlength: 3
                },
                CompanyType: {
                    required: !0,
                    minlength: 1
                },
                AgentMobileNumber: {
                    required: !0,
                    minlength: 10
                },
                AgentPassportNumber: {
                    required: !0,
                    minlength: 10
                },
                Agentemail: {
                    required: !0,
                    email: !0
                },
                Agentpassword: {
                    required: !0,
                    minlength: 5
                },
                Agentconfirm_password: {
                    required: !0,
                    minlength: 5,
                    equalTo: "#Agentpassword"
                },
                Tin_Number: {
                    required: !0,
                    minlength: 2
                },
                GST_Number: {
                    required: !0,
                    minlength: 15
                }
            },
            messages: {
                sel_Account_Type: {
                    required: "Please Select Account Type"
                },
                Companyname: {
                    required: "Please enter a Company name",
                    minlength: "Name must consist of at least 3 characters"
                },
                CompanyType: {
                    required: "Please enter a Company Type",
                    minlength: "Name must consist of at least 3 characters"
                },
                AgentMobileNumber: {
                    required: "Please enter a Mobile Number",
                    minlength: "Name must consist of at least 10 characters"
                },
                AgentPassportNumber: {
                    required: "Please enter a Passport Number",
                    minlength: "Name must consist of at least 10 characters"
                },
                Agentpassword: {
                    required: "Please provide a password",
                    minlength: "Your password must be at least 5 characters long"
                },
                Agentemail: "Please enter a valid email address"
            },
            errorPlacement: function (e, a) {
                e.addClass("mt-2 text-danger"), e.insertAfter(a)
            },
            highlight: function (e, a) {
                $(e).parent().addClass("has-danger"), $(e).addClass("form-control-danger")
            },
            submitHandler: function () {
                var e = $("#AGENT_ID"),
                    a = $("#Companyname"),
                    r = $("#CompanyType"),
                    n = $("#AgentMobileNumber"),
                    t = $("#AgentPassportNumber"),
                    o = $("#Agentemail"),
                    s = $("#Agentpassword"),
                    i = $("#Agentconfirm_password"),
                    l = $("#Tin_Number"),
                    d = $("#GST_Number"),
                    c = $("#sel_Account_Type");
                $.ajax({
                    type: "POST",
                    url: "/Account/ADD_VISA_AGENT_REGISTER",
                    cache: !1,
                    data: '{COMPANY_NAME:"' + a.val() + '", COMPANY_TYPE: "' + r.val() + '",MOBILE_NUMBER: "' + n.val() + '", EMAIL_ID:"' + o.val() + '",PASSPORT_NUMBER: "' + t.val() + '",PASSWORD:"' + s.val() + '", CONFIRM_PASSWORD: "' + i.val() + '",TIN_NUMBER: "' + l.val() + '",GST_NUMBER: "' + d.val() + '",ACCOUNT_TYPE_ID: "' + c.val() + '",AGENT_ID: "' + e.val() + '" }',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (e) {
                        "200" == e.STATUS_CODE ? Swal.fire({
                            position: "top-end",
                            icon: "success",
                            title: e.MESSAGE,
                            showConfirmButton: !1,
                            timer: 1500
                        }).then(function () {
                            window.location.href = "/Account/Login/"
                        }) : ("400" == e.STATUS_CODE ? Swal.fire({
                            position: "top-end",
                            icon: "error",
                            title: "Email Already Exist",
                            showConfirmButton: !1,
                            timer: 1500
                        }) : Swal.fire({
                            position: "top-end",
                            icon: "error",
                            title: e.MESSAGE,
                            showConfirmButton: !1,
                            timer: 1500
                        })).then(function () {
                            window.location.href = "/Account/UserRegister/"
                        })
                    }
                })
            }
        }), $("#userLoginForm").validate({
            rules: {
                email: {
                    required: !0,
                    email: !0
                },
                password: {
                    required: !0,
                    minlength: 5
                }
            },
            messages: {
                email: "Please enter a valid email address",
                password: {
                    required: "Please provide a password",
                    minlength: "Your password must be at least 5 characters long"
                }
            },
            errorPlacement: function (e, a) {
                e.addClass("mt-2 text-danger"), e.insertAfter(a)
            },
            highlight: function (e, a) {
                $(e).parent().addClass("has-danger"), $(e).addClass("form-control-danger")
            },
            submitHandler: function () {
                var e = $(".loginemail"),
                    a = $(".loginpaswd");
                $.ajax({
                    type: "POST",
                    url: "/Account/LoginAsync",
                    cache: !1,
                    data: '{LOGIN_USER_NAME: "' + e.val() + '", LOGIN_PASSWORD: "' + a.val() + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (e) {
                        "200" == e.STATUS_CODE ? Swal.fire({
                            position: "top-end",
                            icon: "success",
                            title: e.MESSAGE,
                            showConfirmButton: !1,
                            timer: 1500
                        }).then(function () {
                            "1" == e.USER_DETAILS.ACCOUNT_TYPE_ID ? window.location.href = "/Dashboard/Index/" : "2" == e.USER_DETAILS.ACCOUNT_TYPE_ID ? window.location.href = "/Dashboard/UserDashboard/" : window.location.href = "/Dashboard/AgentDashboard/"
                        }) : Swal.fire({
                            position: "top-end",
                            icon: "error",
                            title: e.MESSAGE,
                            showConfirmButton: !1,
                            timer: 1500
                        })
                    }
                })
            }
        }), $("#userForgotForm").validate({
            rules: {
                email: {
                    required: !0,
                    email: !0
                },
                password: {
                    required: !0,
                    minlength: 5
                }
            },
            messages: {
                email: "Please enter a valid email address",
                password: {
                    required: "Please provide a password",
                    minlength: "Your password must be at least 5 characters long"
                }
            },
            errorPlacement: function (e, a) {
                e.addClass("mt-2 text-danger"), e.insertAfter(a)
            },
            highlight: function (e, a) {
                $(e).parent().addClass("has-danger"), $(e).addClass("form-control-danger")
            },
            submitHandler: function () {
                var e = $(".loginemail"),
                    a = $(".loginpaswd");
                $.ajax({
                    type: "POST",
                    url: "/Account/UpdateForgotPassword",
                    cache: !1,
                    data: '{LOGIN_USER_NAME: "' + e.val() + '", LOGIN_PASSWORD: "' + a.val() + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (e) {
                        0 < parseInt(e.STATUS_CODE) ? Swal.fire({
                            position: "top-end",
                            icon: "success",
                            title: e.MESSAGE,
                            showConfirmButton: !1,
                            timer: 1500
                        }).then(function () {
                            window.location.href = "/Account/Login/"
                        }) : Swal.fire({
                            position: "top-end",
                            icon: "error",
                            title: e.MESSAGE,
                            showConfirmButton: !1,
                            timer: 1500
                        })
                    }
                })
            }
        })
    })
});
var submit = 0;

function validataionLogin() {
    debugger;
    if ($("#Loaderbck").show(), $("#Loader").show(), 2 < ++submit) return $("#OTP").val(""), $("#OptDiv").hide(100), $("#LoginDiv").show(100), toastr.error("Wrong OTP entered for more than two attempts.Please Login again!", "Error"), !1;
    var e = $("#Username").val(),
        a = $("#Password").val(),
        r = $("#OTP").val(),
        n = $('input[name="Language"]:checked').val();
    if ("" == r) return $(".login").show(), $("#OTP").css("border-color", "red"), $("#OTP").focus(), submit = 0, !1;
    if ("" == e) return $(".login").show(), $("#Username").css("border-color", "red"), $("#Username").focus(), submit = 0, !1;
    if ("" == a) return $(".pasword").show(), $("#Password").css("border-color", "red"), $("#Password").focus(), submit = 0, !1;
    if ("0" == n) return $(".language").show(), $("#Language").focus(), submit = 0, !1;
    var t = $("#Frm_Login"),
        r = {
            __RequestVerificationToken: $('input[name="__RequestVerificationToken"]', t).val(),
            UserName: e,
            Password: a,
            LANG_ID: n,
            OTP: r
        },
        r = $.param(r);
    return $.ajax({
        url: "/Account/LoginAsync",
        type: "POST",
        dataType: "json",
        data: r,
        ContentType: "application/x-www-form-urlencoded;charset=UTF-8",
        success: function (r) {
            "200" == r.STATUS_CODE ? (sessionStorage.setItem("LANG_ID", r.LANG_ID), sessionStorage.setItem("DESI_NAME", r.DESI_NAME), toastr.success(r.MESSAGE, "Success"), $("#Loaderbck").hide(), $("#Loader").hide(), $("#Password").val(""), setTimeout(function () {
                var e = sessionStorage.getItem("DESI_NAME");
                let a = "";
                a = "ADMIN" == e ? "bo" : sessionStorage.getItem("LANG_ID"), "Employee" == r.DESI_NAME ? window.location.href = "/TrainingManagement/TrainingEmployeeDashboard/?LanguageAbbrevation=" + a : window.location.href = '/Dashboard/AdminDashboard/?LanguageAbbrevation=' + a
            }, 200)) : ($("#Password").val(""), $("#OTP").val(""), submit++, toastr.error("Wrong OTP", "Error"), $("#Loaderbck").hide(), $("#Loader").hide())
        }
    }), !0
}



function FnForgotPassword() {
    $(".FnForgotpass").show(100), $(".FnLogin").hide(100)
}

function Fnback() {
    $(".FnForgotpass").hide(100), $(".FnLogin").show(100)
}

function Fn_forgotpassword() {
    var EMP_USERNAME = $("#User_Name").val();
    if (EMP_USERNAME == "") {
        $('#User_Name').css('border-color', 'red');
        $("#User_Name").focus();
        return false;
    }
    else {
        $.ajax({
            url: '/Account/ForgotPassword',
            type: 'POST',
            data: jQuery.param({ EMP_USERNAME: EMP_USERNAME }),
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            success: function (data) {
                if (data.STATUS_CODE == '200') {
                    toastr.success(data.MESSAGE, "Success");
                    $(".FnForgotpass").hide(100);
                    $(".FnLogin").show(100);
                }
                else {
                    toastr.error(data.MESSAGE, "Error");
                    $(".FnForgotpass").show(100);
                    $(".FnLogin").hide(100);
                }
            },
            error: function () {
                alert("error");
            }
        });
    }
}