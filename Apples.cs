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
        
        private static readonly List<Image> erp = new List<Image>();
        private static readonly List<Point> appleSauce = new List<Point>();
        private static int numberOfApples = 20; 
        public List<Image> Erp { get { return erp; } }
        public List<Point> AppleSauce { get { return appleSauce; } }

        //public string NameOfThisObj { get; } = "Apple";
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

        public void Collider(PlayerLogic other, Point playerpos) // until I make a new obj to inheret from
        {
            if (HasCollided)
            {
                //if (other.NameOfThisObj == "Player")
               // {
                    int indexPos = AppleSauce.IndexOf(playerpos);
                    if (AppleSauce.Contains(playerpos))
                    {
                       

                       // Erp[indexPos].Dispose();
                        //Erp.RemoveAt(indexPos);
                        AppleSauce.RemoveAt(indexPos);
                        NumberOfApples--;

                        HasCollided = false;
                    }
               // }
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

