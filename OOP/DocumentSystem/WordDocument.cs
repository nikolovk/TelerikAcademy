using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class WordDocument : OfficeDocument, IEditable
{
    public int? Chars {get;protected set;}



    public override void LoadProperty(string key, string value)
    {
        if (key == "chars")
        {
            this.Chars = int.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }
    public void ChangeContent(string newContent)
    {
        this.Content = newContent;
    }
}
