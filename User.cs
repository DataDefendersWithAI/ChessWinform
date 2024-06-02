using ChessAI_Bck;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winform_chat
{
    public class User
    {
        public string ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public int ELO { get; set; }

        public List<PGNLog> MatchHistory = new List<PGNLog>();
        public User(){ }

        public User( string username, string id = "", string password="", string email = "", int elo= 1)
        {
            ID = id;
            Username = username;
            Password = password;
            Email = email;
            ELO = elo;
        }

        public bool AddMatch(PGNLog match)
        {
            MatchHistory.Add(match);
            return true;
        }

        public bool IsAValidUser()
        {
            if (string.IsNullOrEmpty(ID) || string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Email) || ELO <= 1 )
            {
                Debug.WriteLine("Invalid User");
                return false;
            }
            if (Username.Length < 4 || Password.Length < 4)
            {
                Debug.WriteLine("Invalid User");
                return false;
            }
            if (ELO < 1)
            {
                Debug.WriteLine("Invalid User");
                return false;
            }
            return true;
        }
    }
}
