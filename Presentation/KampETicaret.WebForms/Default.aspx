<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="KampETicaret.WebForms._Default" %>

<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
       <!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Giriş Ekranı</title>
</head>
<body>
    <form runat="server" style="display: flex; flex-direction: column; align-items: center; justify-content: center; height: 100vh;">
        <div style="text-align: center;">
            <div style="margin-bottom: 10px;">
                <label for="txtUsername">Kullanıcı Adı:</label>
                <br />
                <input type="text" id="txtUsername" runat="server" />
            </div>

            <div style="margin-bottom: 10px;">
                <label for="txtPassword">Şifre:</label>
                <br />
                <input type="password" id="txtPassword" runat="server" />
            </div>
              
             <asp:Button ID="btnLogin" runat="server" Text="Giriş Yap" OnClick="btnLogin_Click" OnClientClick="saveDataToLocal()" />
            
            <script>
                $(document).ready(function () {
                    // btnLogin butonuna tıklandığında çalışacak JavaScript kodunu tanımlıyoruz
                    $("#<%= btnLogin.ClientID %>").click(function () {
                        // Token nesnesini Local Storage'a kaydediyoruz
                        localStorage.setItem('token', JSON.stringify(token));
                    });
                });
            </script>
            <br />

            <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message"></asp:Label>
        </div>
    </form>
</body>
</html>
 