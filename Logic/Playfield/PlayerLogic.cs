using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Zap.Logic
{
    public class PlayerLogic : Form1
    {
        readonly Graphiz.Player PGraph = new Graphiz.Player();

        public void GenericPlayerLogic(object sender, PaintEventArgs e)
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
                    DS.PlayerX.Add(point9.X);
                    DS.PlayerY.Add(point9.Y);
                    PGraph.PlayerGeneric(point9, e);
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
                    for (int i = 0; i< DS.PlayerX.Count; i++)
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
                        }
                        else
                        {
                            temp_oldx = DS.PlayerX[i]; // save train 2's pos
                            temp_oldy = DS.PlayerY[i];
                            DS.PlayerX[i] = oldx;
                            DS.PlayerY[i] = oldy;
                            oldx = temp_oldx;
                            oldy = temp_oldy;
                        }
                        Point Point9 = new Point(DS.PlayerX[i], DS.PlayerY[i]);
                        PGraph.PlayerGeneric(Point9, e);
                    }
                }
                else
                {
                    for (int i = 0; i< 10; i++)
                    {
                        Point Point9 = new Point(DS.PlayerX[i], DS.PlayerY[i]);
                        PGraph.PlayerGeneric(Point9, e);
                    }
                }
            }
        }
    }
}
