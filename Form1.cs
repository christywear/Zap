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

        public Form1()
        {
            
            InitializeComponent();
            //Thread play = new Thread(new ThreadStart(GameStartLoader));
            //play.Start();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Graphiz.LevelSelect LS = new Graphiz.LevelSelect();
            LS.LoadLevel();


        }
       
        private void pictureBox1_KeyDown(object sender, KeyEventArgs e)
        {
            Logic.InputReactor IR = new Logic.InputReactor();
            IR.pictureBox1_KeyDown(sender, e);

        }


    }
}
