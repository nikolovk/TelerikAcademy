using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class BinaryDocument : Document
{
    public long? Size { get; protected set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "size")
        {
            this.Size = int.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }
}
