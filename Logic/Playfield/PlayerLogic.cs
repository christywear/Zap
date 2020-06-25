using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Zap.Logic
{
    public class PlayerLogic : Form1
    {
        public PlayerLogic() 
        { 
            GenericPlayerLogic(); 
        }
        static Point pointtemp = new Point(0, 0);
        static Point pointtempSwap = new Point(0, 0);
        public void GenericPlayerLogic()
        { 
            Random rnd = new Random();

            int min = 50;
            int max = 730;
            int pointx = 0;
            int pointy = 0;

            if (DS.PlayerY.Count == 0)
            {
                for (int i = 0; i< 10; i++)
                {

                    if (i == 0)
                    {
                        pointx = rnd.Next(min, max);
                        pointy = rnd.Next(min, max);
                    }
                    Point point9 = new Point(pointx, pointy);
                    DS.Points.Add(point9);
                    DS.PlayerX.Add(point9.X);
                    DS.PlayerY.Add(point9.Y);
                    
                    pointx += DS.Space;
                }
            }
            else
            { //----------------------------start debug here

                if (DS.MovementX != 0 || DS.MovementY != 0)
                {
                    int oldx = 0;
                    int oldy = 0;
                    int temp_oldx;
                    int temp_oldy;
                    for (int i = 0; i < DS.PlayerX.Count; i++)
                    {

                        //image you have a train, traincar 1's pos is 10,10. 
                        //now train car 1's pos is 20,10 + movement
                        // that means train car 2's pos is 10,10  that means 2 = 1's old pos
                        // train car 3 = traincar 2's old pos at 0,10 so 3 = 2
                        // cur pos + movement = newspot
                       
                        if (i == 0) //train car 1
                        {
                            oldx = DS.PlayerX[i];
                            oldy = DS.PlayerY[i];
                            DS.PlayerX[i] += DS.MovementX;
                            DS.PlayerY[i] += DS.MovementY;
                            pointtemp = DS.Points[i]; // store value of point
                            pointtempSwap = DS.Points[i]; // store value of point in swap.
                            pointtemp.X += DS.MovementX; // iterate as needed
                            pointtemp.Y += DS.MovementY; // iterate as needed
                            DS.Points[i] = pointtemp; //give point to list 6,2,3,4,5 stored val 6
                        }
                        else
                        {
                            temp_oldx = DS.PlayerX[i]; // save train 2's pos
                            temp_oldy = DS.PlayerY[i];
                            DS.PlayerX[i] = oldx;
                            DS.PlayerY[i] = oldy;
                            oldx = temp_oldx;
                            oldy = temp_oldy;
                            
                            pointtemp = DS.Points[i]; // store cur val in temp // 6,2,3,4,5 swap 1, temp 2
                            DS.Points[i] = pointtempSwap; // store swap into cur pos // 6,1,3,4,5 swap 1, temp 2
                            pointtempSwap = pointtemp; // store current temp into swap for next go around.
                        }
                    }
                }
            }
        }
    }
}
