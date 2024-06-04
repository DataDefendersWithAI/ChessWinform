using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Net;

namespace winform_chat
{
    public partial class RegisterForm : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "RZxEKkX6ffq8XZgw9p0jbPYhqLYXQOeH1FIcmGIa",
            BasePath = "https://chess-database-a25f7-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };
        IFirebaseClient Client;
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        int Counter = 3;
        Random random = new Random();
        int OTP;
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void AccountBox_Enter(object sender, EventArgs e)
        {
            if (AccountBox.Text == "Enter username")
            {
                AccountBox.Text = "";
                AccountBox.ForeColor = Color.Black;
            }
        }

        private void AccountBox_Leave(object sender, EventArgs e)
        {
            if (AccountBox.Text == "")
            {
                AccountBox.Text = "Enter username";
                AccountBox.ForeColor = Color.Silver;
            }
        }

        private void EmailBox_Enter(object sender, EventArgs e)
        {
            if (EmailBox.Text == "Enter email")
            {
                EmailBox.Text = "";
                EmailBox.ForeColor = Color.Black;
            }
        }

        private void EmailBox_Leave(object sender, EventArgs e)
        {
            if (EmailBox.Text == "")
            {
                EmailBox.Text = "Enter email";
                EmailBox.ForeColor = Color.Silver;
            }
        }

        private void PasswordBox_Enter(object sender, EventArgs e)
        {
            if (PasswordBox.Text == "Enter password")
            {
                PasswordBox.Text = "";
                PasswordBox.ForeColor = Color.Black;
                PasswordBox.PasswordChar = '*';
                PasswordBox.UseSystemPasswordChar = true;
            }
        }

        private void PasswordBox_Leave(object sender, EventArgs e)
        {
            if (PasswordBox.Text == "")
            {
                PasswordBox.Text = "Enter password";
                PasswordBox.ForeColor = Color.Silver;
                PasswordBox.PasswordChar = '\0';
                PasswordBox.UseSystemPasswordChar = false;
            }
        }

        private void ReTypePasswordBox_Enter(object sender, EventArgs e)
        {
            if (ReTypePasswordBox.Text == "Retype password")
            {
                ReTypePasswordBox.Text = "";
                ReTypePasswordBox.ForeColor = Color.Black;
                ReTypePasswordBox.PasswordChar = '*';
                ReTypePasswordBox.UseSystemPasswordChar = true;
            }
        }

        private void ReTypePasswordBox_Leave(object sender, EventArgs e)
        {
            if (ReTypePasswordBox.Text == "")
            {
                ReTypePasswordBox.Text = "Retype password";
                ReTypePasswordBox.ForeColor = Color.Silver;
                ReTypePasswordBox.PasswordChar = '\0';
                ReTypePasswordBox.UseSystemPasswordChar = false;
            }
        }

        private void SignInLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void OTPBox_Enter(object sender, EventArgs e)
        {
            if (OTPBox.Text == "Enter OTP")
            {
                OTPBox.Text = "";
                OTPBox.ForeColor = Color.Black;
            }
        }

        private void OTPBox_Leave(object sender, EventArgs e)
        {
            if (OTPBox.Text == "")
            {
                OTPBox.Text = "Enter OTP";
                OTPBox.ForeColor = Color.Silver;
            }
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            Client = new FireSharp.FirebaseClient(config);
            if (Client != null)
            {
                StatusText.Text = "Current Status: Connected to Database";
            }
            else
            {
                StatusText.Text = "Current Status: Not Connected to Database";
            }
        }

        private async void RegisterButton_Click(object sender, EventArgs e)
        {
            if (AccountBox.Text == "Enter username" || EmailBox.Text == "Enter email" || PasswordBox.Text == "Enter password" || ReTypePasswordBox.Text == "Retype password" || OTPBox.Text == "Enter OTP")
            {
                StatusText.Text = "Current Status: Please fill in all the fields";
            }
            else if (PasswordBox.Text != ReTypePasswordBox.Text)
            {
                StatusText.Text = "Current Status: Passwords do not match";
            }
            else if (OTP.ToString().Equals(OTPBox.Text) == false)
            {
                StatusText.Text = "Current Status: OTP does not match";
            }
            else
            {
                User user = new User
                {
                    ID = EncodeSha256(AccountBox.Text),
                    Username = AccountBox.Text,
                    Email = EmailBox.Text,
                    Password = EncodeSha256(PasswordBox.Text),
                    ELO = 400
                };
                var find_user = Client.Get(@"Users/" + EncodeSha256(AccountBox.Text));
                if (find_user != null)
                {
                    SetResponse response = await Client.SetAsync(@"Users/" + EncodeSha256(AccountBox.Text), user);
                    if (response != null)
                    {
                        timer.Interval = 1000;
                        timer.Tick += new EventHandler(time_Tick);
                        timer.Start();
                        StatusText.Text = "Current Status: Registration Successful" + Environment.NewLine + "Redirecting to login page in " + Counter.ToString() + "seconds";
                    }
                    else
                    {
                        StatusText.Text = "Current Status: Registration Failed";
                    }
                    
                }
                else
                {
                    StatusText.Text = "Current Status: Username already exists";
                }
            }
        }

        private string EncodeSha256(string input)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] inputHashByte = SHA256.Create().ComputeHash(inputBytes);
            string result = BitConverter.ToString(inputHashByte).Replace("-", string.Empty).ToLower();
            return result;
        }

        void time_Tick(object sender, EventArgs e)
        {
            Counter--;

            if (Counter == 0)
            {
                timer.Stop();
                this.Close();
            }
            StatusText.Text = "Current Status: Registration Successful. Redirecting to login page in " + Counter.ToString() + " seconds";
        }

        private void OTPButton_Click(object sender, EventArgs e)
        {
            OTP = random.Next(100000, 999999);
            var fromAddress = new MailAddress("listtodo012@gmail.com");
            var toAddress = new MailAddress(EmailBox.Text);
            const string fromPassword = "mbryfkhizpbantuk";
            const string subject = "OTP Verification for new users";
            string body = "Hello user. Gladly welcome you to journey to battle of chess. Your OTP is " + OTP.ToString();
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
            StatusText.Text = "Current Status: OTP sent to your email";
        }
    }
}
