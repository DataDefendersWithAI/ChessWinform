using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Chess;
using System.Diagnostics;

namespace ChessAI
{
    internal class BoardRenderer
    {
        //========= SETTINGS ========//
        private bool WhiteSide = true; // check if in white side or black side
        private bool ShowOpponentPossiblesMoves = true; // show the possible moves for the opponent
        private bool showTileCoord = false; // show the tile coordinates

        private int edge;

        private Size TileSize;
        private Size Offset; // Offset for the board // now is left top corner

        private int noOfTiles = 8; // 8 for the board and 1 for the labels
        private bool debugMode;

        public static Color BlackTilesColor = Color.LimeGreen;
        public static Color WhiteTilesColor = Color.MintCream;
        public static Color BlackPiecesColor = Color.Black;
        public static Color WhitePiecesColor = Color.White;

        public static class PositionColor
        {
     
            public static Color Path = Color.Turquoise; // possible moves & selected piece
            public static Color Check = Color.Red; // check 
            public static Color NotPath = Color.Salmon; // notPath
            public static Color Special = Color.Violet; // special moves
        }

        private Position selectedPiece;
        private Position pieceMoveTo;


        //========= SETTINGS ========//

        public void DrawBoard(Graphics g, ChessBoard chessBoard, int edgeSet = 800, int offsetX = 75, int offsetY = 75, bool isWhite = true, bool isDebug = false)
        {
            debugMode = isDebug;
            edge = edgeSet;
            TileSize = new Size(edge / noOfTiles, edge / noOfTiles);
            Offset = new Size(offsetX, offsetY);
            WhiteSide = isWhite;

            // Draw tiles and pieces separately for better performance
            DrawTiles(g, chessBoard);
            DrawPieces(g, chessBoard);
        }

        private void DrawTiles(Graphics g, ChessBoard chessBoard)
        {
            bool white = true;
            Brush b;
            Pen pen = new Pen(new SolidBrush(Color.Black), 0);
            var possiblesMoves = (selectedPiece != null) ? chessBoard.GeneratePositions(new Chess.Position(selectedPiece.toSAN())) : [];
            

            for (int i = 0; i < noOfTiles; i++)
            {
                for (int j = 0; j < noOfTiles; j++)
                {
                    // Use a single brush object for different tile colors
                    if (selectedPiece != null &&( possiblesMoves.Contains(new Chess.Position(new Position(i, j).toSAN())) || (selectedPiece.X == i && selectedPiece.Y==j)))
                    {
                        // check if selected piece is the same color as the turn and if the showOpponentPossiblesMoves is true
                        // then the possible moves for the opponent will be shown

                        b = (chessBoard.Turn == chessBoard[selectedPiece.toSAN()].Color) ? new SolidBrush(PositionColor.Path) : (ShowOpponentPossiblesMoves ? new SolidBrush(PositionColor.NotPath): (white ? new SolidBrush(WhiteTilesColor) : new SolidBrush(BlackTilesColor))); 
                        pen = (ShowOpponentPossiblesMoves ? new Pen(new SolidBrush(Color.Black), 2): new Pen(new SolidBrush(Color.Black), 0)) ;
                       
                    }
                    else
                    {
                        b = (white ? new SolidBrush(WhiteTilesColor) : new SolidBrush(BlackTilesColor));
                        pen = new Pen(new SolidBrush(Color.Black), 0);
                    }

                    g.FillRectangle(b, i * TileSize.Width + Offset.Width, j * TileSize.Height + Offset.Height, TileSize.Width, TileSize.Height);
                    g.DrawRectangle(pen, i * TileSize.Width + Offset.Width, j * TileSize.Height + Offset.Height, TileSize.Width, TileSize.Height);


                    if (showTileCoord)
                    {
                        g.DrawString((char)('a' + i) + (noOfTiles - j).ToString(), new Font("Arial", 10), new SolidBrush(Color.Red), i * TileSize.Width + Offset.Width + 5, j * TileSize.Height + Offset.Height + 5);
                    }
                    
                    if (j == noOfTiles - 1)
                    {
                        g.DrawString(((char)('a' + i)).ToString(), new Font("Arial", 13), new SolidBrush(Color.Red), i * TileSize.Width + Offset.Width + TileSize.Width - (float)(TileSize.Width * .7), j * TileSize.Height + Offset.Height + TileSize.Height + (float)(TileSize.Height * .2));
                    }
                    if (i == 0)
                    {
                        g.DrawString((noOfTiles - j).ToString(), new Font("Arial", 13), new SolidBrush(Color.Red), i * TileSize.Width + Offset.Width - (float)(TileSize.Width * .5), j * TileSize.Height + Offset.Height + (float)(TileSize.Height * .2));
                    }
                    


                    // Dispose the brush after use
                    b.Dispose();

                    white = !white;
                }
                white = !white;
            }
        }

