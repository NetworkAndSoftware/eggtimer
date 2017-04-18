using System;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace DrawEgg
{
  public class Shader
  {
    Color ambient, point, surface;

    public Shader(Color ambient, Color point, Color surface)
    {
      this.ambient = ambient;
      this.point = point;
      this.surface = surface;
    }

    private float scale(int colorcomponent)
    {
      return (float)colorcomponent / 255f;
    }

    private int mixer(int a, int p, int s, float l)
    { return (int) Math.Min(255, s * (scale(a) + l * scale(p)) / 2);
    }

    public Color get(float light)
    { return Color.FromArgb
      ( mixer(ambient.R, point.R, surface.R, light)
      , mixer(ambient.G, point.G, surface.G, light)
      , mixer(ambient.B, point.B, surface.B, light)
      );
    }
  }
  
  class Drawings
  {
    // using http://home.vicnet.net.au/~pwguild/i-gadg.htm
    
    // r is radius of circle at base
    static public GraphicsPath EggGraphicsPath(float r)
    { GraphicsPath path = new GraphicsPath();
      float r_top = (2 - (float)Math.Sqrt(2)) * r;
      path.AddArc(-r, -r, 2 * r, 2 * r, 0, 180); // base
      path.AddArc(-r, -2 * r, 4 * r, 4 * r, 180, 45); // left
      path.AddArc(-r_top, -r - r_top, 2 * r_top, 2 * r_top, 180 + 45, 90); // top
      path.AddArc(-3 * r, -2 * r, 4 * r, 4 * r, -45, 45); // right
      path.CloseFigure();
      return path;
    }

    static public double degtorad(double angle)
    {
      return angle * Math.PI / 180;
    }

    static public double EggRadius(Graphics g, double radius, double angle)
    { const double PI = Math.PI;
      double sqrt2 = 1.4142135623730951;

      double delta = degtorad(angle) % (2 * PI);
      if (delta < 0)
        delta += 2 * PI;

      if (PI > delta)
        return radius;
      if (2 * PI - Math.Acos((2 - 2 * sqrt2)/(10 - 4 * sqrt2)) > delta)
      {
        double gamma = (2 * Math.PI) - delta;
        double b = radius;
        double c = 2 * radius;
        double s = Math.Sin(gamma) / c;
        double beta = Math.Asin(b * s);
        double alpha = Math.PI - gamma - beta;
        double a = c * Math.Sin(alpha) / Math.Sin(gamma);
        return a;
      }
      return -1;
    
    }

/// <summary>
/// Draw solid egg.
/// </summary>
/// <param name="graphics">The Graphics to draw the egg on</param>
/// <param name="r">radius of egg</param>
/// <param name="angleh">horizontal angle of light. positive angle is left of line of sight for observer</param>
/// <param name="anglev">vertical angle of light. positive angle is up from line of sight</param>
    static public void DrawSolidEgg(Graphics graphics, float r, float angleh, float anglev)
    {
      System.Diagnostics.Debug.Print(EggRadius(graphics, 7, 225).ToString());
      Color ambient = Color.White;
      Color point = Color.White;
      Color egg = Color.FromArgb(0xff, 0xcc, 0x99);
      

      Shader shader = new Shader(ambient, point, egg);
      
      for (int i = (int) r; i > 0; i--)
      {
        graphics.TranslateTransform(-i / (2*r), -i / r);
        graphics.FillPath(new SolidBrush(shader.get(1 - (float) i / r)), EggGraphicsPath(i));
      }
    }
  }
}
