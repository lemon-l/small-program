using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Threading;
using System.Windows.Input;
namespace 天天打飞机
{
    public class MyPlane:Warcraft
    {
        public  Rectangle Rec = new Rectangle();
        public int X=250, Y=550;
        public  enum Direction {stand,up,down,left,right}
        public Direction Dir=Direction.stand;
        //private List<Bullet> myBullet;
        public double midPosition=0;//记录飞机的中点位置用来初始化子弹的位置
        public MyPlane()
        {
            
            Rec.Height = PLANE_SIZE;
            Rec.Width = PLANE_SIZE;
            //填充图片到矩形中
            Uri uri = new Uri("..\\..\\Images\\1.png", UriKind.Relative);
            BitmapImage bimg = new BitmapImage(uri);
            Rec.Fill = new ImageBrush(bimg);
            SetPosition(ref X,ref Y);
        }
        public void SetPosition( int x,  int y)
        {
            Canvas.SetLeft(this.Rec,x);    //设置矩形位置
            Canvas.SetTop(this.Rec,y);
        }
        public void SetPosition(ref int x,ref int y)
        {
            Canvas.SetLeft(this.Rec, x);    //设置矩形位置
            Canvas.SetTop(this.Rec,y);
        }
        public void Move()
        {
            //this.Y += PLANE_SIZE;
            //SetPosition(X, Y);
          // if(false==Is_Beyond_Pane(this.X,this.Y))
            switch (Dir)
            {
                case Direction.up:
                    if(0<this.Y)
                    this.Y -= PLANE_SIZE;
                    SetPosition(ref this.X, ref this.Y);
                    this.Dir = Direction.stand;
                    break;
                case Direction.down:
                    if(550>this.Y)
                    this.Y += PLANE_SIZE;
                    SetPosition(ref this.X, ref this.Y);
                    this.Dir = Direction.stand;
                    break;
                case Direction.left:
                    if(0<this.X)
                    this.X -= PLANE_SIZE;
                    SetPosition(ref this.X, ref this.Y);
                    this.Dir = Direction.stand;
                    break;
                case Direction.right:
                    if(500>this.X)
                    this.X += PLANE_SIZE;
                    SetPosition(ref this.X, ref this.Y);
                    this.Dir = Direction.stand;
                    break;
                default :
                    break;
            }
        }

        private bool Is_Beyond_Pane(int x, int y)
        {
            if (0 >= x || 500 <= x || 0 >= y || 550 <=y)
                return true;
            else
                return false;
        }
    }
}