        private void DrawPieces(Graphics g, ChessBoard chessBoard)
        {
            Bitmap bitmap;
            for (int i = 0; i < noOfTiles; i++)
            {
                for (int j = 0; j < noOfTiles; j++)
                {
                    // Retrieve the piece once instead of multiple times
                    var piece = chessBoard[new Position(i, j).toSAN()];
                    if (piece != null)
                    {
                        bitmap = new PiecesCustomize().mapFromSANToBitmap(g, piece.ToString()[1], piece.ToString()[0] == 'w');
                        if (bitmap != null)
                        {
                            g.DrawImage(bitmap, i * TileSize.Width + Offset.Width, j * TileSize.Height + Offset.Height, TileSize.Width, TileSize.Height);
                            bitmap.Dispose(); // Dispose the bitmap after use
                        }
                    }
                }
            }
        }

        public static bool IsInBoard(Position p) // check for click if out of the board or not
        {
            return p.X >= 0 && p.Y >= 0 && p.X <= 7 && p.Y <= 7;
        }

        public ChessBoard onClicked(Position clickedPosition, ChessBoard chessBoard, bool isNormalized = false)
        {
            // Check if the game has ended
            if (chessBoard.IsEndGame)
            {
                ResetSelection();
                Debug.WriteLineIf(debugMode, "The game has ended. " + chessBoard.EndGame.WonSide + " won!");
                return chessBoard;
            }

            // Normalize the clicked position if needed
            if (isNormalized == false)
            {
                clickedPosition = NormalizePosition(clickedPosition);
                Debug.WriteLineIf(debugMode, "Normalized position: " + clickedPosition.toSAN());
            }

            // Check if the clicked position is within the board range from (0,0) to (7,7)
            if (!IsInBoard(clickedPosition))
            {
                Debug.WriteLineIf(debugMode, "Clicked position is out of board");
                ResetSelection();
                return chessBoard;
            }

            // If no piece is selected, try to select one
            if (selectedPiece == null)
            {
                if (!SelectPiece(clickedPosition, chessBoard))
                {
                    Debug.WriteLineIf(debugMode, "No piece on clicked position");
                    ResetSelection();
                    return chessBoard;
                }
            }
            else
            {
                // If a piece is already selected, move to the clicked position
                pieceMoveTo = clickedPosition;
                // Change selected piece if the clicked position has a piece of the same color
                if (chessBoard[pieceMoveTo.toSAN()] != null && chessBoard[selectedPiece.toSAN()].Color == chessBoard[pieceMoveTo.toSAN()].Color)
                {
                    Debug.WriteLineIf(debugMode, "Changed selected piece to " + pieceMoveTo.toSAN());
                    selectedPiece = pieceMoveTo;
                    pieceMoveTo = null;
                    return chessBoard;
                }
            }

            // If no position is selected to move to, return
            if (pieceMoveTo == null)
            {
                return chessBoard;
            }

            // If clicked on the same piece, deselect it
            if (pieceMoveTo.Equals(selectedPiece))
            {
                Debug.WriteLineIf(debugMode, "Clicked on the same piece");
                ResetSelection();
                return chessBoard;
            }

            // Validate the move
            if (!IsValidMove(selectedPiece, pieceMoveTo, chessBoard))
            {
                Debug.WriteLineIf(debugMode, "Invalid Move: " + selectedPiece.toSAN() + " to " + pieceMoveTo.toSAN());
                ResetSelection();
                return chessBoard;
            }

            // Execute the move
            chessBoard.Move(new Move(selectedPiece.toSAN(), pieceMoveTo.toSAN()));
            Debug.WriteLineIf(debugMode, "Moved piece from " + selectedPiece.toSAN() + " to " + pieceMoveTo.toSAN());
            Debug.WriteLineIf(debugMode, chessBoard.ToAscii());

            // Reset selection after the move
            ResetSelection();

            return chessBoard;
        }

        private void ResetSelection()
        {
            selectedPiece = null;
            pieceMoveTo = null;
        }

        private Position NormalizePosition(Position position)
        {
            return new Position((position.X - Offset.Width) / TileSize.Width, (position.Y - Offset.Height) / TileSize.Height);
        }

        private bool SelectPiece(Position clickedPosition, ChessBoard chessBoard)
        {
            // Check if there's a piece at the clicked position
            if (chessBoard[clickedPosition.toSAN()] == null)
            {
                return false;
            }

            selectedPiece = clickedPosition;
            Debug.WriteLineIf(debugMode, "Selected piece on " + chessBoard[selectedPiece.toSAN()]);
            return true;
        }

        private bool IsValidMove(Position fromPosition, Position toPosition, ChessBoard chessBoard)
        {
            return chessBoard.IsValidMove(new Move(fromPosition.toSAN(), toPosition.toSAN()));
        }

    }
}
