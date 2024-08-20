using Microsoft.Web.WebView2.Core;
using System.Diagnostics;
using System.Windows.Forms.VisualStyles;

namespace FramedBrowser
{
    public partial class MainForm : Form
    {
        Rectangle restoreBounds;

        public MainForm()
        {
            InitializeComponent();
            resizeablePanel1.Visible = false;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            webView21.CoreWebView2InitializationCompleted += webView21_CoreWebView2InitializationCompleted;
            await InitializeAsync();

            if (Properties.Settings.Default.ResizeablePanelSize.Width != 0) {
                resizeablePanel1.Bounds = new Rectangle(
                    Properties.Settings.Default.ResizeablePanelLocation,
                    Properties.Settings.Default.ResizeablePanelSize);
                resizeablePanel1.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            }

            resizeablePanel1.OnResize += resizeablePanel1_onResize;
            urlTextBox.Text = Properties.Settings.Default.LastURL;
            resizeablePanel1.Visible = true;
        }

        private void resizeablePanel1_onResize(object sender, Rectangle bounds)
        {
            Properties.Settings.Default.ResizeablePanelLocation = new Point(bounds.Left, bounds.Top);
            Properties.Settings.Default.ResizeablePanelSize = new Size(bounds.Width, bounds.Height);
            Properties.Settings.Default.Save();
        }

        private void webView21_CoreWebView2InitializationCompleted(object? sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            Debug.WriteLine("WebView_CoreWebView2InitializationCompleted");
        }

        private void remeberLastURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void navigateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = Prompt.ShowDialog(this, "Navigate", "Enter Url", "http://www.");
            Navigate(url);
        }

        private async Task InitializeAsync()
        {
            await webView21.EnsureCoreWebView2Async(null);

            if ((webView21 == null) || (webView21.CoreWebView2 == null)) {
                MessageBox.Show(this, "WebView not ready");
            }
            else {
                string url = Properties.Settings.Default.LastURL;
                Navigate(url);
            }
        }

        public Rectangle ScreenBounds()
        {
            return Screen.FromControl(this).Bounds;
        }

        private void Navigate(string url)
        {
            try {
                webView21.CoreWebView2.Navigate(url);
                Properties.Settings.Default.LastURL = url;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex) {
                MessageBox.Show(this, ex.Message);
            }

        }

        private void urlTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                Navigate(urlTextBox.Text);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
