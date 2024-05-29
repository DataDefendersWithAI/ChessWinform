using ChessAI_Bck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winform_chat
{
    internal class User
    {
        public string ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public int ELO { get; set; }

        
        public List<PGNLog> MatchHistory = new List<PGNLog>();

        public bool AddMatch(PGNLog match)
        {
            MatchHistory.Add(match);
            return true;
        }
    }
}
