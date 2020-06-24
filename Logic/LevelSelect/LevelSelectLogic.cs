using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

//second
namespace Zap.Logic
{
    public class LevelSelectLogic : Form1
    {

        public void InterateDrawOnLevelLeft()
        {
            DS.CurrentSelectedPos -= DS.PosMoveAmount;
            if (DS.CurrentSelectedPos < 10)
            { DS.CurrentSelectedPos = 250; }
            DS.LevelSelected--;
            if (DS.LevelSelected <= 0)
            { DS.LevelSelected = 5; DS.CurrentSelectedPos = 250; }
            
        }

        public void InterateDrawOnLevelRight()
        {
            DS.CurrentSelectedPos += DS.PosMoveAmount;
            if (DS.CurrentSelectedPos > 250)
            { DS.CurrentSelectedPos = 46; }
            DS.LevelSelected++;
            if (DS.LevelSelected > 5)
            { DS.LevelSelected = 1; DS.CurrentSelectedPos = 46; }
            
        }
    }
}
