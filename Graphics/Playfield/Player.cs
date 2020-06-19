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
        public void PlayerGeneric(Point point, object sender, PaintEventArgs e)
        {

            Size rectangleSize = new Size(20, 20);
            Rectangle rectangle = new Rectangle(point, rectangleSize);
            SolidBrush me = new SolidBrush(Color.Green);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillEllipse(me, rectangle);
        }
    }
}
