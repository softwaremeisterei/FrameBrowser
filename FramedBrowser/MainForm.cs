using System.Windows.Forms.VisualStyles;

namespace FramedBrowser
{
    public partial class MainForm : Form
    {
        bool isMaximized = false;
        Rectangle restoreBounds;

        public MainForm()
        {
            InitializeComponent();
        }

        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isMaximized) {
                RestoreSize();
            }
            else {
                Maximize();
            }
            isMaximized = !isMaximized;
        }

        private void MainForm_Load(object sender, EventArgs e)
        { }

        private void RestoreSize()
        {
            FormBorderStyle = FormBorderStyle.Sizable;
            menuStrip1.Visible = true;
            Bounds = restoreBounds;
        }

        private void Maximize()
        {
            restoreBounds = new Rectangle(new Point(Left, Top), Size);
            FormBorderStyle = FormBorderStyle.None;
            menuStrip1.Visible = false;
            this.Bounds = ScreenBounds();
        }

        public Rectangle ScreenBounds()
        {
            return Screen.FromControl(this).Bounds;
        }

    }
}
