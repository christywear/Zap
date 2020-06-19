using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

//first
namespace Zap.Graphiz
{
    public class LevelSelect : Form1
    {
       

        public void clearnumline(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
            g.Clear(Color.Black);
            Font fnt4 = new Font("Arial", 20);
            Font fnt3 = new Font("Arial", 18);

            string numline = "1     2     3     4     5";
            //clear old
            g.DrawString(numline,
            fnt3, System.Drawing.Brushes.Black, new Point(50, 70));
            g.DrawString(numline,
            fnt4, System.Drawing.Brushes.Black, new Point(50, 70));
            OnPaint(e);
        }

        public void DrawLineLeftOrRight(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
            Logic.LevelSelectLogic LSL = new Logic.LevelSelectLogic();
            //draw simple pica skill level
            Font fnt2 = new Font("Arial", 20);
            Pen blackPen2 = new Pen(Color.Green, 3);
            string pickSkillLevel = "PICK A SKILL LEVEL:\n";
            g.DrawString((pickSkillLevel),
                    fnt2, System.Drawing.Brushes.Green, new Point(30, 30));
            //draw numberline
            Font fnt4 = new Font("Arial", 20);
            Font fnt3 = new Font("Arial", 18);
            string numline = "1     2     3     4     5"; //full number line
            numline = numline.Replace(LSL.CurrentSelectedPos.ToString(), " "); //replace num using
            //draw new except current
            g.DrawString(numline,
            fnt3, System.Drawing.Brushes.Green, new Point(50, 70));
            //draw current
            e.Graphics.DrawString(LSL.LevelSelected.ToString(),
            fnt4, System.Drawing.Brushes.Green, new Point(LSL.CurrentSelectedPos, 70));
            OnPaint(e);
        }

        public void LoadLevel()
        {
            pictureBox1.Paint += clearnumline;
            pictureBox1.Paint += DrawLineLeftOrRight;
            pictureBox1.Invalidate();
            Dispose();
        }
    }
}
