using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Zap.Logic
{
    public class PlayerLogic : Form1
    {
        Graphiz.Player PGraph = new Graphiz.Player();

        private int space = 22;
        private int movementx = 0;
        private int movementy = 0;
       
        private List<int> Playery = new List<int>();
        private List<int> Playerx = new List<int>();

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
        public List<int> GetPlayerX
        {

            get { return new List<int>(Playerx); }

        }
        public List<int> GetPlayerY
        {
            get { return new List<int>(Playery); }
        }

        public void ListClear()
        {
            Playerx.Clear();
            Playery.Clear();
        }
        public void GenericPlayerLogic(object sender, PaintEventArgs e)
        { 
            Random rnd = new Random();

            int min = 50;
            int max = 730;
            int pointx = 0;
            int pointy = 0;

           
           
            
            if (Playerx.Count == 0)
            {
                for (int i = 0; i< 10; i++)
                {

                    if (i == 0)
                    {
                        pointx = rnd.Next(min, max);
                        pointy = rnd.Next(min, max);
                    }
                    Point point9 = new Point(pointx, pointy);
                    Playerx.Add(point9.X);
                    Playery.Add(point9.Y);
                    PGraph.PlayerGeneric(point9, sender, e);
                    pointx += space;
                }
            }
            else
            { //----------------------------start debug here

                if (movementx != 0 || movementy != 0)
                {
                    int oldx = 0;
                    int oldy = 0;
                    int temp_oldx = 0;
                    int temp_oldy = 0;
                    for (int i = 0; i<Playerx.Count; i++)
                    {

                        //image you have a train, traincar 1's pos is 10,10. 
                        //now train car 1's pos is 20,10 + movement
                        // that means train car 2's pos is 10,10  that means 2 = 1's old pos
                        // train car 3 = traincar 2's old pos at 0,10 so 3 = 2
                        // cur pos + movement = newspot

                        if (i == 0) //train car 1
                        {
                            oldx = Playerx[i];
                            oldy = Playery[i];
                            Playerx[i] += movementx;
                            Playery[i] += movementy;
                        }
                        else
                        {
                            temp_oldx = Playerx[i]; // save train 2's pos
                            temp_oldy = Playery[i];
                            Playerx[i] = oldx;
                            Playery[i] = oldy;
                            oldx = temp_oldx;
                            oldy = temp_oldy;
                            temp_oldx = 0;
                            temp_oldy = 0;
                        }
                        Point Point9 = new Point(Playerx[i], Playery[i]);
                        PGraph.PlayerGeneric(Point9, sender, e);
                    }
                }
                else
                {
                    for (int i = 0; i< 10; i++)
                    {
                        Point Point9 = new Point(Playerx[i], Playery[i]);
                        PGraph.PlayerGeneric(Point9, sender, e);
                    }
                }
            }
        }
    }
}
