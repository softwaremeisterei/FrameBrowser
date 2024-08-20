namespace FramedBrowser
{
    partial class ResizeablePanel
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            SuspendLayout();
            Name = "ResizeablePanel";
            Size = new Size(692, 300);
            MouseDown += ResizeablePanel_MouseDown;
            MouseLeave += ResizeablePanel_MouseLeave;
            MouseMove += ResizeablePanel_MouseMove;
            MouseUp += ResizeablePanel_MouseUp;
            ResumeLayout(false);
        }

        #endregion
    }
}
