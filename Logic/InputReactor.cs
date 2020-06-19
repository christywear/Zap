using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace Zap.Logic
{
    public class InputReactor : Form1
    {
        public void pictureBox1_KeyDown(object sender, KeyEventArgs e)
        {
            PlayerLogic PL = new PlayerLogic();
            LevelSelectLogic LSL = new LevelSelectLogic();
            GuiLogic GL = new GuiLogic();
            Graphiz.Gui GUI = new Graphiz.Gui();

            bool itsPlayTime = false;
            Keys lastkeypressed = Keys.None;

            if (PL.GetPlayerX.Count != 0)
            {
                itsPlayTime = true;
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
                    if (!itsPlayTime)
                    { 
                        LSL.InterateDrawOnLevelLeft();
                        
                    }

                    else
                    {
                        if (PL.GetPlayerX[0] >= 50 && PL.GetPlayerX[0] != PL.GetPlayerX[1] + PL.Space)
                        {
                            PL.MovementX = 0;
                            PL.MovementY = 0;
                            PL.MovementX -= PL.Space;
                            System.Threading.Thread.Sleep(800 / LSL.LevelSelected);
                            lastkeypressed = Keys.A;
                            pictureBox1.Invalidate();

                        }
                        if (PL.GetPlayerX[0] < 50)
                        {
                            GL.GenericLogicReset(); // respawn
                        }
                    }
                break;
            case Keys.D:
                    //pictureBox1.Paint += new PaintEventHandler(clearnumline);
                    //pictureBox1.Paint += new PaintEventHandler(DrawLinePointF);
                    //pictureBox1.Paint += new PaintEventHandler(DrawLineLeftOrRight);
                    if (!itsPlayTime)
                    { LSL.InterateDrawOnLevelRight(); }
                    else
                    {
                        if (PL.GetPlayerX[0] <= 920 && PL.GetPlayerX[0] != PL.GetPlayerX[1] - PL.Space)
                        {
                            PL.MovementX = 0;
                            PL.MovementY = 0;
                            PL.MovementX += PL.Space;
                            lastkeypressed = Keys.D;
                            System.Threading.Thread.Sleep(800 / LSL.LevelSelected);
                            pictureBox1.Invalidate();
                        }
                        if (PL.GetPlayerX[0] > 920)
                        {
                            GL.GenericLogicReset(); // respawn
                        }
                    }
                break;
            case Keys.W:
                    if (!itsPlayTime) { }
                    else
                    {
                        if (lastkeypressed != Keys.W)
                        {

                        }
                        if (PL.GetPlayerY[0] >= 90 && PL.GetPlayerY[0] != PL.GetPlayerY[1] + PL.Space)
                        {
                            PL.MovementX = 0;
                            PL.MovementY = 0;
                            PL.MovementY -= PL.Space;
                            lastkeypressed = Keys.W;
                            System.Threading.Thread.Sleep(800 / LSL.LevelSelected);
                            pictureBox1.Invalidate();
                        }
                        if (PL.GetPlayerY[0] < 90)
                        {
                            GL.GenericLogicReset(); // respawn
                        }
                    }
                break;
            case Keys.S:
                    if (!itsPlayTime) { }
                    else
                    {
                        if (PL.GetPlayerY[0] <= 690 && PL.GetPlayerY[0] != PL.GetPlayerY[1] - PL.Space)
                        {
                            PL.MovementX = 0;
                            PL.MovementY = 0;
                            PL.MovementX += PL.Space;
                            lastkeypressed = Keys.S;
                            System.Threading.Thread.Sleep(800 / LSL.LevelSelected);
                            pictureBox1.Invalidate();
                        }
                        if (PL.GetPlayerX[0] > 690)
                        {
                            GL.GenericLogicReset(); // respawn
                        }
                    }
                break;
            case Keys.Enter:
                    //playstart = true;
                    //skilllevel = d;
                    if (!itsPlayTime)
                    {
                        itsPlayTime = true;
                        if (LSL.Selected == false)
                        {
                            LSL.Selected = true;
                            GUI.LoadPictureBoxGG();
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
        

