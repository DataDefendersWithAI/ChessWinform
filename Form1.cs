using Chess;
using System.Diagnostics;
namespace ChessAI
{
    public partial class Form1 : Form
    {
        BoardRenderer boardRenderer;
        ChessBoard chessBoard;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true; // remove the small blinking when Invalidate()

            chessBoard = new ChessBoard(); // init new board
            boardRenderer = new BoardRenderer(); // init new renderer

            this.Size = new Size(1000, 800); // add minimun offset is 75 and maybe some space
        }
        public void boardPaint(object sender, PaintEventArgs e) // update continously
        {
            boardRenderer.DrawBoard(e.Graphics, chessBoard, 600, isDebug: true , isWhite: true); // draw the board
            richTextBox1.Text = chessBoard.ToPgn(); // show the moves       
        }

        public void boardClick(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("X: " + e.X + " Y: " + e.Y);
            chessBoard = boardRenderer.onClicked(new Position(e.X, e.Y), chessBoard , isNormalized: false); // handle the click
            Invalidate(); // redraw whole screen
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var moves = textBox1.Text.Split(' ');
            foreach (var m in moves)
            {
                chessBoard = boardRenderer.onClicked(new Position(m), chessBoard, isNormalized: true); // handle the click
                Invalidate(); // redraw whole screen
            }         
        }
    }
}
