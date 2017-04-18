using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace eggtimer
{ // TransparencyKey doesn't work with resolutions > 24bpp
  public class TransparencyFix
  {

    static public void FixTranparency(Form form)
    { Color c = form.TransparencyKey;
    Region r = GetRegion((Bitmap)form.BackgroundImage, c);
      form.Region = r;
    }

    // soo inefficient
    static private Region GetRegion(Bitmap _img, Color color)
    {

      Color _matchColor = Color.FromArgb(color.R, color.G, color.B);
      System.Drawing.Region rgn = new Region();
      rgn.MakeEmpty();
      Rectangle rc = new Rectangle(0, 0, 0, 0);
      bool inimage = false;

      for (int y = 0; y < _img.Height; y++)
      {
        for (int x = 0; x < _img.Width; x++)
        {
	 if (!inimage)
	 {
	   if (_img.GetPixel(x, y) != _matchColor)
	   {
	     inimage = true;
	     rc.X = x;
	     rc.Y = y;
	     rc.Height = 1;
	   }
	 }
	 else
	 {
	   if (_img.GetPixel(x, y) == _matchColor)
	   {
	     inimage = false;
	     rc.Width = x - rc.X;
	     rgn.Union(rc);
	   }
	 }
        }
        if (inimage)
        {
	 inimage = false;
	 rc.Width = _img.Width - rc.X;
	 rgn.Union(rc);
        }
      }
      return rgn;
    }
  }

}
