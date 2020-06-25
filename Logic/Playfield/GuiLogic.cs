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
            
            if (DS.CrashesLeft > 0)
            {
                DS.CrashesLeft--;
                DS.MovementX = 0;
                DS.MovementY = 0;
                DS.PlayerX.Clear();
                DS.PlayerY.Clear();
                DS.Points.Clear();

            }
            else
            {
                DS.ItsPlayTime = false;
                DS.Selected = false;
                DS.CrashesLeft = 5;
                DS.MovementX = 0;
                DS.MovementY = 0;
                DS.PlayerX.Clear();
                DS.PlayerY.Clear();
                DS.Points.Clear();
                
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }
                
            }
        }
    }
}
