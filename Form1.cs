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

namespace Zap
{
    public partial class Form1 : Form
    {
        private static bool playFieldStarted = false;
        private Data.DataStorage ds = new Data.DataStorage();

        public Form1()
        {
            
            InitializeComponent();
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Graphiz.LevelSelect LS = new Graphiz.LevelSelect();
            pictureBox1.Paint += new PaintEventHandler(LS.DrawLineLeftOrRight);
            LaunchStuffAsync();

        }

        private async Task LaunchStuffAsync()
        {
             await Task.Run(() => Playfield());
            
        }

        public Data.DataStorage DS { get { return ds; } set { ds = value; } }

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
                    
                    pictureBox1.Paint += new PaintEventHandler(Clear);
                    pictureBox1.Paint += new PaintEventHandler(GUI.PictureboxStuff);
                    pictureBox1.Invalidate();
                    Logic.PlayerLogic PL = new Logic.PlayerLogic();
                    pictureBox1.Paint += new PaintEventHandler(PlayDraw.PlayerGeneric);
                    pictureBox1.Invalidate();
                    if (DS.Points[0].X < 9 || DS.Points[0].X > 968 || DS.Points[0].Y < 50 || DS.Points[0].Y > 740)
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
