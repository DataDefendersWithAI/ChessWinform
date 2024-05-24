
using System.Text;
using FireSharp.Config;
using FireSharp.Interfaces;
using System.Security.Cryptography;

namespace LoginForm.DashboardForm
{
    public partial class ProfileForm : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "RZxEKkX6ffq8XZgw9p0jbPYhqLYXQOeH1FIcmGIa",
            BasePath = "https://chess-database-a25f7-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };
        IFirebaseClient Client;
        public ProfileForm()
        {
            InitializeComponent();
        }

        private void ProfileForm_Load(object sender, EventArgs e)
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

        private void CurrAccountBox_Enter(object sender, EventArgs e)
        {
            if (CurrAccountBox.Text == "Enter current username")
            {
                CurrAccountBox.Text = "";
                CurrAccountBox.ForeColor = Color.Black;
            }

        }

        private void CurrAccountBox_Leave(object sender, EventArgs e)
        {
            if (CurrAccountBox.Text == "")
            {
                CurrAccountBox.Text = "Enter current username";
                CurrAccountBox.ForeColor = Color.Gray;
            }
        }

        private void NewAccountBox_Enter(object sender, EventArgs e)
        {
            if (NewAccountBox.Text == "Enter new username")
            {
                NewAccountBox.Text = "";
                NewAccountBox.ForeColor = Color.Black;
            }
        }

        private void NewAccountBox_Leave(object sender, EventArgs e)
        {
            if (NewAccountBox.Text == "")
            {
                NewAccountBox.Text = "Enter new username";
                NewAccountBox.ForeColor = Color.Gray;
            }
        }

        private void AccountBox_Enter(object sender, EventArgs e)
        {
            if (CurrAccountBox.Text == "Enter username")
            {
                CurrAccountBox.Text = "";
                CurrAccountBox.ForeColor = Color.Black;
            }
        }

        private void AccountBox_Leave(object sender, EventArgs e)
        {
            if (CurrAccountBox.Text == "")
            {
                CurrAccountBox.Text = "Enter username";
                CurrAccountBox.ForeColor = Color.Gray;
            }
        }

        private void PasswordBox_Enter(object sender, EventArgs e)
        {
            if (PasswordBox.Text == "Enter new password")
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
                PasswordBox.Text = "Enter new password";
                PasswordBox.ForeColor = Color.Gray;
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
                ReTypePasswordBox.ForeColor = Color.Gray;
                ReTypePasswordBox.PasswordChar = '\0';
                ReTypePasswordBox.UseSystemPasswordChar = false;
            }
        }

        private string EncodeSha256(string input)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] inputHashByte = SHA256.Create().ComputeHash(inputBytes);
            string result = BitConverter.ToString(inputHashByte).Replace("-", string.Empty).ToLower();
            return result;
        }
        private async void UpdateUserButton_Click(object sender, EventArgs e)
        {
            if (CurrAccountBox.Text == "Enter current username" || NewAccountBox.Text == "Enter new username")
            {
                StatusText.Text = "Current Status: Please fill in all fields";
            }
            else
            {
                var find_user = Client.Get("Users/" + EncodeSha256(CurrAccountBox.Text));
                var user = find_user.ResultAs<User>();

                var update_user = new User
                {
                    ID = EncodeSha256(NewAccountBox.Text),
                    Username = NewAccountBox.Text,
                    Email = user.Email,
                    Password = user.Password
                };
                var delete_user = await Client.DeleteAsync("Users/" + EncodeSha256(CurrAccountBox.Text));
                var set = await Client.SetAsync("Users/" + EncodeSha256(NewAccountBox.Text), update_user);
                StatusText.Text = "Current Status: User Updated";
                CurrAccountBox.Text = "Enter current username";
                CurrAccountBox.ForeColor = Color.Gray;
                NewAccountBox.Text = "Enter new username";
                NewAccountBox.ForeColor = Color.Gray;
            }
        }

        private void UpdatePassButton_Click(object sender, EventArgs e)
        {
            if (CurrAccountBox.Text == "Enter username" || PasswordBox.Text == "Enter password" || ReTypePasswordBox.Text == "Retype password")
            {
                StatusText.Text = "Current Status: Please fill in all fields";
            }
            else if (PasswordBox.Text != ReTypePasswordBox.Text)
            {
                StatusText.Text = "Current Status: Passwords do not match";
            }
            else
            {
                var find_user = Client.Get("Users/" + EncodeSha256(CurrAccountBox.Text));
                var user = find_user.ResultAs<User>();

                var update_user = new User
                {
                    ID = EncodeSha256(CurrAccountBox.Text),
                    Username = user.Username,
                    Email = user.Email,
                    Password = EncodeSha256(PasswordBox.Text)
                };
                var set = Client.SetAsync("Users/" + EncodeSha256(CurrAccountBox.Text), update_user);
                StatusText.Text = "Current Status: Password Updated";
                CurrAccountBox.Text = "Enter username";
                CurrAccountBox.ForeColor = Color.Gray;
                PasswordBox.Text = "Enter password";
                PasswordBox.ForeColor = Color.Gray;
                ReTypePasswordBox.Text = "Retype password";
                ReTypePasswordBox.ForeColor = Color.Gray;
            }
        }
    }
}
