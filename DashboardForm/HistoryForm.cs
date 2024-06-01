using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace winform_chat.DashboardForm
{
    public partial class HistoryForm : Form
    {
        private User playerUser;

        public HistoryForm(User pUser)
        {
            InitializeComponent();
            playerUser = pUser ?? new User(username: "NotFound" + new Random().Next(999, 9999), elo: 404);
            Load += HistoryForm_Load;
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            listBoxHistory.DrawMode = DrawMode.OwnerDrawFixed;
            listBoxHistory.ItemHeight = 50;
            listBoxHistory.DrawItem += ListBoxHistory_DrawItem;

            // Sample data
            var gameHistory = new List<HistoryListItem>
            {
                new HistoryListItem("Player1", DateTime.Now.AddDays(-1), "Win", 777, 1200),
                new HistoryListItem("Player2", DateTime.Now.AddDays(-2), "Loss", 786, 1300),
                new HistoryListItem("Player3", DateTime.Now.AddDays(-3), "Draw", 997, 1100)
            };

            listBoxHistory.Items.AddRange(gameHistory.ToArray());
        }

        private void ListBoxHistory_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            var item = (HistoryListItem)listBoxHistory.Items[e.Index];

            e.DrawBackground();
            var graphics = e.Graphics;
            var bounds = e.Bounds;

            // Draw the opponent name
            var opponentName = item.OpponentName;
            var opponentNameFont = new Font("Arial", 10, FontStyle.Bold);
            var opponentNameBrush = Brushes.Black;
            graphics.DrawString(opponentName, opponentNameFont, opponentNameBrush, bounds.Left + 10, bounds.Top + 5);

            // Draw the game date
            var gameDate = item.GameDate.ToShortDateString();
            var gameDateFont = new Font("Arial", 8, FontStyle.Italic);
            var gameDateBrush = Brushes.Gray;
            graphics.DrawString(gameDate, gameDateFont, gameDateBrush, bounds.Left + 10, bounds.Top + 25);

            // Draw the result
            var result = item.Result;
            var resultFont = new Font("Arial", 10, FontStyle.Regular);
            var resultBrush = Brushes.Black;
            graphics.DrawString(result, resultFont, resultBrush, bounds.Left + 200, bounds.Top + 5);

            // Draw the player ELO
            var playerELO = $"Player ELO: {item.PlayerELO}";
            var playerELOFont = new Font("Arial", 8, FontStyle.Regular);
            var playerELOBrush = Brushes.Black;
            graphics.DrawString(playerELO, playerELOFont, playerELOBrush, bounds.Left + 200, bounds.Top + 25);

            // Draw the opponent ELO
            var opponentELO = $"Opponent ELO: {item.OpponentELO}";
            var opponentELOFont = new Font("Arial", 8, FontStyle.Regular);
            var opponentELOBrush = Brushes.Black;
            graphics.DrawString(opponentELO, opponentELOFont, opponentELOBrush, bounds.Left + 300, bounds.Top + 25);

            e.DrawFocusRectangle();
        }
    }
}
