using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using Zap.Logic;
using Zap.Properties;

namespace Zap
{
    public class Apples : Form1
    {
        public Apples() { }
        static List<Image> erp = new List<Image>();
        static List<Point> appleSauce = new List<Point>();
        private static int numberOfApples = 20; 
        public List<Image> Erp { get { return erp; } }
        public List<Point> AppleSauce { get { return appleSauce; } }
        private readonly string name = "Apple";
        public string Apple { get { return name; } }
        private static bool hasCollided = false;

        public int NumberOfApples
        {
            get { return numberOfApples; }
            set { numberOfApples = value; }
        }

        public bool HasCollided
        {
            get { return hasCollided; }
            set { hasCollided = value; }
        }

        public void Collider(PlayerLogic other) // until I make a new obj to inheret from
        {
            if (HasCollided)
            {
                if (other.Name == "Player")
                {
                    //AppleSauce.RemoveAt(AppleSauce.IndexOf(this.pictureBox1.Location));
                    this.Hide();
                    HasCollided = false;
                }
            }
        }

        public Bitmap ResizeImage(Image image, int width, int height)
        {
        var destRect = new Rectangle(0, 0, width, height);
        var destImage = new Bitmap(width, height);

        destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using var wrapMode = new ImageAttributes();
                wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
            }

        return destImage;
        }
    }
}

