using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using Zap.Logic;

namespace Zap.Graphiz
{
    public class Player : Form1
    {
        public void PlayerGeneric(object sender, PaintEventArgs e)
        {
            PlayerLogic PL = new PlayerLogic();
            if (DS.Points.Count != 0)
            { 
                for (int i = 0; i < PL.NumberOfPoints; i++)
                {
                    Rectangle rectangle = new Rectangle(DS.Points[i], DS.RectangleSize);
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillEllipse(DS.PCircBrush, rectangle);
                }
            }
        }
    }
}
