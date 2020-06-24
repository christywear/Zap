using System;
using System.Collections.Generic;

using System.Text;

namespace Zap.Data
{
    public class DataStorage
    {


        #region LevelSelectLogic
        private static int posMoveAmount = 51;
        private static int currentSelectedPos = 46;
        private static int levelSelected = 1;
        private static bool selected = false;

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
            set
            {
                currentSelectedPos = value;
            }
        }

        public int LevelSelected
        {
            get
            {
                return levelSelected;
            }
            set
            {
                levelSelected = value;
            }
        }

        #endregion

        #region Gui
        private static int crashes_left = 5;
        private static int skilllevel = 0;
        private static int score = 0;

        public int CrashesLeft
        {
            get { return crashes_left; }
            set { crashes_left = value; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public int SkillLevel
        {
            get { return skilllevel; }
            set { skilllevel = value; }
        }
        #endregion

        #region InputReactor
        private static bool itsPlayTime = false;
        public bool ItsPlayTime
        {
            get { return itsPlayTime; }
            set { itsPlayTime = value; }
        }
        #endregion

        #region PlayerLogic
        private static int space = 22;
        private static int movementx = 0;
        private static int movementy = 0;

        
        public int Space
        {
            get
            {
                return space;
            }
        }

        public int MovementX
        {
            get
            {
                return movementx;
            }
            set
            {
                movementx = value;
            }
        }

        public int MovementY
        {
            get
            {
                return movementy;
            }
            set
            {
                movementy = value;
            }
        }

 

        private static List<int> playery = new List<int>();
        private static List<int> playerx = new List<int>();


        public List<int> PlayerY 
        { 
            get 
            {
                return playery;
            } 
        }

        public int PlayerYCount { get { return playery.Count; }}

        public List<int> PlayerX 
        { 
            get 
            {
                return playerx; 
            } 
        }
            
        public int PlayerXCount { get { return PlayerY.Count; } }

          
      

        #endregion

    }
}
