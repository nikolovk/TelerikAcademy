using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ExcelDocument : OfficeDocument
{
    public int? Rows { get; protected set; }
    public int? Cols { get; protected set; }


    public override void LoadProperty(string key, string value)
    {
        if (key == "rows")
        {
            this.Rows = int.Parse(value);
        }
        else if (key == "cols")
        {
            this.Cols = int.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }
}
