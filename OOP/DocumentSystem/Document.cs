using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public abstract class Document : IDocument
{
    public string Name { get; protected set; }
    public string Content { get; protected set; }

    public virtual void LoadProperty(string key, string value)
    {
        if (key == "name")
        {
            this.Name = value;
        }
        else if (key == "content")
        {
            this.Content = value;
        }
        else
        {
            throw new ArgumentException("Unknown Argument Pair");
        }
    }

    public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        foreach (var item in output)
        {
            this.LoadProperty(item.Key, item.Value as string);
        }
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.Append(this.GetType().Name);
        result.Append("[");
        PropertyInfo[] properties = this.GetType().GetProperties();
        List<KeyValuePair<string, string>> attributes = new List<KeyValuePair<string, string>>();
        foreach (var prop in properties)
        {
            if ((prop.GetValue(this) !=null) && (prop.Name != "IsEncrypted"))
            {
                attributes.Add(new KeyValuePair<string, string>( prop.Name.ToLower(), prop.GetValue(this).ToString()));
            }
        }
        attributes.Sort((a, b) => a.Key.CompareTo(b.Key));
        foreach (var attribute in attributes)
        {
            result.Append(attribute.Key);
            result.Append("=");
            result.Append(attribute.Value);
            result.Append(";");
        }
        result.Length--;
        result.Append("]");
        return result.ToString();
    }
}
