using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Zap.Logic
{
    public class GuiLogic : Form1
    {

        
        //logic reset??
        public void GenericLogicReset()
        {
            
            if (DS.CrashesLeft >= 0)
            {
                DS.CrashesLeft--;
                DS.PlayerX.Clear();
                DS.MovementX = 0;
                DS.MovementY = 0;
            }
            else
            {
                DS.CrashesLeft = 5;
                DS.PlayerY.Clear();
                DS.MovementX = 0;
                DS.MovementY = 0;
                DS.Selected = false;
                
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }
                
            }
        }
    }
}
