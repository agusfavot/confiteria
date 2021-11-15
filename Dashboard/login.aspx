<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Dashboard.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <link href="https://fonts.googleapis.com/css?family=Lato:300,400,700&display=swap" rel="stylesheet" />

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" />

    <link rel="stylesheet" href="Resource/css/style.css" />

    <title>LOGIN</title>
</head>
<body>
    <section class="ftco-section">
        <div class="container">
            <form id="form" runat="server">

                <div class="row justify-content-center">
                    <div class="col-md-6 col-lg-4">
                        <div class="login-wrap py-5">
                            <h3 class="text-center mb-0">Bienvenido</h3>
                            <div class="p-3"></div>
                            <div class="form-group">
                                <div class="icon d-flex align-items-center justify-content-center"><span class="fa fa-user"></span></div>
                                <asp:TextBox ID="name" runat="server" type="text" class="form-control" placeholder="Username" required="required"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <div class="icon d-flex align-items-center justify-content-center"><span class="fa fa-lock"></span></div>
                                <asp:TextBox ID="pass" runat="server" type="password" class="form-control" placeholder="Password" required="required"></asp:TextBox>
                            </div>
                            <div class="p-3">
                            </div>
                            <div class="form-group">
                                <asp:Button ID="Button1" runat="server" Text="Iniciar Sesión" class="btn form-control btn-primary rounded submit px-3" OnClick="logIn" />
                            </div>
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </section>
    <script src="Script/jquery.min.js"></script>
    <script src="Script/popper.js"></script>
    <script src="Script/bootstrap.min.js"></script>
    <script src="Script/main.js"></script>
</body>
</html>
