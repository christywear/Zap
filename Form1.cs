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

            Graphiz.LevelSelect LS = new Graphiz.LevelSelect();
            pictureBox1.Paint += new PaintEventHandler(LS.DrawLineLeftOrRight);
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            LaunchStuffAsync();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

            
        }
        private async Task LaunchStuffAsync()
        {
            if(DS.Selected)
                Makeapples();
            await Task.Run(() => Playfield());
            
        }

        public Data.DataStorage DS { get { return ds; } set { ds = value; } }


        public void Makeapples()
        {
            Apples apple = new Apples();
            var bmp = new Bitmap(Resources.apple);
            bmp = apple.ResizeImage(bmp, 20, 20);
            bmp.MakeTransparent(bmp.GetPixel(0, 0));
            

            for (int i = 0; i < 20; i++)
            {
                apple.Erp.Add(bmp);
            }

                Random rnd = new Random();
            foreach (Image image in apple.Erp)
            {
                Point pointyapplesauce = new Point(rnd.Next(20, 980), rnd.Next(50, 700));
                apple.AppleSauce.Add(pointyapplesauce);

            }
            
            int iCtr = 0;
            foreach (Image i in apple.Erp)
            {
                PictureBox eachPictureBox = new PictureBox
                {
                    BackColor = System.Drawing.Color.Transparent,
                    Parent = pictureBox1,
                    Size = new Size(20, 20),
                    Location = apple.AppleSauce[iCtr],
                    Image = i
                };
                iCtr++;
            }
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
                        this.Invoke((MethodInvoker)delegate
                        {
                            this.Makeapples();
                        });
                    }

                    pictureBox1.Paint += new PaintEventHandler(Clear);
                    pictureBox1.Paint += new PaintEventHandler(GUI.PictureboxStuff);
                    pictureBox1.Invalidate();
                    Logic.PlayerLogic PL = new Logic.PlayerLogic();
                    pictureBox1.Paint += new PaintEventHandler(PlayDraw.PlayerGeneric);
                    pictureBox1.Invalidate();
                    if (DS.Points[0].X < 9 || DS.Points[0].X > 968 || DS.Points[0].Y < 50 || DS.Points[0].Y > 732)
                    {
                        GL.GenericLogicReset(); // respawn
                    }
                }
            
                else
                {
                    pictureBox1.Paint += new PaintEventHandler(Clear);
                    pictureBox1.Paint += new PaintEventHandler(LS.Clearnumline);
                    pictureBox1.Paint += new PaintEventHandler(LS.DrawLineLeftOrRight);
                    pictureBox1.Invalidate();
                }
                System.Threading.Thread.Sleep(800 / DS.LevelSelected);
            } while (true);
        }

        private void Clear(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Black);
            this.Invalidate();
        }
    }
}
