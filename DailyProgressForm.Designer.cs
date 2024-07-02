namespace DailyProgress;

partial class DailyProgressForm
{
    private System.ComponentModel.IContainer components = null;
    private int workingMinutes   = 480;
    private Label startTimeLabel = new Label();
    private Label statusLabel    = new Label();
    private Brush greenBrush     = new SolidBrush(Color.Green);
    private Brush cyanBrush      = new SolidBrush(Color.Cyan);
    private Pen blackPen         = new Pen(Color.Black);
    private DateTime startTime   = DateTime.Now;

    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);
        m.Result = (IntPtr) 0x2;
    }

    protected override void Dispose(bool disposing) 
    {
        if (disposing && (components != null)) 
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components      = new System.ComponentModel.Container();
        AutoScaleMode   = AutoScaleMode.Font;
        FormBorderStyle = FormBorderStyle.None;
        ClientSize      = new Size(500, 60);
        Text            = "Daily Progress";

        var timer      = new System.Windows.Forms.Timer();
        timer.Interval = 60 * 1000;
        timer.Tick    += new System.EventHandler(timerTick);
        timer.Start();

        DrawLabels();
        Refresh();
    }

    private void DrawLabels() 
    {
        startTimeLabel.Text     = "Started at: " + startTime.ToString("t");
        startTimeLabel.Width    = 120;
        startTimeLabel.Location = new Point(2, 5);

        statusLabel.Width    = 370;
        statusLabel.Location = new Point(124, 5);

        Controls.Add(startTimeLabel);
        Controls.Add(statusLabel);
    }

    protected override void OnPaint(PaintEventArgs e) 
    {
        var passedTime = DateTime.Now - startTime;
        int netMinutes = (int) Math.Round(passedTime.TotalMinutes) - workingMinutes;
        int hours      = (netMinutes - (netMinutes % 60)) / 60;
        int minutes    = netMinutes % 60;

        statusLabel.Text = "Net: " + hours + "h " + ((netMinutes < 0 ? 60-minutes : minutes) % 60) + "m";

        double progressPercent = 1;
        if (netMinutes < 0) 
        {
            int inverted = workingMinutes - (netMinutes * -1);
            progressPercent = (double) inverted / workingMinutes;
        }
        
        double overtimePercent = 0;
        if (netMinutes > 0) 
        {
            overtimePercent = (double) netMinutes / workingMinutes;
        }

        int progressWidth = (int) Math.Round(489 * progressPercent);
        int overtimeWidth = (int) Math.Round(489 * overtimePercent);

        e.Graphics.FillRectangle(greenBrush, new Rectangle(6, 31, progressWidth, 19));
        e.Graphics.FillRectangle(cyanBrush, new Rectangle(6, 31, overtimeWidth, 19));
        e.Graphics.DrawRectangle(blackPen, new Rectangle(5, 30, 490, 20));
    }

    private void timerTick(object sender, EventArgs e) 
    {
        Refresh();
    }
}
