using System;
using System.Diagnostics;
using System.IO;
using System.Text;

class Algorithm
{
    private static bool[,] field = new bool[500, 500];
    private static Figure[] arrayOfFigures;

    static void Main()
    {
        Stopwatch timer = new Stopwatch();
        timer.Start();
        //Read Input
        arrayOfFigures = ReadInput();

        // Search empty space, Figure by figure and put on field;
        int allPath = 0;
        for (int i = 0; i < arrayOfFigures.Length; i++)
        {
            int path = SearchEmptySpace(arrayOfFigures[i].Row, arrayOfFigures[i].Col,
                arrayOfFigures[i].Type, i);
            allPath += path;
        }

        PrintResult();
        //for (int i = 0; i < 500; i++)
        //{
        //    for (int j = 0; j < 500; j++)
        //    {
        //        if (field[i,j])
        //        {
        //            Console.Write(1);
        //        }
        //        else
        //        {
        //            Console.Write(0);
        //        }
        //    }
        //    Console.WriteLine();
        //}
        //Console.WriteLine("Path= {0}", allPath);
        //Console.WriteLine("Time= {0}",timer.ElapsedMilliseconds);
    }

    private static void PrintResult()
    {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < arrayOfFigures.Length; i++)
        {
            result.Append(arrayOfFigures[i].Row);
            result.Append(' ');
            result.Append(arrayOfFigures[i].Col);
            result.Append(Environment.NewLine);
        }

