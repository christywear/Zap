using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

// 
namespace Zap.Graphiz
{
    public class Gui : Form1
    {
        

        public void PictureboxStuff(object sender, PaintEventArgs e)
        {

            Font fnt = new Font("Arial", 30);
            Pen blackPen = new Pen(Color.Green, 3);

            // Create points that define line.
            //first line
            PointF point1 = new PointF(10.0F, 50.0F); //start top line
            PointF point2 = new PointF(1000.0F, 50.0F); // stop top line
                                                        // second line
            PointF point3 = new PointF(1000.0F, 50.0F); //start right line
            PointF point4 = new PointF(1000.0F, 750.0F); // stop right line
                                                         // third line
            PointF point5 = new PointF(1000.0F, 750.0F); //start bottom line
            PointF point6 = new PointF(10.0F, 750.0F); // stop bottom line
                                                       // fourth line
            PointF point7 = new PointF(10.0F, 750.0F); //start left line
            PointF point8 = new PointF(10.0F, 50.0F); // stop left line
                                                      // Draw line to screen.
            e.Graphics.DrawLine(blackPen, point1, point2); // draw line 1
            e.Graphics.DrawLine(blackPen, point3, point4); // draw line 2
            e.Graphics.DrawLine(blackPen, point5, point6); // draw line 3
            e.Graphics.DrawLine(blackPen, point7, point8); // draw line 4
            e.Graphics.DrawString(("Score= " + DS.Score),
                fnt, System.Drawing.Brushes.Green, new Point(10, 0));
            e.Graphics.DrawString(("Crashes Left= " + DS.CrashesLeft),
                fnt, System.Drawing.Brushes.Green, new Point(350, 0));
            e.Graphics.DrawString(("Level= " + DS.SkillLevel),
                fnt, System.Drawing.Brushes.Green, new Point(840, 0));
            if (DS.Points.Count != 0)
            {
                e.Graphics.DrawString(("x is" + DS.Points[0].X),
               fnt, System.Drawing.Brushes.Green, new Point(350, 400));
                e.Graphics.DrawString(("y is" + DS.Points[0].Y),
                   fnt, System.Drawing.Brushes.Green, new Point(600, 400));
            }
        }

        public void LoadPictureBoxGG()
        {
            pictureBox1.Paint += new PaintEventHandler(PictureboxStuff);
        }
    }
}
