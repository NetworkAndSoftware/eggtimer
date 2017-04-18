using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace eggtimer
{
  public partial class Form1 : Form
  {
    Countdown countdown;
    bool bWantClose;

    private Point mouseOffset;
    private bool isMouseDown = false;

    public class Ringer
    {
      ResourceSoundPlayer rsp;
      Thread tRing;
      bool bStop;
      Form form;

      public Ringer(Form form)
      {
        this.form = form;
        rsp = new ResourceSoundPlayer(Application.ProductName + ".ring1.wav");
        bStop = true;
      }

      public void start()
      {
        if (bStop)
        {
          bStop = false;
          tRing = new Thread(ringer);
          tRing.Start();
        }
      }

      public void stop()
      {
        bStop = true;
      }

      private void ringer()
      {
        while (!bStop)
        {
          rsp.play_sync();
        }
      }
    }
    Ringer ringer;

    public class Countdown
    {
      public int minutes;
      public int seconds;

      public void set(int minutes)
      {
        this.minutes = minutes;
        this.seconds = 0;
      }

      public void tick()
      {
        if (0 == seconds && minutes > 0)
        {
          minutes--;
          seconds = 59;
          return;
        }
        if (seconds > 0)
          seconds--;
      }

      public bool zero
      {
        get
        {
          return (0 == (minutes | seconds));
        }
      }

      public override string ToString()
      {
        return minutes.ToString() + " minutes, " + seconds.ToString() + " seconds left.";
      }
    }


    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      ringer = new Ringer(this);
      countdown = new Countdown();
      bWantClose = false;

      // > 24bpp fix 
      Bitmap b = (Bitmap)BackgroundImage;
      TransparencyKey = b.GetPixel(1, 1);
      TransparencyFix.FixTranparency((Form)this);
    }

    private void timer_Tick(object sender, EventArgs e)
    {
      countdown.tick();
      showcountdown();
      if (countdown.zero)
      {
        timer.Stop();
        ringstart();
      }
    }

    private void ringstart()
    {
      ringer.start();
      lblMinutes.Visible = false;
      nudMinutes.Visible = false;
      btnOfSsh.Visible = true;
      show();
    }

    private void ringstop()
    {
      btnOfSsh.Visible = false;
      ringer.stop();
      lblMinutes.Visible = true;
      nudMinutes.Visible = true;
    }

    private void showcountdown()
    {
      if (0 == countdown.seconds)
        lSeconds.Visible = false;
      else
      {
        lSeconds.Text = countdown.seconds.ToString();
        lSeconds.Visible = true;
      }
      nudMinutes.Value = countdown.minutes;
      if (countdown.zero)
        ni.Text = "Egg Timer: " + "Ring!";
      else
        ni.Text = "Egg Timer: " + countdown.ToString();
    }


    private void nudMinutes_ValueChanged(object sender, EventArgs e)
    {
      if (nudMinutes.Value != countdown.minutes)
      {
        timer.Stop();
        countdown.set(Convert.ToInt16(nudMinutes.Value));
        showcountdown();
        timer.Start();
      }
    }

    private void show()
    {
      Visible = true;
      Activate();
      WindowState = FormWindowState.Normal;
    }

    private void hide()
    {
      Visible = false;
    }

    private void ni_DoubleClick(object sender, EventArgs e)
    {
      show();
    }

    private void tsmiShow_Click(object sender, EventArgs e)
    {
      show();
    }

    private void close()
    {
      bWantClose = true;
      ringstop();
      Close();
    }

    private void tsmiExit_Click(object sender, EventArgs e)
    {
      close();
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (!bWantClose)
      {
        hide();
        e.Cancel = true;
      }
    }

    private void ni_Click(object sender, EventArgs e)
    {
      show();
    }

    private void Form1_MouseDown(object sender,
    System.Windows.Forms.MouseEventArgs e)
    {

      int xOffset;
      int yOffset;

      if (e.Button == MouseButtons.Left)
      {
        xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
        yOffset = -e.Y - SystemInformation.CaptionHeight -
       SystemInformation.FrameBorderSize.Height;
        mouseOffset = new Point(xOffset, yOffset);
        isMouseDown = true;
      }
    }

    private void Form1_MouseMove(object sender, 
      System.Windows.Forms.MouseEventArgs e)
    {
      if (isMouseDown)
      {
        Point mousePos = Control.MousePosition;
        mousePos.Offset(mouseOffset.X, mouseOffset.Y);
        Location = mousePos;
      }
    }

    private void Form1_MouseUp(object sender,
    System.Windows.Forms.MouseEventArgs e)
    {
      // Changes the isMouseDown field so that the form does
      // not move unless the user is pressing the left mouse button.
      if (e.Button == MouseButtons.Left)
      {
        isMouseDown = false;
      }
      else
        cms.Show(Control.MousePosition);
    }

    private void label2_Click(object sender, EventArgs e)
    {
      cms.Show(Control.MousePosition);
    }

    private void tsmiAbout_Click(object sender, EventArgs e)
    {
      AboutBox1 aboutbox1 = new AboutBox1();
      aboutbox1.ShowDialog();
    }

    private void btnOfSsh_Click(object sender, EventArgs e)
    {
      ringstop();
    }

    private void hideToolStripMenuItem_Click(object sender, EventArgs e)
    {
      hide();
    }

  }
}