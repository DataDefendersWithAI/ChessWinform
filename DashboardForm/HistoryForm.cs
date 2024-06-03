using Chess;
using ChessAI;
using ChessAI_Bck;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace winform_chat.DashboardForm
{
    public partial class HistoryForm : Form
    {

        private User playerUser;
        private List<PGNLog> pgnLogs;
        private ChessAIClient client;
        private Color WinColor = Color.PaleGreen;
        private Color LoseColor = Color.LightCoral; 
        private Color DrawColor = Color.LightGray;

        public HistoryForm(User pUser)
        {
            InitializeComponent();
            playerUser = pUser == null ? new User(username: "NotFound" + new Random().Next(999, 9999), elo: 404) : pUser;
            pgnLogs = playerUser.MatchHistory;


            WhiteSide.Text = "";
            BlackSide.Text = "";
            gameResult.Text = "";
            gameDate.Text = "";
            gameTermination.Text = "";
            richTextBoxPGN.Text = "";
            wside.BackColor = Color.Transparent;
            bside.BackColor = Color.Transparent;


            Load += HistoryForm_Load;
            listBoxHistory.SelectedIndexChanged += listBoxHistory_SelectedIndexChanged;
        }
        public void UpdateFomrUI()
        {
            Debug.WriteLine("[HS] History UI updating...");
            Task.Run(() =>
            {
                playerUser = new LoadUserData().GetUserData(playerUser.Username); // update new data
            });
            pgnLogs = playerUser.MatchHistory;
            listBoxHistory.Items.Clear();
            listBoxHistory.Items.AddRange(pgnLogs.ToArray());
            if (listBoxHistory.Items.Count > 0)
                listBoxHistory.SelectedIndex = 0;
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            listBoxHistory.DrawMode = DrawMode.OwnerDrawFixed;
            listBoxHistory.ItemHeight = 60;
            listBoxHistory.DrawMode = DrawMode.OwnerDrawFixed;
            listBoxHistory.DrawItem += ListBoxHistory_DrawItem;


            listBoxHistory.Items.AddRange(pgnLogs.ToArray());
            if (listBoxHistory.Items.Count > 0)
                listBoxHistory.SelectedIndex = 0;
        }

        private void ListBoxHistory_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                if (e.Index < 0) return;

                var item = (PGNLog)listBoxHistory.Items[e.Index];

                if (item == null) return;
                if (item.Result == "" || item.Result.Contains("-"))
                {
                    item.Result = item.PGN.Contains("1/2-1/2") ? "1/2 : 1/2" : item.PGN.Contains("1-0") ? "1 : 0" : item.PGN.Contains("0-1") ? "0 : 1" : "1/2 : 1/2";
                    item.Termination = item.PGN.Contains("1/2-1/2") ? "Draw" : item.PGN.Contains("1-0") ? "White Wins" : item.PGN.Contains("0-1") ? "Black Wins" : "Draw";
                }

                // Alternate row color
                Color backColor = DrawColor;

                // Override background color based on game result
                if (item.Black == playerUser.Username)
                {
                    if (item.Result == "0 : 1") // if Black (user) wins
                    {
                        backColor = WinColor;
                    }
                    else if (item.Result == "1 : 0") // if Black (user) loses
                    {
                        backColor = LoseColor;
                    }
                }

                if (item.White == playerUser.Username)
                {
                    if (item.Result == "1 : 0") // if White (user) wins
                    {
                        backColor = WinColor;
                    }
                    else if (item.Result == "0 : 1") // if White (user) loses
                    {
                        backColor = LoseColor;
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
                var bTop = bounds.Top + 5;
                var bLeft = bounds.Left + 5;

                // Draw the border
                //graphics.DrawRectangle(Pens.Black, bLeft, bounds.Top, bounds.Width - 1, bounds.Height - 1);

                // Draw the square and White player name
                var whiteSquareColor = Brushes.White;
                var whiteName = $"{item.White} [{item.WhiteELO}]";
                var whiteNameFont = new Font("Arial", 12, FontStyle.Bold);
                var whiteNameBrush = Brushes.Black;
                graphics.FillRectangle(whiteSquareColor, bLeft + 10, bTop + 5, 13, 13);
                graphics.DrawString(whiteName, whiteNameFont, whiteNameBrush, bLeft + 25, bTop + 5);

                // Draw the square and Black player name
                var blackSquareColor = Brushes.Black;
                var blackName = $"{item.Black} [{item.BlackELO}]";
                var blackNameFont = new Font("Arial", 12, FontStyle.Bold);
                var blackNameBrush = Brushes.Black;
                graphics.FillRectangle(blackSquareColor, bLeft + 10, bTop + 25, 13, 13);
                graphics.DrawString(blackName, blackNameFont, blackNameBrush, bLeft + 25, bTop + 25);

                var res = item.Result.Replace(" ", "").Split(':');

                // Draw the result for White
                var resultWhite = res[0];
                var resultWhiteFont = new Font("Arial", 10, FontStyle.Bold);
                var resultWhiteBrush = res[0] == "1" ? Brushes.Green : (res[0] == "1/2" ? Brushes.Gray : Brushes.Red);
                graphics.DrawString(resultWhite, resultWhiteFont, resultWhiteBrush, bLeft + 180, bTop + 5);

                // Draw the result for Black
                var resultBlack = res[1];
                var resultBlackFont = new Font("Arial", 10, FontStyle.Bold);
                var resultBlackBrush = res[1] == "1" ? Brushes.Green : (res[1] == "1/2" ? Brushes.Gray : Brushes.Red);
                graphics.DrawString(resultBlack, resultBlackFont, resultBlackBrush, bLeft + 180, bTop + 25);


                // Draw the game date
                var gameDate = item.Date;
                var gameDateFont = new Font("Arial", 10, FontStyle.Regular);
                var gameDateBrush = Brushes.Black;
                graphics.DrawString(gameDate, gameDateFont, gameDateBrush, bLeft + 250, bTop + 5);

                // Draw the number of moves
                var moves = $"{item.PGN.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length / 2} moves";
                var movesFont = new Font("Arial", 10, FontStyle.Regular);
                var movesBrush = Brushes.Black;
                graphics.DrawString(moves, movesFont, movesBrush, bLeft + 350, bTop + 25);

                // Draw the time control
                var timeControl = item.TimeControl;
                var timeControlFont = new Font("Arial", 10, FontStyle.Regular);
                var timeControlBrush = Brushes.Black;
                graphics.DrawString(timeControl, timeControlFont, timeControlBrush, bLeft + 350, bTop + 5);

                e.DrawFocusRectangle();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
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

            var whiteText = $"{white} [{whiteElo}]";
            var blackText = $"{black} [{blackElo}]";

            var dateText = date;

            WhiteSide.Text = whiteText;
            BlackSide.Text = blackText;
            gameResult.Text = result;
            gameDate.Text = "Date: " + dateText;
            gameTermination.Text = termination;
            bside.BackColor = Color.Transparent;
            wside.BackColor = Color.Transparent;

            if (result == "1 : 0")
            {
                wside.BackColor = WinColor;
            }
            else if (result == "0 : 1")
            {
                bside.BackColor = WinColor;
            }

            panel1.BackColor = DrawColor;
            if (white == playerUser.Username && result == "1 : 0")
            {
                panel1.BackColor = WinColor;
            }
            else if (white == playerUser.Username && result == "0 : 1")
            {
                panel1.BackColor = LoseColor;
            }

            if (black == playerUser.Username && result == "0 : 1")
            {
                panel1.BackColor = WinColor;
            }
            else if (black == playerUser.Username && result == "1 : 0")
            {
                panel1.BackColor = LoseColor;
            }

            richTextBoxPGN.Text = pgn;
        }

        private void cpyBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // copy the PGN to clipboard
                Clipboard.SetText(richTextBoxPGN.Text + " ");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void rvwBtn_Click(object sender, EventArgs e)
        {
            if (client != null) // clean up
            {
                client.Close();
                client.Dispose();
                client = null;
            }
           
            var item = (PGNLog)listBoxHistory.SelectedItem;
            var pgn = item.PGN;
            if (item.White == playerUser.Username)
            {
                User p = new User(username: item.White, elo: item.WhiteELO);
                User o = new User(username: item.Black, elo: item.BlackELO);
                client = new ChessAIClient(isRvw: true, pUser: p , oUser:o, setSide:PieceColor.White);
            }
            else
            {
                User p = new User(username: item.Black, elo: item.BlackELO);
                User o = new User(username: item.White, elo: item.WhiteELO);
                client = new ChessAIClient(isRvw: true, pUser: p, oUser: o, setSide:PieceColor.Black);
            }
            client.LoadBoardFromPgn(pgn);
            client.Show();
        }
    }
}
