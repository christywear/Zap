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
                DS.Points.Clear();

            }
            else
            {
                DS.ItsPlayTime = false;
                DS.NotDoneThisYet = false;
                DS.Selected = false;
                DS.CrashesLeft = 5;
                DS.MovementX = 0;
                DS.MovementY = 0;
                DS.Points.Clear();
                
                
                
            }
        }
    }
}
