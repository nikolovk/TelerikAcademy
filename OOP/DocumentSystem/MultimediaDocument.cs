using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class MultimediaDocument : BinaryDocument
{
    public int? Length { get; protected set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "length")
        {
            this.Length = int.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }
}
