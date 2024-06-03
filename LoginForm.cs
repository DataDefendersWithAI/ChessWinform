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
using Newtonsoft.Json;
using ChessAI_Bck;
namespace winform_chat
{
    public partial class LoginForm : Form
    {

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "RZxEKkX6ffq8XZgw9p0jbPYhqLYXQOeH1FIcmGIa",
            BasePath = "https://chess-database-a25f7-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };
        IFirebaseClient Client;
        public LoginForm()
        {
            InitializeComponent();
          //  AccountBox.Text = "Null";
           // PasswordBox.Text = "p1c0CTFp4s$%2255";
           // PasswordBox.PasswordChar = '*';
           // PasswordBox.UseSystemPasswordChar = true;
        }

        private void AccountBox_Enter(object sender, EventArgs e)
        {
            if (AccountBox.Text == "Username")
            {
                AccountBox.Text = "";
                AccountBox.ForeColor = Color.Black;
            }

        }

        private void AccountBox_Leave(object sender, EventArgs e)
        {
            if (AccountBox.Text == "")
            {
                AccountBox.Text = "Username";
                AccountBox.ForeColor = Color.Silver;
            }
        }

        private void PasswordBox_Enter(object sender, EventArgs e)
        {
            if (PasswordBox.Text == "Password")
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
                PasswordBox.Text = "Password";
                PasswordBox.ForeColor = Color.Silver;
                PasswordBox.PasswordChar = '\0';
                PasswordBox.UseSystemPasswordChar = false;
            }
        }

        private void SignUpLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            RegisterForm newRegister = new RegisterForm();
            newRegister.ShowDialog();
            newRegister = null;
            this.Show();

        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            if (AccountBox.Text == "Username" || PasswordBox.Text == "Password")
            {
                StatusText.Text = "Current Status: Please enter username and password";
            }
            else
            {
                var searching_user = Client.Get(@"Users/" + EncodeSha256(AccountBox.Text));
                var temp = EncodeSha256(AccountBox.Text);
                var find_user = JsonConvert.DeserializeObject<User>(searching_user.Body.ToString());

                if (find_user != null && find_user.Username == AccountBox.Text && find_user.Password == EncodeSha256(PasswordBox.Text))
                {
                    StatusText.Text = "Current Status: Login successful";

                    User playerUser = new LoadUserData().GetUserData(AccountBox.Text);
                    if (playerUser == null)
                    {
                        playerUser = new User(username: "ELPlay" + new Random().Next(999, 9999), elo: 400);
                    }
                    if (playerUser.ELO <= 0)
                    {
                        playerUser.ELO = 400;

                    }
                    this.Hide();
                    MainScreen newMain = new MainScreen(playerUser);
                    newMain.ShowDialog();
                    if (newMain.isLoggedOut == true && newMain.IsDisposed == true)
                    {
                        this.Show();
                    }
                }
                else
                {
                    StatusText.Text = "Current Status: Wrong username or password";
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

        private void LoginForm_Load(object sender, EventArgs e)
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
            this.Show();
        }

        private void ForgetPasswordLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            ForgetPasswordForm newForget = new ForgetPasswordForm();
            newForget.ShowDialog();
            newForget = null;
            this.Show();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}