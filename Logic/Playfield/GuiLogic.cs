using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Zap.Logic
{
    public class GuiLogic : Form1
    {
        Graphiz.Gui GUI = new Graphiz.Gui();
        PlayerLogic PL = new PlayerLogic();
        LevelSelectLogic LSL = new LevelSelectLogic();
        Graphiz.LevelSelect LS = new Graphiz.LevelSelect();
        //logic reset??
        public void GenericLogicReset()
        {
            
            if (GUI.CrashesLeft >= 0)
            {
                GUI.CrashesLeft--;
                PL.ListClear();
                PL.MovementX = 0;
                PL.MovementY = 0;
            }
            else
            {
                GUI.CrashesLeft = 5;
                PL.ListClear();
                PL.MovementX = 0;
                PL.MovementY = 0;
                LSL.Selected = false;
                
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }
                LS.LoadLevel();
            }
        }
    }
}
