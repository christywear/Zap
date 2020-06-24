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
        private Data.DataStorage ds = new Data.DataStorage();

        public Form1()
        {
            
            InitializeComponent();
            //Thread play = new Thread(new ThreadStart(GameStartLoader));
            //play.Start();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Graphiz.LevelSelect LS = new Graphiz.LevelSelect();
            pictureBox1.Paint += new PaintEventHandler(LS.DrawLineLeftOrRight);


        }

        public Data.DataStorage DS { get { return ds; } set { ds = value; } }

        private void PictureBox1_KeyDown(object sender, KeyEventArgs e)
        {
            Logic.InputReactor IR = new Logic.InputReactor();
            string drawthis = IR.PictureBox1_KeyDown(sender, e);
            DrawThis(drawthis);
        }

        private void DrawThis(string drawing)
        {
           
           
            switch(drawing)
            {
                case "LS.GoLeft":
                case "LS.GoRight":
                    Graphiz.LevelSelect LS = new Graphiz.LevelSelect();
                    pictureBox1.Paint += new PaintEventHandler(LS.Clearnumline);
                    pictureBox1.Paint += new PaintEventHandler(LS.DrawLineLeftOrRight);
                    pictureBox1.Invalidate();
                    break;
                /*case "GUI.LoadPicture":
                    Graphiz.Gui GUI = new Graphiz.Gui();
                    pictureBox1.Paint += new PaintEventHandler(GUI.PictureboxStuff);
                    pictureBox1.Invalidate();
                    break;*/
                case "Invalid":
                    pictureBox1.Invalidate();
                    break;
                default:
                    break;
            }
        }
    }
}
