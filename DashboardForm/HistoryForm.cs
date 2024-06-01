using ChessAI_Bck;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace winform_chat.DashboardForm
{
    public partial class HistoryForm : Form
    {
        private User playerUser;
        private List<PGNLog> pgnLogs;
        public HistoryForm(User pUser)
        {
            InitializeComponent();
            playerUser = pUser == null ? new User(username: "NotFound" + new Random().Next(999, 9999), elo: 404): pUser;
            pgnLogs = playerUser.MatchHistory;
            Load += HistoryForm_Load;
            listBoxHistory.SelectedIndexChanged += listBoxHistory_SelectedIndexChanged;
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            listBoxHistory.DrawMode = DrawMode.OwnerDrawFixed;
            listBoxHistory.ItemHeight = 50;
            listBoxHistory.DrawMode = DrawMode.OwnerDrawFixed;
            listBoxHistory.DrawItem += ListBoxHistory_DrawItem;


            listBoxHistory.Items.AddRange(pgnLogs.ToArray());
            // Example data for testing
            listBoxHistory.Items.Add(new PGNLog
            {
                ID = "1",
                Date = "2024-06-01",
                White = "Null",
                Black = "Player B",
                Result = "1-0",
                WhiteELO = 2500,
                BlackELO = 2450,
                TimeControl = "90+30",
                Termination = "Normal",
                PGN = "1. e4 e5 2. Nf3 Nc6 3. Bb5 a6 ..."
            });
            listBoxHistory.Items.Add(new PGNLog
            {
                ID = "1",
                Date = "2024-06-01",
                White = "Player A",
                Black = "Null",
                Result = "1-0",
                WhiteELO = 2500,
                BlackELO = 2450,
                TimeControl = "90+30",
                Termination = "Normal",
                PGN = "1. e4 e5 2. Nf3 Nc6 3. Bb5 a6 ..."
            });
        }

        private void ListBoxHistory_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            var item = (PGNLog)listBoxHistory.Items[e.Index];
            // Alternate row color
            Color backColor = Color.LightGray;

            // Override background color based on game result
            if (item.Black == playerUser.Username)
            {
                if (item.Result == "1-0") // if Black (user) wins
                {
                    backColor = Color.PaleGreen;
                }
                else if (item.Result == "0-1") // if Black (user) loses
                {
                    backColor = Color.PaleVioletRed;
                }
            }

            if (item.White == playerUser.Username)
            {
                if (item.Result == "1-0") // if White (user) wins
                {
                    backColor = Color.PaleGreen;
                }
                else if (item.Result == "0-1") // if White (user) loses
                {
                    backColor = Color.PaleVioletRed;
                }
            }

            // Change background color if the item is selected
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                backColor = Color.LightBlue;
            }

            using (SolidBrush backgroundBrush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
            }

            var graphics = e.Graphics;
            var bounds = e.Bounds;

            // Draw the border
            //graphics.DrawRectangle(Pens.Black, bounds.Left, bounds.Top, bounds.Width - 1, bounds.Height - 1);

            // Draw the square and White player name
            var whiteSquareColor = Brushes.White;
            var whiteName = $"{item.White} [{item.WhiteELO}]";
            var whiteNameFont = new Font("Arial", 10, FontStyle.Bold);
            var whiteNameBrush = Brushes.Black;
            graphics.FillRectangle(whiteSquareColor, bounds.Left + 10, bounds.Top + 5, 13, 13);
            graphics.DrawString(whiteName, whiteNameFont, whiteNameBrush, bounds.Left + 25, bounds.Top + 5);

            // Draw the square and Black player name
            var blackSquareColor = Brushes.Black;
            var blackName = $"{item.Black} [{item.BlackELO}]";
            var blackNameFont = new Font("Arial", 10, FontStyle.Bold);
            var blackNameBrush = Brushes.Black;
            graphics.FillRectangle(blackSquareColor, bounds.Left + 10, bounds.Top + 25, 13, 13);
            graphics.DrawString(blackName, blackNameFont, blackNameBrush, bounds.Left + 25, bounds.Top + 25);

            var res = item.Result.Split('-');
            // Draw the result for White
            var resultWhite = res[0];
            var resultWhiteFont = new Font("Arial", 10, FontStyle.Bold);
            var resultWhiteBrush = res[0] == "1" ? Brushes.Green : (res[0] == "1/2" ? Brushes.Gray : Brushes.Red);
            graphics.DrawString(resultWhite, resultWhiteFont, resultWhiteBrush, bounds.Left + 180, bounds.Top + 5);

            // Draw the result for Black
            var resultBlack = res[1];
            var resultBlackFont = new Font("Arial", 10, FontStyle.Bold);
            var resultBlackBrush = res[1] == "1" ? Brushes.Green : (res[1] == "1/2" ? Brushes.Gray : Brushes.Red);
            graphics.DrawString(resultBlack, resultBlackFont, resultBlackBrush, bounds.Left + 180, bounds.Top + 25);


            // Draw the game date
            var gameDate = item.Date;
            var gameDateFont = new Font("Arial", 10, FontStyle.Regular);
            var gameDateBrush = Brushes.Gray;
            graphics.DrawString(gameDate, gameDateFont, gameDateBrush, bounds.Left + 300, bounds.Top + 5);

            // Draw the number of moves
            var moves = $"{item.PGN.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length / 2} moves";
            var movesFont = new Font("Arial", 10, FontStyle.Regular);
            var movesBrush = Brushes.Black;
            graphics.DrawString(moves, movesFont, movesBrush, bounds.Left + 400, bounds.Top + 25);

            // Draw the time control
            var timeControl = item.TimeControl;
            var timeControlFont = new Font("Arial", 10, FontStyle.Regular);
            var timeControlBrush = Brushes.Black;
            graphics.DrawString(timeControl, timeControlFont, timeControlBrush, bounds.Left + 400, bounds.Top + 5);





            e.DrawFocusRectangle();
        }

        // Selected the list item then render it on the right side
        private void listBoxHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxHistory.SelectedIndex < 0) return;

            var item = (PGNLog)listBoxHistory.SelectedItem;
            var pgn = item.PGN;
            var result = item.Result;
            var white = item.White;
            var black = item.Black;
            var whiteElo = item.WhiteELO;
            var blackElo = item.BlackELO;
            var timeControl = item.TimeControl;
            var termination = item.Termination;
            var date = item.Date;

            var moves = pgn.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var movesCount = moves.Length / 2;

            var resultColor = result == "1-0" ? Color.Green : (result == "0-1" ? Color.Red : Color.Gray);

            var whiteText = $"{white} [{whiteElo}]";
            var blackText = $"{black} [{blackElo}]";

            var dateText = date;

            WhiteSide.Text = whiteText;
            BlackSide.Text = blackText;
            gameResult.Text = result;
            gameDate.Text ="Date: "+ dateText;
            gameTermination.Text = termination;

            richTextBoxPGN.Text = pgn;
        }
    }
}
