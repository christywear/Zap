using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace Zap.Logic
{
    public class InputReactor : Form1
    {
        readonly LevelSelectLogic LSL = new LevelSelectLogic();
        readonly Logic.GuiLogic GL = new GuiLogic();

        public string PictureBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (DS.PlayerXCount != 0)
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
                        return "LS.GoLeft";
                    }

                    else
                    {
                        if (DS.PlayerX[0] >= 50 && DS.PlayerX[0] != DS.PlayerX[1] + DS.Space)
                        {
                            DS.MovementX = 0;
                            DS.MovementY = 0;
                            DS.MovementX -= DS.Space;
                            System.Threading.Thread.Sleep(800 / DS.LevelSelected);
                            return "Invalid";
                        }
                        if (DS.PlayerX[0] < 50)
                        {
                            GL.GenericLogicReset(); // respawn
                            return "Invalid";
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
                        return "LS.GoRight";
                    }
                    else
                    {
                        if (DS.PlayerX[0] <= 920 && DS.PlayerX[0] != DS.PlayerX[1] - DS.Space)
                        {
                            DS.MovementX = 0;
                            DS.MovementY = 0;
                            DS.MovementX += DS.Space;
                            System.Threading.Thread.Sleep(800 / DS.LevelSelected);
                            
                            return "Invalid";
                        }
                        if (DS.PlayerX[0] > 920)
                        {
                            GL.GenericLogicReset(); // respawn
                            return "Invalid";
                        }
                    }
                break;
            case Keys.W:
                    if (!DS.ItsPlayTime) { }
                    else
                    {
                        if (DS.PlayerY[0] >= 90 && DS.PlayerY[0] != DS.PlayerY[1] + DS.Space)
                        {
                            DS.MovementX = 0;
                            DS.MovementY = 0;
                            DS.MovementY -= DS.Space;
                            System.Threading.Thread.Sleep(800 / DS.LevelSelected);
                            
                            return "Invalid";
                        }
                        if (DS.PlayerX[0] < 90)
                        {
                            GL.GenericLogicReset(); // respawn
                            return "Invalid";
                        }
                    }
                break;
            case Keys.S:
                    if (!DS.ItsPlayTime) { }
                    else
                    {
                        if (DS.PlayerY[0] <= 690 && DS.PlayerY[0] != DS.PlayerY[1] - DS.Space)
                        {
                            DS.MovementX = 0;
                            DS.MovementY = 0;
                            DS.MovementX += DS.Space;
                            System.Threading.Thread.Sleep(800 / DS.LevelSelected);
                            
                            return "Invalid";
                        }
                        if (DS.PlayerX[0] > 690)
                        {
                            GL.GenericLogicReset(); // respawn
                            return "Invalid";
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
                            
                            return "GUI.LoadPicture";
                        }
                    }
                //pictureBox1.Invalidate();
                //lastkeypressed = Keys.Enter;
                break;
            }
            
            e.Handled = true;
            return "";
        }
    }
}
        

