namespace eggtimer
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.nudMinutes = new System.Windows.Forms.NumericUpDown();
      this.lblMinutes = new System.Windows.Forms.Label();
      this.timer = new System.Windows.Forms.Timer(this.components);
      this.lSeconds = new System.Windows.Forms.Label();
      this.ni = new System.Windows.Forms.NotifyIcon(this.components);
      this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
      this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
      this.label2 = new System.Windows.Forms.Label();
      this.btnOfSsh = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.nudMinutes)).BeginInit();
      this.cms.SuspendLayout();
      this.SuspendLayout();
      // 
      // nudMinutes
      // 
      this.nudMinutes.BackColor = System.Drawing.Color.White;
      this.nudMinutes.ForeColor = System.Drawing.Color.Black;
      this.nudMinutes.Location = new System.Drawing.Point(75, 131);
      this.nudMinutes.Name = "nudMinutes";
      this.nudMinutes.Size = new System.Drawing.Size(54, 20);
      this.nudMinutes.TabIndex = 0;
      this.nudMinutes.ValueChanged += new System.EventHandler(this.nudMinutes_ValueChanged);
      // 
      // lblMinutes
      // 
      this.lblMinutes.AutoSize = true;
      this.lblMinutes.BackColor = System.Drawing.Color.Transparent;
      this.lblMinutes.ForeColor = System.Drawing.Color.Black;
      this.lblMinutes.Location = new System.Drawing.Point(25, 133);
      this.lblMinutes.Name = "lblMinutes";
      this.lblMinutes.Size = new System.Drawing.Size(44, 13);
      this.lblMinutes.TabIndex = 1;
      this.lblMinutes.Text = "Minutes";
      this.lblMinutes.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // timer
      // 
      this.timer.Interval = 1000;
      this.timer.Tick += new System.EventHandler(this.timer_Tick);
      // 
      // lSeconds
      // 
      this.lSeconds.AutoSize = true;
      this.lSeconds.BackColor = System.Drawing.Color.Transparent;
      this.lSeconds.ForeColor = System.Drawing.Color.Black;
      this.lSeconds.Location = new System.Drawing.Point(136, 133);
      this.lSeconds.Name = "lSeconds";
      this.lSeconds.Size = new System.Drawing.Size(19, 13);
      this.lSeconds.TabIndex = 2;
      this.lSeconds.Text = "60";
      this.lSeconds.Visible = false;
      // 
      // ni
      // 
      this.ni.Icon = ((System.Drawing.Icon)(resources.GetObject("ni.Icon")));
      this.ni.Visible = true;
      this.ni.Click += new System.EventHandler(this.ni_Click);
      this.ni.DoubleClick += new System.EventHandler(this.ni_DoubleClick);
      // 
      // cms
      // 
      this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAbout,
            this.hideToolStripMenuItem,
            this.tsmiExit});
      this.cms.Name = "cms";
      this.cms.Size = new System.Drawing.Size(100, 70);
      this.cms.Text = "Egg Timer";
      // 
      // tsmiAbout
      // 
      this.tsmiAbout.Name = "tsmiAbout";
      this.tsmiAbout.Size = new System.Drawing.Size(99, 22);
      this.tsmiAbout.Text = "&Help!";
      this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
      // 
      // hideToolStripMenuItem
      // 
      this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
      this.hideToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
      this.hideToolStripMenuItem.Text = "H&ide";
      this.hideToolStripMenuItem.Click += new System.EventHandler(this.hideToolStripMenuItem_Click);
      // 
      // tsmiExit
      // 
      this.tsmiExit.Name = "tsmiExit";
      this.tsmiExit.Size = new System.Drawing.Size(99, 22);
      this.tsmiExit.Text = "E&xit";
      this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.BackColor = System.Drawing.Color.Transparent;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)), true);
      this.label2.ForeColor = System.Drawing.Color.Yellow;
      this.label2.Location = new System.Drawing.Point(75, 194);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(38, 40);
      this.label2.TabIndex = 4;
      this.label2.Text = "?";
      this.label2.Click += new System.EventHandler(this.label2_Click);
      // 
      // btnOfSsh
      // 
      this.btnOfSsh.Location = new System.Drawing.Point(55, 129);
      this.btnOfSsh.Name = "btnOfSsh";
      this.btnOfSsh.Size = new System.Drawing.Size(75, 23);
      this.btnOfSsh.TabIndex = 5;
      this.btnOfSsh.Text = "Ssh!";
      this.btnOfSsh.UseVisualStyleBackColor = true;
      this.btnOfSsh.Visible = false;
      this.btnOfSsh.Click += new System.EventHandler(this.btnOfSsh_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
      this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.ClientSize = new System.Drawing.Size(180, 240);
      this.Controls.Add(this.btnOfSsh);
      this.Controls.Add(this.nudMinutes);
      this.Controls.Add(this.lblMinutes);
      this.Controls.Add(this.lSeconds);
      this.Controls.Add(this.label2);
      this.DoubleBuffered = true;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Form1";
      this.Text = "Egg Timer";
      this.TransparencyKey = System.Drawing.Color.Blue;
      this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
      this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
      this.Load += new System.EventHandler(this.Form1_Load);
      ((System.ComponentModel.ISupportInitialize)(this.nudMinutes)).EndInit();
      this.cms.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.NumericUpDown nudMinutes;
    private System.Windows.Forms.Label lblMinutes;
    private System.Windows.Forms.Timer timer;
    private System.Windows.Forms.Label lSeconds;
    private System.Windows.Forms.NotifyIcon ni;
    private System.Windows.Forms.ContextMenuStrip cms;
    private System.Windows.Forms.ToolStripMenuItem tsmiExit;
    private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
    private System.Windows.Forms.Button btnOfSsh;
  }
}

