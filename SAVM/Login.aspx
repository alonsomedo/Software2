<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SAVM.Login" %>

<!DOCTYPE html>

<html class="bg-black" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login</title>
    <link href="plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
	<link href="img/mundo4.jpg" type="icon" />
    <link href="css/AdminLTE.css" rel="stylesheet" />
</head>
<body class="bg-black">
    <form id="form1" runat="server">
        <div class="form-box" id="login-box">

                    <div class="header">Iniciar Sesion</div>

                    <div class="body bg-gray">
                        <div class="form-group">
                            <asp:TextBox ID="Username" runat="server" class="form-control" placeholder="Ingrese usuario"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="Password" runat="server" class="form-control" type="password" placeholder="Ingrese contraseña"></asp:TextBox>
                        </div>
                    </div>
                    <div class="footer">
                        <asp:Button ID="BtnIngreso" CommandName="Login" runat="server" Text="Ingresar" class="btn bg-olive btn-block" OnClick="BtnIngreso_Click" />
                    </div>

        </div>
    </form>

</body>

</html>
