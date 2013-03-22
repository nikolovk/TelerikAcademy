using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class VideoDocument : MultimediaDocument
{
    public int? FrameRate { get; protected set; }


    public override void LoadProperty(string key, string value)
    {
        if (key == "framerate")
        {
            this.FrameRate = int.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }
}
