using System;

namespace CheckersHafifa 
{
    interface IBoard 
    {
        void InitializeBoard();
        void Display();
        bool MovePiece(Player player, int startX, int startY, int endX, int endY);
    }
}