using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
namespace 天天打飞机
{
   public class Bullet
    {
        public double X, Y;
        public Rectangle B_Rec = new Rectangle();
        public const double BULLET_SIZE = MyPlane.PLANE_SIZE /3;
        public Bullet(double x, double y,String str)
        {
            this.X = x;
            this.Y = y;
            Uri uri = new Uri(str, UriKind.Relative);
            BitmapImage bimg = new BitmapImage(uri);
            B_Rec.Fill = new ImageBrush(bimg);
            B_Rec.Height = BULLET_SIZE;      
            B_Rec.Width = BULLET_SIZE;
        }
    }
}
