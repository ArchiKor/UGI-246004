using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task08._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите позицию белого короля:");
            var whiteKingPosition = Console.ReadLine();
            Console.WriteLine("Введите позицию чёрного коня:");
            var blackKnightPosition = Console.ReadLine();

            if (whiteKingPosition == blackKnightPosition)
            {
                Console.WriteLine("Король и конь не могут стоять на одной клетке.");
                return;
            }

            int whiteKingHorizontal, whiteKingVertical;
            int blackKnightHorizontal, blackKnightVertical;

            DecodePosition(whiteKingPosition, out whiteKingVertical, out whiteKingHorizontal);
            DecodePosition(blackKnightPosition, out blackKnightVertical, out blackKnightHorizontal);

            if (whiteKingHorizontal < 1 || whiteKingHorizontal > 8 || whiteKingVertical < 1 || whiteKingVertical > 8 ||
                blackKnightHorizontal < 1 || blackKnightHorizontal > 8 || blackKnightVertical < 1 || blackKnightVertical > 8)
            {
                Console.WriteLine("Позиции фигур введены некорректно.");
                return;
            }

            if (IsUnderStrikeByWhiteKing(blackKnightPosition, whiteKingPosition))
                Console.WriteLine("Конь находится под боем короля.");
            else if (IsUnderStrikeByBlackKnight(whiteKingPosition, blackKnightPosition))
                Console.WriteLine("Король находится под боем коня.");
            else
                Console.WriteLine("Фигуры не бьют друг друга.");
        }

        static void DecodePosition(string position, out int vert, out int hor)
        {
            vert = (int)position[0] - 0x60;
            hor = int.Parse(position.Substring(1).ToString());
        }

        static bool IsUnderStrikeByWhiteKing(string position, string whiteKingPosition)
        {
            int positionVertical, positionHorizontal, whiteKingVertical, whiteKingHorizontal;

            DecodePosition(position, out positionVertical, out positionHorizontal);
            DecodePosition(whiteKingPosition, out whiteKingVertical, out whiteKingHorizontal);

            return Math.Abs(positionVertical - whiteKingVertical) <= 1 && Math.Abs(positionHorizontal - whiteKingHorizontal) <= 1 
                && (Math.Abs(positionVertical - whiteKingVertical) != 0 || Math.Abs(positionHorizontal - whiteKingHorizontal) != 0);
        }

        static bool IsUnderStrikeByBlackKnight(string position, string blackKnightPosition)
        {
            int positionVertical, positionHorizontal, blackKnightVertical, blackKnightHorizontal;

            DecodePosition(position, out positionVertical, out positionHorizontal);
            DecodePosition(blackKnightPosition, out blackKnightVertical, out blackKnightHorizontal);


            return (Math.Abs(positionVertical - blackKnightVertical) == 2 && Math.Abs(positionHorizontal - blackKnightHorizontal) == 1)
                || (Math.Abs(positionVertical - blackKnightVertical) == 1 && Math.Abs(positionHorizontal - blackKnightHorizontal) == 2);
        
    }
    }
}
