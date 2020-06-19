using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

//second
namespace Zap.Logic
{
    public class LevelSelectLogic : Form1
    {
        Graphiz.LevelSelect LS = new Graphiz.LevelSelect();
        private int posMoveAmount = 51;
        private int currentSelectedPos = 46;
        private int levelSelected = 1;
        private bool selected = false;
        public int PosMoveAmount
        {
            get
            {
                return posMoveAmount;
            }
        }

        public bool Selected
        {
            get
            {
                return selected;
            }
            set
            {
                selected = value;
            }
        }
        public int CurrentSelectedPos
        {
            get
            {
                return currentSelectedPos;
            }
        }

        public int LevelSelected
        {
            get
            {
                return levelSelected;
            }
        }
       
        public void InterateDrawOnLevelLeft()
        {
            currentSelectedPos -= posMoveAmount;
            if (currentSelectedPos < 10)
            { currentSelectedPos = 250; }
            levelSelected--;
            if (levelSelected <= 0)
            { levelSelected = 5; currentSelectedPos = 250; }
            LS.LoadLevel();
        }

        public void InterateDrawOnLevelRight()
        {
            currentSelectedPos += posMoveAmount;
            if (currentSelectedPos > 250)
            { currentSelectedPos = 46; }
            levelSelected++;
            if (levelSelected > 5)
            { levelSelected = 1; currentSelectedPos = 46; }
            LS.LoadLevel();
        }
    }
}
