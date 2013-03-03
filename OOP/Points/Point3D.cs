public struct Point3D
{
    private static readonly Point3D zero = new Point3D(0, 0, 0);
    public static Point3D Zero
    {
        get { return zero; }
    }
    public double X { set; get; }
    public double Y { set; get; }
    public double Z { set; get; }

    public Point3D(double x, double y, double z)
        : this()
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }


    public override string ToString()
    {

        return string.Format("({0},{1},{2})", this.X, this.Y, this.Z);
    }
}