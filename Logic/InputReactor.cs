using System;
using System.Collections.Generic;
using System.Media;
using System.Text;
using System.Windows.Forms;
using Zap.Properties;

namespace Zap.Logic
{
    public class InputReactor : Form1
    {
        readonly LevelSelectLogic LSL = new LevelSelectLogic();
        

        public void PictureBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (DS.Points.Count != 0)
            {
                DS.ItsPlayTime = true;
            }
            switch (e.KeyCode)
            {

                case Keys.Escape:
                    //mainloop = false;
                    Application.Exit();
                    //thisway = 0;
                    
                    break;

                case Keys.A:
                    //
                    if (!DS.ItsPlayTime)
                    {
                        LSL.InterateDrawOnLevelLeft();
                    }

                    else
                    {
                        if (DS.Points.Count == 0)
                            break;
                        if (DS.Points[0].X >= 0 && DS.Points[0].X != DS.Points[1].X + DS.Space)
                        {
                            DS.MovementX = 0;
                            DS.MovementY = 0;
                            DS.MovementX -= DS.Space;
                           // System.Threading.Thread.Sleep(51);
                        }
                    }
                break;
            case Keys.D:
                    //pictureBox1.Paint += new PaintEventHandler(clearnumline);
                    //pictureBox1.Paint += new PaintEventHandler(DrawLinePointF);
                    //pictureBox1.Paint += new PaintEventHandler(DrawLineLeftOrRight);
                    if (!DS.ItsPlayTime)
                    {
                        LSL.InterateDrawOnLevelRight();
                    }
                    else
                    {
                        if (DS.Points.Count == 0)
                            break;
                        if (DS.Points[0].X <= 1000 && DS.Points[0].X != DS.Points[1].X - DS.Space)
                        {
                            DS.MovementX = 0;
                            DS.MovementY = 0;
                            DS.MovementX += DS.Space;
                           // System.Threading.Thread.Sleep(51);
                        }
                    }
                break;
            case Keys.W:
                    if (!DS.ItsPlayTime) { }
                    else
                    {
                        if (DS.Points.Count == 0)
                            break;
                        if (DS.Points[0].Y >= 40 && DS.Points[0].Y != DS.Points[1].Y + DS.Space)
                        {
                            DS.MovementX = 0;
                            DS.MovementY = 0;
                            DS.MovementY -= DS.Space;
                          //  System.Threading.Thread.Sleep(51);
                        }
                       
                    }
                break;
            case Keys.S:
                    if (!DS.ItsPlayTime) { }
                    else
                    {
                        if (DS.Points.Count == 0)
                            break;
                        if (DS.Points[0].Y <= 740 && DS.Points[0].Y != DS.Points[1].Y - DS.Space)
                        {
                            DS.MovementX = 0;
                            DS.MovementY = 0;
                            DS.MovementY += DS.Space;
                            //System.Threading.Thread.Sleep(51);
                        }
                       
                    }
                break;
            case Keys.Enter:
                    SoundPlayer sndmusic = new SoundPlayer(Resources.flux_capacitor1);
                    //playstart = true;
                    //skilllevel = d;
                    if (!DS.ItsPlayTime)
                    {
                        DS.ItsPlayTime = true;
                        sndmusic.PlayLooping();
                        if (DS.Selected == false)
                        {
                            DS.Selected = true;
                        }

                    }
                //pictureBox1.Invalidate();
                //lastkeypressed = Keys.Enter;
                break;
            }
            
            e.Handled = true;
        }
    }
}
        

