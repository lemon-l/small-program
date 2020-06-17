using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace 天天打飞机
{
   public class EnemyPlane:MyPlane
    {
       public int  E_X = 250, E_Y = 0;
        public int blood = 10;
       //public EnemyPlane()
       //{
       //    Rec.Height = PLANE_SIZE;
       //    Rec.Width = PLANE_SIZE;
       //    Uri uri = new Uri("..\\..\\Images\\3.jpg", UriKind.Relative);
       //    BitmapImage bimg = new BitmapImage(uri);
       //    Rec.Fill = new ImageBrush(bimg);
       //    SetPosition(ref E_X, ref E_Y);
       //}
       public EnemyPlane(double x,string str)
       {
           Rec.Height = PLANE_SIZE;
           Rec.Width = PLANE_SIZE;
           E_X = (int)x;
           Uri uri = new Uri(str, UriKind.Relative);
           BitmapImage bimg = new BitmapImage(uri);
           Rec.Fill = new ImageBrush(bimg);
           SetPosition(ref E_X, ref E_Y);
       }
       public  void Move()
       {
          
           Random random = new Random();
           int dir=random.Next(0, 4);
           switch (dir)
           {

               case 1:
                   if (550 > this.E_Y)
                       this.E_Y += PLANE_SIZE;
                  // SetPosition(ref this.E_X, ref this.E_Y);
                   break;
               default:
                   break;
           }
       }
    }
}
