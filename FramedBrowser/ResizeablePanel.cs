﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FramedBrowser
{
    public partial class ResizeablePanel : Panel
    {
        private bool mMouseDown = false;
        private EdgeEnum mEdge = EdgeEnum.None;
        private int mWidth = 4;
        private bool mOutlineDrawn = false;

        public event EventHandler<Rectangle> OnResize;

        private enum EdgeEnum
        {
            None,
            Right,
            Left,
            Top,
            Bottom,
            TopLeft
        }


        public ResizeablePanel()
        {
            InitializeComponent();
        }

        private void ResizeablePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left) {
                mMouseDown = true;

            }
        }

        private void ResizeablePanel_MouseUp(object sender, MouseEventArgs e)
        {
            mMouseDown = false;

        }

        private void ResizeablePanel_MouseMove(object sender, MouseEventArgs e)
        {
            Control c = (Control)sender;
            Graphics g = c.CreateGraphics();
            switch (mEdge) {
                case EdgeEnum.TopLeft:
                    g.FillRectangle(Brushes.Fuchsia, 0, 0, mWidth * 4, mWidth * 4);
                    mOutlineDrawn = true;
                    break;
                case EdgeEnum.Left:
                    g.FillRectangle(Brushes.Fuchsia, 0, 0, mWidth, c.Height);
                    mOutlineDrawn = true;
                    break;
                case EdgeEnum.Right:
                    g.FillRectangle(Brushes.Fuchsia, c.Width - mWidth, 0, c.Width, c.Height);
                    mOutlineDrawn = true;
                    break;
                case EdgeEnum.Top:
                    g.FillRectangle(Brushes.Fuchsia, 0, 0, c.Width, mWidth);
                    mOutlineDrawn = true;
                    break;
                case EdgeEnum.Bottom:
                    g.FillRectangle(Brushes.Fuchsia, 0, c.Height - mWidth, c.Width, mWidth);
                    mOutlineDrawn = true;
                    break;
                case EdgeEnum.None:
                    if (mOutlineDrawn) {
                        c.Refresh();
                        mOutlineDrawn = false;
                    }
                    break;
            }

            if (mMouseDown & mEdge != EdgeEnum.None) {
                c.SuspendLayout();
                switch (mEdge) {
                    case EdgeEnum.TopLeft:
                        c.SetBounds(c.Left + e.X, c.Top + e.Y, c.Width, c.Height);
                        break;
                    case EdgeEnum.Left:
                        c.SetBounds(c.Left + e.X, c.Top, c.Width - e.X, c.Height);
                        break;
                    case EdgeEnum.Right:
                        c.SetBounds(c.Left, c.Top, c.Width - (c.Width - e.X), c.Height);
                        break;
                    case EdgeEnum.Top:
                        c.SetBounds(c.Left, c.Top + e.Y, c.Width, c.Height - e.Y);
                        break;
                    case EdgeEnum.Bottom:
                        c.SetBounds(c.Left, c.Top, c.Width, c.Height - (c.Height - e.Y));
                        break;
                }
                OnResize?.Invoke(this, Bounds);
                c.ResumeLayout();
            }
            else {
                if (e.X <= (mWidth * 4) && e.Y <= (mWidth * 4)) {
                    //top left corner
                    c.Cursor = Cursors.SizeAll;
                    mEdge = EdgeEnum.TopLeft;
                }
                else if (e.X <= mWidth) {
                    //left edge
                    c.Cursor = Cursors.VSplit;
                    mEdge = EdgeEnum.Left;
                }
                else if (e.X > c.Width - (mWidth + 1)) {
                    //right edge
                    c.Cursor = Cursors.VSplit;
                    mEdge = EdgeEnum.Right;
                }
                else if (e.Y <= mWidth) {
                    //top edge
                    c.Cursor = Cursors.HSplit;
                    mEdge = EdgeEnum.Top;
                }
                else if (e.Y > c.Height - (mWidth + 1)) {
                    //bottom edge
                    c.Cursor = Cursors.HSplit;
                    mEdge = EdgeEnum.Bottom;
                }
                else {
                    //no edge
                    c.Cursor = Cursors.Default;
                    mEdge = EdgeEnum.None;
                }
            }

        }

        private void ResizeablePanel_MouseLeave(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            mEdge = EdgeEnum.None;
            c.Refresh();

        }
    }
}
