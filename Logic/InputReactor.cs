using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace Zap.Logic
{
    public class InputReactor : Form1
    {
        readonly LevelSelectLogic LSL = new LevelSelectLogic();
        

        public void PictureBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (DS.PlayerX.Count != 0)
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
                        if (DS.PlayerX.Count == 0)
                            break;
                        if (DS.PlayerX[0] >= 0 && DS.PlayerX[0] != DS.PlayerX[1] + DS.Space)
                        {
                            DS.MovementX = 0;
                            DS.MovementY = 0;
                            DS.MovementX -= DS.Space;
                            System.Threading.Thread.Sleep(51);
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
                        if (DS.PlayerX.Count == 0)
                            break;
                        if (DS.PlayerX[0] <= 1000 && DS.PlayerX[0] != DS.PlayerX[1] - DS.Space)
                        {
                            DS.MovementX = 0;
                            DS.MovementY = 0;
                            DS.MovementX += DS.Space;
                            System.Threading.Thread.Sleep(51);
                        }
                    }
                break;
            case Keys.W:
                    if (!DS.ItsPlayTime) { }
                    else
                    {
                        if (DS.PlayerX.Count == 0)
                            break;
                        if (DS.PlayerY[0] >= 40 && DS.PlayerY[0] != DS.PlayerY[1] + DS.Space)
                        {
                            DS.MovementX = 0;
                            DS.MovementY = 0;
                            DS.MovementY -= DS.Space;
                            System.Threading.Thread.Sleep(51);
                        }
                       
                    }
                break;
            case Keys.S:
                    if (!DS.ItsPlayTime) { }
                    else
                    {
                        if (DS.PlayerX.Count == 0)
                            break;
                        if (DS.PlayerY[0] <= 740 && DS.PlayerY[0] != DS.PlayerY[1] - DS.Space)
                        {
                            DS.MovementX = 0;
                            DS.MovementY = 0;
                            DS.MovementY += DS.Space;
                            System.Threading.Thread.Sleep(51);
                        }
                       
                    }
                break;
            case Keys.Enter:
                    //playstart = true;
                    //skilllevel = d;
                    if (!DS.ItsPlayTime)
                    {
                        DS.ItsPlayTime = true;
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
        

