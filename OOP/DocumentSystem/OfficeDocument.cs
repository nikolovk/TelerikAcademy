using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class OfficeDocument : BinaryDocument, IEncryptable
{
    public string Version { get; protected set; }
    public bool IsEncrypted { get; protected set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "version")
        {
            this.Version = value;
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