using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Zap.Data
{
    public class DataStorage
    {
        #region form
        private static bool notdonethisyet = false;
        public bool NotDoneThisYet { get { return notdonethisyet; } set { notdonethisyet = value; } }
        #endregion

        #region LevelSelectLogic
        private static readonly int posMoveAmount = 51;
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
        private static int applesEaten = 0;
        private static int applesWorth = 6;

        public int ApplesEaten
        {
            get { return applesEaten; }
            set { applesEaten = value; }
        }

        public int CrashesLeft
        {
            get { return crashes_left; }
            set { crashes_left = value; }
        }

        public int Score()
        {
            score = (applesWorth * applesEaten) + applesEaten;
            return score;
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
        private static readonly int space = 22;
        private static int movementx = 0;
        private static int movementy = 0;
        public static readonly Size rectangleSize = new Size(20, 20);
        public static readonly SolidBrush pCircBrush = new SolidBrush(Color.Green);
        private static List<Point> points = new List<Point>();


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

        public Size RectangleSize
        {
            get
            {
                return rectangleSize;
            }
        }

        public SolidBrush PCircBrush
        {
            get
            {
                return pCircBrush;
            }
        }

        public List<Point> Points
        {
            get
            {
                return points;
            }
          
        }

        #endregion

    }
}
