using System;
using System.Collections.Generic;
using System.Media;
using System.Text;
using System.Windows.Forms;
using Zap.Properties;

//second
namespace Zap.Logic
{
    public class LevelSelectLogic : Form1
    {
        readonly SoundPlayer sndLeft = new SoundPlayer(Resources.clickLeft);
        readonly SoundPlayer sndRight = new SoundPlayer(Resources.clickRight);

        public void InterateDrawOnLevelLeft()
        {
            sndLeft.Play();
            DS.CurrentSelectedPos -= DS.PosMoveAmount;
            if (DS.CurrentSelectedPos < 10)
            { DS.CurrentSelectedPos = 250; }
            DS.LevelSelected--;
            if (DS.LevelSelected <= 0)
            { DS.LevelSelected = 5; DS.CurrentSelectedPos = 250; }
            
        }

        public void InterateDrawOnLevelRight()
        {
            sndRight.Play();
            DS.CurrentSelectedPos += DS.PosMoveAmount;
            if (DS.CurrentSelectedPos > 250)
            { DS.CurrentSelectedPos = 46; }
            DS.LevelSelected++;
            if (DS.LevelSelected > 5)
            { DS.LevelSelected = 1; DS.CurrentSelectedPos = 46; }
            
        }
    }
}
