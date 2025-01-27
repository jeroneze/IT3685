﻿<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="IT3685.Login" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeaderContent" runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">



</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="limiter">
        <div class="container-login100" style="background-image: url('Content/images/login-bg.jpg');">
            <div class="wrap-login100 p-l-110 p-r-110 p-t-62 p-b-33">
                <form class="login100-form validate-form flex-sb flex-w">
                    <span class="login100-form-title p-b-53">Log In
                    </span>

                    <asp:Label runat="server" ID="lblErrorMsg" Style="color: red" Text=""></asp:Label>
                    <div class="p-t-31 p-b-9">
                        <span class="txt1">Email
                        </span>
                    </div>
                    <div class="wrap-input100 validate-input" data-validate="Email is required">
                        <asp:TextBox runat="server" CssClass="input100" ID="txtEmail"></asp:TextBox>
                        <span class="focus-input100"></span>
                    </div>

                    <div class="p-t-13 p-b-9">
                        <span class="txt1">Password
                        </span>

                        <a href="ForgetPassword" class="txt2 bo1 m-l-5">Forgot?
                        </a>
                    </div>
                    <div class="wrap-input100 validate-input" data-validate="Password is required">
                        <asp:TextBox type="password" runat="server" CssClass="input100" ID="txtPassword"></asp:TextBox>
                        <span class="focus-input100"></span>
                    </div>

                    <div class="container-login100-form-btn m-t-17">
                        <asp:LinkButton runat="server" CssClass="login100-form-btn" style="color: white" OnClick="OnLoginClick">Sign In</asp:LinkButton>
                    </div>

                    <div class="w-full text-center p-t-55">
                        <span class="txt2">Not a member?
                        </span>

                        <a href="Signup" class="txt2 bo1">Sign up now
                        </a>
                    </div>
                </form>
            </div>
        </div>
    </div>


    <div id="dropDownSelect1"></div>

    <!--===============================================================================================-->
    <script src="Content/vendor/jquery/jquery-3.2.1.min.js"></script>
    <!--===============================================================================================-->
    <script src="Content/vendor/animsition/js/animsition.min.js"></script>
    <!--===============================================================================================-->
    <script src="Content/vendor/bootstrap/js/popper.js"></script>
    <script src="Content/vendor/bootstrap/js/bootstrap.min.js"></script>
    <!--===============================================================================================-->
    <script src="Content/vendor/select2/select2.min.js"></script>
    <!--===============================================================================================-->
    <script src="Content/vendor/daterangepicker/moment.min.js"></script>
    <script src="Content/vendor/daterangepicker/daterangepicker.js"></script>
    <!--===============================================================================================-->
    <script src="Content/vendor/countdowntime/countdowntime.js"></script>
    <!--===============================================================================================-->
    <script src="Content/js/login.js"></script>

</asp:Content>
