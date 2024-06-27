using System;

namespace CheckersHafifa 
{
    interface IBoard 
    {
        void Initialize();
        void Display();
        bool MovePiece(Player player, int startX, int startY, int endX, int endY);
    }
}