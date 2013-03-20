using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostVikingGame
{
    class ConsoleRenderer
    {
        public int FieldRows { get; private set; }
        public int FieldCols { get; private set; }
        public char[,] Field { get; private set; }

        // define Field that will 
        public ConsoleRenderer(int fieldRows, int fieldCols)
        {
            this.Field = new char[fieldRows, fieldCols];
            this.FieldRows = fieldRows;
            this.FieldCols = fieldCols;
        }

        //Clear field or initialize it.
        public void ClearField()
        {
            for (int row = 0; row < this.FieldRows; row++)
            {
                for (int col = 0; col < this.FieldCols; col++)
                {
                    this.Field[row, col] = ' ';
                }
            }
        }

        //Add GameObjects to Field
        public void AddToField(List<GameObject> objList)
        {
            for (int i = 0; i < objList.Count; i++)
            {
                bool onField = false;

                // Find start and end position of GameObject on Field
                int startRow = objList[i].TopLeft.Row;
                int startCol = objList[i].TopLeft.Col;
                int endRow = objList[i].TopLeft.Row + objList[i].Height;
                int endCol = objList[i].TopLeft.Col + objList[i].Width;
                if (startRow < 0)
                {
                    startRow = 0;
                }
                if (startCol < 0)
                {
                    startCol = 0;
                }
                if (endRow > this.FieldRows)
                {
                    endRow = this.FieldRows;
                }
                if (endCol > this.FieldCols)
                {
                    endCol = this.FieldCols;
                }

                // Fill object in Field
                for (int row = startRow; row < endRow; row++)
                {
                    for (int col = startCol; col < endCol; col++)
                    {
                        this.Field[row, col] = objList[i].Texture[row - objList[i].TopLeft.Row, col - objList[i].TopLeft.Col];

                        // Check that there is part of object still exist on screen
                        onField = true;
                    }
                }

                // When object is outside of screen I mark it as Destroyed - Krasi
                if (!onField)
                {
                    objList[i].IsDestroyed = true;
                }   
            }
        }

        //Print Score
        public void PrintScore(int score)
        {
            Console.SetCursorPosition(55, 5);
            Console.Write("SCORE: {0}",score);
            Console.SetCursorPosition(0, 28);
            Console.Write(" ");
        }


        //Print Game Field on Console
        public void PrintField()
        {
            Console.SetCursorPosition(0, 0);
            StringBuilder fieldForPrint = new StringBuilder();

            for (int row = 0; row < this.FieldRows; row++)
            {
                for (int col = 0; col < this.FieldCols; col++)
                {
                    fieldForPrint.Append(this.Field[row, col]);
                }
                fieldForPrint.Append(Environment.NewLine);
            }

            Console.WriteLine(fieldForPrint.ToString());

        }
    }
}
