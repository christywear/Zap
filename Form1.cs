using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using Zap.Graphiz;
using Zap.Properties;
using System.Media;
using System.Drawing.Imaging;

namespace Zap
{
    public partial class Form1 : Form
    {
        
        private Data.DataStorage ds = new Data.DataStorage();

        public Form1()
        {
            
            InitializeComponent();
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            //Graphiz.LevelSelect LS = new Graphiz.LevelSelect();
            //pictureBox1.Paint += new PaintEventHandler(LS.DrawLineLeftOrRight);
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            LaunchStuff();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

            
        }
        private void LaunchStuff()
        {
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            Task.Run(() => Playfield());
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
           
        }

        public Data.DataStorage DS { get { return ds; } set { ds = value; } }


        public void Makeapples()
        {
            
            Apples Ambrosia = new Apples();
            var bmp = new Bitmap(Resources.apple);
            bmp = Ambrosia.ResizeImage(bmp, 20, 20);
            bmp.MakeTransparent(bmp.GetPixel(0, 0));
            
            
            for (int i = 0; i < Ambrosia.NumberOfApples; i++)
            {
                Ambrosia.Erp.Add(bmp);
            }
            
                Random rnd = new Random();
            foreach (Image _ in Ambrosia.Erp)
            {
                Point pointyapplesauce = new Point(rnd.Next(20, 980), rnd.Next(50, 700));
                Ambrosia.AppleSauce.Add(pointyapplesauce);

            }
            
            int iCtr = 0;
            foreach (Image i in Ambrosia.Erp)
            {
                PictureBox eachPictureBox = new PictureBox
                {
                    BackColor = System.Drawing.Color.Transparent,
                    Parent = pictureBox1,
                    Size = new Size(20, 20),
                    Location = Ambrosia.AppleSauce[iCtr],
                    Image = i
                };
                iCtr++;
            }
            pictureBox1.Invalidate();
            //CollisionController();
        }

        private void PictureBox1_KeyDown(object sender, KeyEventArgs e)
        {
            Logic.InputReactor IR = new Logic.InputReactor();
            IR.PictureBox1_KeyDown(sender, e);

        }

        private void Playfield()
        {
            
            Graphiz.Gui GUI = new Graphiz.Gui();
            Graphiz.LevelSelect LS = new Graphiz.LevelSelect();
            Graphiz.Player PlayDraw = new Graphiz.Player();
            Logic.GuiLogic GL = new Logic.GuiLogic();
            

            do
            {
                if (DS.Selected)
                {
                    
                    if (!DS.NotDoneThisYet)
                    {
                        DS.NotDoneThisYet = true;
                        Invoke((MethodInvoker)delegate
                        {
                            this.Makeapples();
                        });
                    }
                    
                    pictureBox1.Paint += new PaintEventHandler(Clear);
                    pictureBox1.Paint += new PaintEventHandler(GUI.PictureboxStuff);
                    Invoke((MethodInvoker)delegate
                    {
                        pictureBox1.Invalidate();
                    });

                    Logic.PlayerLogic PL = new Logic.PlayerLogic();
                    PL.GenericPlayerLogic();
                    pictureBox1.Paint += new PaintEventHandler(PlayDraw.PlayerGeneric);
                    Invoke((MethodInvoker)delegate
                    {
                        pictureBox1.Invalidate();
                    });

                    
                    if (DS.Points.Count > 0)
                    {
                        if (DS.Points[0].X < 9 || DS.Points[0].X > 968 || DS.Points[0].Y < 50 || DS.Points[0].Y > 732)
                        {
                            GL.GenericLogicReset(); // respawn
                        }
                       
                    }

                }

                else
                {
                    pictureBox1.Paint += new PaintEventHandler(Clear);
                    pictureBox1.Paint += new PaintEventHandler(LS.Clearnumline);
                    pictureBox1.Paint += new PaintEventHandler(LS.DrawLineLeftOrRight);
                    Invoke((MethodInvoker)delegate
                    {
                    pictureBox1.Invalidate();
                    });
                    System.Threading.Thread.Sleep(800 / DS.LevelSelected);
                }
            } while (true);
        }

        public void CollisionController()
        {
            
            do
            {
                if (DS.Selected)
                { 
                    
                    Apples apple = new Apples();
                    Logic.PlayerLogic PL = new Logic.PlayerLogic();
                   
                    if (DS.Points.Count > 0 && apple.AppleSauce.Count > 0)
                    {
                        Point playerpos = new Point(DS.Points[0].X, DS.Points[0].Y);
                        int xmax = 22;
                        int xmin = -22;
                        int ymax = 22;
                        int ymin = -22;
                        foreach (Point p in apple.AppleSauce)
                        {
                            if (p == playerpos || (playerpos.X + xmin > p.X && playerpos.X + xmax < p.X) && (playerpos.Y + ymin > p.Y && playerpos.Y + ymax < p.Y))
                            {

                                apple.HasCollided = true;
                                PL.HasCollided = true;
                                apple.Collider(PL, playerpos);
                                PL.Collider(apple, playerpos);
                                Invoke((MethodInvoker)delegate
                                {
                                    pictureBox1.Invalidate();
                                });


                            }
                        }
                    }
                }
            } while (true);
        }

        private void Clear(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Black);
                      
        }
    }
}
