using ServiceStack;
using System;
using System.Windows.Forms;
using WebApiModel;
using WebApplicationASP.Status;

namespace DesktopApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //string url = "http://localhost:53817/Authenticate";
            //var client = new JsonServiceClient(url);
            //var request = new AuthenticationRequest()
            //{
            //    SystemId = "EGIS",
            //    UserName = "Designer",
            //    AuthenticationType = AuthenticationType.Basic
            //};
            //var authenticationResponse = client.Post(request);

            //label1.Text = authenticationResponse.Message;
            
            //provide valid credentials
            var client = new JsonServiceClient("http://localhost:53817/") { UserName = "thanhbka", Password = "pass123"};
            try
            {
                var response = client.Send(new StatusRequest() { DateStatus = DateTime.Now });
                Console.WriteLine("{0} of {1} has", response.Total, response.Goal);
                label1.Text = response.Total + " status " + response.Goal + " session " + response.Message;
            }
            catch (Exception ex)
            {
                label1.Text = ex.Message;
            }
            
        }
    }
}
