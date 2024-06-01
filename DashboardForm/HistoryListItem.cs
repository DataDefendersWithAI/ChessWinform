using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform_chat.DashboardForm
{
    public partial class HistoryListItem : Form
    {

        public string OpponentName { get; set; }
        public DateTime GameDate { get; set; }
        public string Result { get; set; } // e.g., "Win", "Loss", "Draw"
        public int PlayerELO { get; set; }
        public int OpponentELO { get; set; }

        public HistoryListItem(string opponentName, DateTime gameDate, string result, int playerELO, int opponentELO)
        {
            OpponentName = opponentName;
            GameDate = gameDate;
            Result = result;
            PlayerELO = playerELO;
            OpponentELO = opponentELO;
        }

        public override string ToString()
        {
            return $"{GameDate.ToShortDateString()} - {OpponentName} ({OpponentELO}) - {Result}";
        }
        
    }
}