        Console.Write(result);
    }

    private static int SearchEmptySpace(int rowBase, int colBase, Type type, int element)
    {
        int path = 0;
        // Check if current position is Empty and Put on field
        bool isEmpty = CheckIfEmpty(rowBase, colBase, type);
        if (isEmpty)
        {
            PutOnField(rowBase, colBase, type, element);
        }
        else
        {
            int maxDistance = 150;
            for (int distance = 1; distance < maxDistance; distance++)
            {
                for (int i = 1; i < distance; i++)
                {
                    int rowUpRight = rowBase - i;
                    int colUpRight = colBase + distance - i;
                    isEmpty = CheckIfEmpty(rowUpRight, colUpRight, type);
                    if (isEmpty)
                    {
                        PutOnField(rowUpRight, colUpRight, type, element);
                        path = distance;
                        break;
                    }

                    int rowDownLeft = rowBase + distance - i;
                    int colDownLeft = colBase - i;
                    isEmpty = CheckIfEmpty(rowDownLeft, colDownLeft, type);
                    if (isEmpty)
                    {
                        PutOnField(rowDownLeft, colDownLeft, type, element);
                        path = distance;
                        break;
                    }
                }

                if (isEmpty)
                {
                    break;
                }

                for (int i = 0; i < distance + 1; i++)
                {
                    int rowTopLeft = rowBase - distance + i;
                    int colTopLeft = colBase - i;
                    isEmpty = CheckIfEmpty(rowTopLeft, colTopLeft, type);
                    if (isEmpty)
                    {
                        PutOnField(rowTopLeft, colTopLeft, type, element);
                        path = distance;
                        break;
                    }

                    int rowDownRight = rowBase + distance - i;
                    int colDownRight = colBase + i;
                    isEmpty = CheckIfEmpty(rowDownRight, colDownRight, type);
                    if (isEmpty)
                    {
                        PutOnField(rowDownRight, colDownRight, type, element);
                        path = distance;
                        break;
                    }
                }
                if (isEmpty)
                {
                    break;
                }
            }
        }

        return path;
    }

    private static void PutOnField(int rowBase, int colBase, Type type, int element)
    {
        //Change base position in list
        arrayOfFigures[element].Row = rowBase;
        arrayOfFigures[element].Col = colBase;

        //Put on Field
        switch (type)
        {
            case Type.Ninetile:
                for (int row = rowBase - 1; row <= rowBase + 1; row++)
                {
                    for (int col = colBase - 1; col <= colBase + 1; col++)
                    {
                        field[row, col] = true;
                    }
                }
                break;
            case Type.Plus:
                field[rowBase, colBase] = true;
                field[rowBase + 1, colBase] = true;
                field[rowBase - 1, colBase] = true;
                field[rowBase, colBase + 1] = true;
                field[rowBase, colBase - 1] = true;
                break;
            case Type.Hline:
                field[rowBase, colBase] = true;
                field[rowBase, colBase + 1] = true;
                field[rowBase, colBase - 1] = true;
                break;
            case Type.Vline:
                field[rowBase, colBase] = true;
                field[rowBase + 1, colBase] = true;
                field[rowBase - 1, colBase] = true;
                break;
            case Type.AngleUR:
                field[rowBase, colBase] = true;
                field[rowBase, colBase + 1] = true;
                field[rowBase - 1, colBase] = true;
                break;
            case Type.AngleDR:
                field[rowBase, colBase] = true;
                field[rowBase, colBase + 1] = true;
                field[rowBase + 1, colBase] = true;
                break;
            case Type.AngleDL:
                field[rowBase, colBase] = true;
                field[rowBase, colBase - 1] = true;
                field[rowBase + 1, colBase] = true;
                break;
            case Type.AngleUL:
                field[rowBase, colBase] = true;
                field[rowBase, colBase - 1] = true;
                field[rowBase - 1, colBase] = true;
                break;
            default:
                break;
        }
    }

    private static bool CheckIfEmpty(int rowBase, int colBase, Type type)
    {
        bool isEmpty = true;
        switch (type)
        {
            case Type.Ninetile:
                isEmpty = CheckEmptySpaceForNinetile(rowBase, colBase);
                break;
            case Type.Plus:
                isEmpty = CheckEmptySpaceForPlus(rowBase, colBase);
                break;
            case Type.Hline:
                isEmpty = CheckEmptySpaceForHline(rowBase, colBase);
                break;
            case Type.Vline:
                isEmpty = CheckEmptySpaceForVline(rowBase, colBase);
                break;
            case Type.AngleUR:
                isEmpty = CheckEmptySpaceForAngleUR(rowBase, colBase);
                break;
            case Type.AngleDR:
                isEmpty = CheckEmptySpaceForAngleDR(rowBase, colBase);
                break;
            case Type.AngleDL:
                isEmpty = CheckEmptySpaceForAngleDL(rowBase, colBase);
                break;
            case Type.AngleUL:
                isEmpty = CheckEmptySpaceForAngleUL(rowBase, colBase);
                break;
            default:
                break;
        }

        return isEmpty;
    }

    private static bool CheckEmptySpaceForNinetile(int rowBase, int colBase)
    {
        bool isEmpty = true;
        if ((colBase >= 1) && (colBase <= 498) && (rowBase >= 1) && (rowBase <= 498))
        {
            for (int row = rowBase - 1; row <= rowBase + 1; row++)
            {
                for (int col = colBase - 1; col < colBase + 1; col++)
                {
                    if (field[row, col] == true)
                    {
                        isEmpty = false;
                        break;
                    }
                }

                if (isEmpty == false)
                {
                    break;
                }
            }
        }
        else
        {
            isEmpty = false;
        }

        return isEmpty;
    }

    private static bool CheckEmptySpaceForPlus(int rowBase, int colBase)
    {
        bool isEmpty = true;
        if ((colBase >= 1) && (colBase <= 498) && (rowBase >= 1) && (rowBase <= 498))
        {
            if (field[rowBase, colBase] == true)
            {
                isEmpty = false;
            }
            if (field[rowBase + 1, colBase] == true)
            {
                isEmpty = false;
            }
            if (field[rowBase - 1, colBase] == true)
            {
                isEmpty = false;
            }
            if (field[rowBase, colBase + 1] == true)
            {
                isEmpty = false;
            }
            if (field[rowBase, colBase - 1] == true)
            {
                isEmpty = false;
            }
        }
        else
        {
            isEmpty = false;
        }

        return isEmpty;
    }

    private static bool CheckEmptySpaceForVline(int rowBase, int colBase)
    {
        bool isEmpty = true;
        if ((colBase >= 0) && (colBase <= 499) && (rowBase >= 1) && (rowBase <= 498))
        {
            if (field[rowBase, colBase] == true)
            {
                isEmpty = false;
            }
            if (field[rowBase + 1, colBase] == true)
            {
                isEmpty = false;
            }
            if (field[rowBase - 1, colBase] == true)
            {
                isEmpty = false;
            }
        }
        else
        {
            isEmpty = false;
        }

        return isEmpty;
    }

    private static bool CheckEmptySpaceForHline(int rowBase, int colBase)
    {
        bool isEmpty = true;
        if ((colBase >= 1) && (colBase <= 498) && (rowBase >= 0) && (rowBase <= 499))
        {
            if (field[rowBase, colBase] == true)
            {
                isEmpty = false;
            }
            if (field[rowBase, colBase + 1] == true)
            {
                isEmpty = false;
            }
            if (field[rowBase, colBase - 1] == true)
            {
                isEmpty = false;
            }
        }
        else
        {
            isEmpty = false;
        }

        return isEmpty;
    }

    private static bool CheckEmptySpaceForAngleUR(int rowBase, int colBase)
    {
        bool isEmpty = true;
        if ((colBase >= 0) && (colBase <= 498) && (rowBase >= 1) && (rowBase <= 499))
        {
            if (field[rowBase, colBase] == true)
            {
                isEmpty = false;
            }
            if (field[rowBase - 1, colBase] == true)
            {
                isEmpty = false;
            }
            if (field[rowBase, colBase + 1] == true)
            {
                isEmpty = false;
            }
        }
        else
        {
            isEmpty = false;
        }

        return isEmpty;
    }

    private static bool CheckEmptySpaceForAngleDR(int rowBase, int colBase)
    {
        bool isEmpty = true;
        if ((colBase >= 0) && (colBase <= 498) && (rowBase >= 0) && (rowBase <= 498))
        {
            if (field[rowBase, colBase] == true)
            {
                isEmpty = false;
            }
            if (field[rowBase + 1, colBase] == true)
            {
                isEmpty = false;
            }
            if (field[rowBase, colBase + 1] == true)
            {
                isEmpty = false;
            }
        }
        else
        {
            isEmpty = false;
        }

        return isEmpty;
    }

    private static bool CheckEmptySpaceForAngleDL(int rowBase, int colBase)
    {
        bool isEmpty = true;
        if ((colBase >= 1) && (colBase <= 499) && (rowBase >= 0) && (rowBase <= 498))
        {
            if (field[rowBase, colBase] == true)
            {
                isEmpty = false;
            }
            if (field[rowBase + 1, colBase] == true)
            {
                isEmpty = false;
            }
            if (field[rowBase, colBase - 1] == true)
            {
                isEmpty = false;
            }
        }
        else
        {
            isEmpty = false;
        }

        return isEmpty;
    }

    private static bool CheckEmptySpaceForAngleUL(int rowBase, int colBase)
    {
        bool isEmpty = true;
        if ((colBase >= 1) && (colBase <= 499) && (rowBase >= 1) && (rowBase <= 499))
        {
            if (field[rowBase, colBase] == true)
            {
                isEmpty = false;
            }
            if (field[rowBase - 1, colBase] == true)
            {
                isEmpty = false;
            }
            if (field[rowBase, colBase - 1] == true)
            {
                isEmpty = false;
            }
        }
        else
        {
            isEmpty = false;
        }

        return isEmpty;
    }

    private static Figure[] ReadInput()
    {
        int N = int.Parse(Console.ReadLine());
        Figure[] arrayOfFigures = new Figure[N];
        for (int i = 0; i < arrayOfFigures.Length; i++)
        {
            string[] line = Console.ReadLine().Split(' ');
            Type type = StringToType(line[0]);
            int row = int.Parse(line[1]);
            int col = int.Parse(line[2]);
            Figure figure = new Figure(row, col, type);
            arrayOfFigures[i] = figure;
        }

        return arrayOfFigures;
    }

    private static Type StringToType(string text)
    {
        Type type;
        switch (text)
        {
            case "ninetile":
                type = Type.Ninetile;
                break;
            case "plus":
                type = Type.Plus;
                break;
            case "hline":
                type = Type.Hline;
                break;
            case "vline":
                type = Type.Vline;
                break;
            case "angle-ur":
                type = Type.AngleUR;
                break;
            case "angle-dr":
                type = Type.AngleDR;
                break;
            case "angle-ul":
                type = Type.AngleUL;
                break;
            case "angle-dl":
                type = Type.AngleDL;
                break;
            default:
                type = Type.Ninetile;
                break;
        }
        return type;
    }

}
