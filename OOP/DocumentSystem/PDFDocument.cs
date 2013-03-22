using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PDFDocument : BinaryDocument, IEncryptable
{
    public int? Pages { get; protected set; }
    public bool IsEncrypted { get; protected set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "pages")
        {
            this.Pages = int.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }



    public void Encrypt()
    {
        this.IsEncrypted = true;
    }

    public void Decrypt()
    {
        this.IsEncrypted = false;
    }
}