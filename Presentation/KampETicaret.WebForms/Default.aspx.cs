using KampETicaret.WebForms.Auth.JWT;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Optimization;
using System.Web.Script.Serialization;
using System.Web.Services.Protocols;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KampETicaret.WebForms
{
    public partial class _Default : Page
    {

        public _Default()
        {
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Giriş yap butonuna tıklandığında çalışacak kodlar buraya gelebilir.
            string userName = txtUsername.Value;
            string password = txtPassword.Value;
            var uri = new Uri(string.Format("https://localhost:7286/api/Auth/Login?UserName=" + userName + "&Password=" + password));
            WebRequest request = WebRequest.Create(uri);
            request.ContentType = "application/json";
            request.Method = "GET";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            string result;
            UserLoginResponse userResponse =new UserLoginResponse();
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {

                        StreamReader streamReader = new StreamReader(stream);
                        result = streamReader.ReadToEnd();
                        userResponse = JsonConvert.DeserializeObject<UserLoginResponse>(result);
                        streamReader.Close();
                    }
                }
                

            }
            catch (Exception ex)
            {
                result = ex.Message;

            }
            if (userResponse.Success)
            {
                string tokenJson = JsonConvert.SerializeObject(userResponse.Token);
                string script = $"localStorage.setItem('token', \"{tokenJson}\");"; // Local Storage'a token nesnesini kaydediyoruz
                ClientScript.RegisterStartupScript(this.GetType(), "tokenScript", script, true); // JavaScript kodunu sayfaya gönderiyoruz
                Response.Redirect("Contact.aspx");
            }
           

        }

    }
    public class UserLoginResponse
    {
        public string Message { get; set; }
        public Token Token { get; set; }
        public bool Success { get; set; }
    }
}