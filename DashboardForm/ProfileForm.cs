﻿
using System.Text;
using FireSharp.Config;
using FireSharp.Interfaces;
using System.Security.Cryptography;
using ChessAI_Bck;
using System.Diagnostics.Eventing.Reader;

namespace winform_chat.DashboardForm
{
    public partial class ProfileForm : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "RZxEKkX6ffq8XZgw9p0jbPYhqLYXQOeH1FIcmGIa",
            BasePath = "https://chess-database-a25f7-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };
        IFirebaseClient Client;
        private User playerUser;
        //Update user event
        private MainScreen ParentForm;
        public ProfileForm(User pUser, MainScreen thisMainScreen = null)
        {
            InitializeComponent();
            if (thisMainScreen != null) ParentForm = thisMainScreen;
            if (pUser != null)
            {
                playerUser = pUser;
            }
            else
            {
                playerUser = new User(username: "NotFound" + new Random().Next(999, 9999), elo: 404);
            }
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
            new SoundFXHandler(null, "", "click");
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
                    Password = user.Password,
                    ELO = user.ELO,
                    MatchHistory = user.MatchHistory
                };
                var exists = await Client.GetAsync("Users/" + EncodeSha256(NewAccountBox.Text));
                if (exists.Body != "null")
                {
                    StatusText.Text = "Current Status: Username already exists";
                    return;
                }
                else
                {
                    if (update_user.MatchHistory.Count > 0)
                    {
                        var opponent = "";
                        foreach (var match in update_user.MatchHistory)
                        {
                            var match_pgn = match.PGN;
                            var match_id = match.ID;    
                            if (match.Black == CurrAccountBox.Text.Trim())
                            {
                                match.Black = NewAccountBox.Text.Trim();
                                match.BlackELO = update_user.ELO;
                                opponent = match.White;
                            }
                            else
                            {
                                match.White = NewAccountBox.Text.Trim();
                                match.WhiteELO = update_user.ELO;
                                opponent = match.Black;
                            }
                            if (match.Result.Contains(CurrAccountBox.Text.Trim())) match.Result = match.Result.Replace(CurrAccountBox.Text.Trim(), NewAccountBox.Text.Trim());
                            if (opponent != "AI")
                            {
                                var update_opponent = await Client.GetAsync("Users/" + EncodeSha256(opponent));
                                var opponent_user = update_opponent.ResultAs<User>();
                                for (int i = 0; i < opponent_user.MatchHistory.Count; i++)
                                {
                                    if (opponent_user.MatchHistory[i].PGN == match_pgn || opponent_user.MatchHistory[i].ID==match_id)
                                    {
                                        opponent_user.MatchHistory[i] = match;
                                        break;
                                    }
                                }
                                var set_opponent = await Client.SetAsync("Users/" + EncodeSha256(opponent), opponent_user);
                            }
                           
                        }
                    }
                    
                    var delete_user = await Client.DeleteAsync("Users/" + EncodeSha256(CurrAccountBox.Text));
                    var set_user = await Client.SetAsync("Users/" + EncodeSha256(NewAccountBox.Text), update_user);
                    StatusText.Text = "Current Status: User Updated";
                    CurrAccountBox.Text = "Enter current username";
                    CurrAccountBox.ForeColor = Color.Gray;
                    NewAccountBox.Text = "Enter new username";
                    NewAccountBox.ForeColor = Color.Gray;
                    ParentForm.playerUser = update_user;
                }
            }
        }

        private void UpdatePassButton_Click(object sender, EventArgs e)
        {
            new SoundFXHandler(null, "", "click");
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
                    Password = EncodeSha256(PasswordBox.Text),
                    ELO = user.ELO,
                    MatchHistory = user.MatchHistory
                };
                var set = Client.SetAsync("Users/" + EncodeSha256(CurrAccountBox.Text), update_user);
                StatusText.Text = "Current Status: Password Updated";
                CurrAccountBox.Text = "Enter username";
                CurrAccountBox.ForeColor = Color.Gray;
                PasswordBox.Text = "Enter password";
                PasswordBox.ForeColor = Color.Gray;
                ReTypePasswordBox.Text = "Retype password";
                ReTypePasswordBox.ForeColor = Color.Gray;
                ParentForm.playerUser = update_user;
            }
        }
    }
}
