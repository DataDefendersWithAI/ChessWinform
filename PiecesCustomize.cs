using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessAI
{
    internal class PiecesCustomize
    {
        public Bitmap mapFromSANToBitmap(Graphics g,  char SAN , bool isWhite)
        {
            switch (SAN)
            {
                case 'p':
                    return new Pawn().GetBitmap(g,isWhite);
                case 'r':
                    return new Rook().GetBitmap(g, isWhite);
                case 'n':
                    return new Knight().GetBitmap(g, isWhite);
                case 'b':
                    return new Bishop().GetBitmap(g, isWhite);
                case 'q':
                    return new Queen().GetBitmap(g, isWhite);
                case 'k':
                    return new King().GetBitmap(g, isWhite);
                default:
                    return new Pawn().GetBitmap(g, isWhite);
            }
        }

        class Pawn : PiecesCustomize
        {
            public Bitmap GetBitmap(Graphics g, bool White)
            {
                var img = White ? Properties.Resources.w_pawn_png_shadow_1024px
                               : @Properties.Resources.b_pawn_png_shadow_1024px;
                return img;
            }

        }
        class Rook : PiecesCustomize
        {
            public Bitmap GetBitmap(Graphics g, bool White)
            {
                var img = White ? Properties.Resources.w_rook_png_shadow_1024px
                               : @Properties.Resources.b_rook_png_shadow_1024px;
                return img;
            }

        }
        class Knight : PiecesCustomize
        {
            public Bitmap GetBitmap(Graphics g, bool White)
            {
                var img = White ? Properties.Resources.w_knight_png_shadow_1024px
                               : @Properties.Resources.b_knight_png_shadow_1024px;
                return img;
            }

        }
        class Bishop : PiecesCustomize
        {
            public Bitmap GetBitmap(Graphics g, bool White)
            {
                var img = White ? Properties.Resources.w_bishop_png_shadow_1024px
                               : @Properties.Resources.b_bishop_png_shadow_1024px;
                return img;
            }

        }
        class Queen : PiecesCustomize
        {
            public Bitmap GetBitmap(Graphics g, bool White)
            {
                var img = White ? Properties.Resources.w_queen_png_shadow_1024px
                               : @Properties.Resources.b_queen_png_shadow_1024px;
                return img;
            }

        }
        class King : PiecesCustomize
        {
            public Bitmap GetBitmap(Graphics g, bool White)
            {
                var img = White ? Properties.Resources.w_king_png_shadow_1024px
                               : @Properties.Resources.b_king_png_shadow_1024px;
                return img;
            }

        }

    }
}
