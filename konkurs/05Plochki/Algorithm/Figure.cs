using System;

class Figure
{
    public int Row { get; set; }
    public int Col { get; set; }
    public Type Type { get; private set;}

    public Figure(int row, int col, Type type)
    {
        this.Row = row;
        this.Col = col;
        this.Type = type;
    }
}

