using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Zap.Graphiz
{
    public class Player : Form1
    {
        public void PlayerGeneric(object sender, PaintEventArgs e)
        {
            if (DS.Points.Count != 0)
            { 
                for (int i = 0; i < 10; i++)
                {
                    Rectangle rectangle = new Rectangle(DS.Points[i], DS.RectangleSize);
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillEllipse(DS.PCircBrush, rectangle);
                }
            }
        }
    }
}
