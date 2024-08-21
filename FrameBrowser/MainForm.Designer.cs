namespace FrameBrowser
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            resizeablePanel1 = new ResizeablePanel();
            urlTextBox = new TextBox();
            closeButton = new Label();
            fullscreenButton = new Label();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            resizeablePanel1.SuspendLayout();
            SuspendLayout();
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Location = new Point(3, 30);
            webView21.Name = "webView21";
            webView21.Size = new Size(704, 297);
            webView21.TabIndex = 1;
            webView21.ZoomFactor = 1D;
            // 
            // resizeablePanel1
            // 
            resizeablePanel1.Controls.Add(urlTextBox);
            resizeablePanel1.Controls.Add(webView21);
            resizeablePanel1.Location = new Point(45, 60);
            resizeablePanel1.Name = "resizeablePanel1";
            resizeablePanel1.Size = new Size(711, 330);
            resizeablePanel1.TabIndex = 2;
            // 
            // urlTextBox
            // 
            urlTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            urlTextBox.Location = new Point(3, 4);
            urlTextBox.Name = "urlTextBox";
            urlTextBox.Size = new Size(704, 23);
            urlTextBox.TabIndex = 2;
            urlTextBox.KeyDown += urlTextBox_KeyDown;
            // 
            // closeButton
            // 
            closeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            closeButton.AutoSize = true;
            closeButton.BackColor = Color.Transparent;
            closeButton.Cursor = Cursors.Hand;
            closeButton.Font = new Font("Segoe UI", 6F);
            closeButton.ForeColor = SystemColors.ControlDark;
            closeButton.Location = new Point(786, 1);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(16, 11);
            closeButton.TabIndex = 4;
            closeButton.Text = "❌";
            closeButton.Click += closeButton_Click;
            // 
            // fullscreenButton
            // 
            fullscreenButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            fullscreenButton.AutoSize = true;
            fullscreenButton.BackColor = Color.Transparent;
            fullscreenButton.Cursor = Cursors.Hand;
            fullscreenButton.Font = new Font("Segoe UI", 8F);
            fullscreenButton.ForeColor = SystemColors.ControlDark;
            fullscreenButton.Location = new Point(769, -1);
            fullscreenButton.Name = "fullscreenButton";
            fullscreenButton.Size = new Size(18, 13);
            fullscreenButton.TabIndex = 5;
            fullscreenButton.Text = "🗖";
            fullscreenButton.Click += fullscreenButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bg_line_slanting_dark_1920x1080;
            ClientSize = new Size(800, 450);
            Controls.Add(fullscreenButton);
            Controls.Add(closeButton);
            Controls.Add(resizeablePanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForm";
            Text = "Frame Browser 1.0";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            resizeablePanel1.ResumeLayout(false);
            resizeablePanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private ResizeablePanel resizeablePanel1;
        private TextBox urlTextBox;
        private Label closeButton;
        private Label fullscreenButton;
    }
}
