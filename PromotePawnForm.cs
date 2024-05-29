using Chess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessAI_Bck
{
    public partial class PromotePawnForm : Form
    {
        public PromotionType SelectedPromotion { get; private set; }

        public PromotePawnForm(PieceColor side)
        {
            InitializeComponent();
            if (side == PieceColor.White)
            {
                QueenButton.ImageKey = "WQueen";
                KnightButton.ImageKey = "WKnight";
                RookButton.ImageKey = "WRook";
                BishopButton.ImageKey = "WBishop";
            }
            else
            {
                QueenButton.ImageKey = "BQueen";
                KnightButton.ImageKey = "BKnight";
                RookButton.ImageKey = "BRook";
                BishopButton.ImageKey = "BBishop";
            }

            QueenButton.Click += (s, e) => { SelectedPromotion = PromotionType.ToQueen; Close(); };
            KnightButton.Click += (s, e) => { SelectedPromotion = PromotionType.ToKnight; Close(); };
            RookButton.Click += (s, e) => { SelectedPromotion = PromotionType.ToRook; Close(); };
            BishopButton.Click += (s, e) => { SelectedPromotion = PromotionType.ToBishop; Close(); };
        }
    }
}
