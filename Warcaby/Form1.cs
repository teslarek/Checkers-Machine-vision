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

using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;

namespace Warcaby
{
    public partial class Form1 : Form
    {

        Image<Bgr, byte> imgOriginal;
        Image<Gray, byte> imgOriginal_gray;



        VideoCapture camera;

        CircleF[] circles;
        LineSegment2D[] linesX = new LineSegment2D[9];
        LineSegment2D[] linesY = new LineSegment2D[9];


        public Form1()
        {
            InitializeComponent();

            try
            {
                camera = new VideoCapture(0);
                camera.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameWidth, pictureBox1.Width);
                camera.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameHeight, pictureBox1.Height);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void plik()
        {
            Mat temp = new Mat();
            switch (numericUpDown1.Value)
            {
                case 0:
                    temp = CvInvoke.Imread(@"C:\Users\arekk\source\repos\Warcaby\Warcaby\Warcaby\Obrazki\Warcaby11.jpg");
                    break;
                case 1:
                    temp = CvInvoke.Imread(@"C:\Users\arekk\source\repos\Warcaby\Warcaby\Warcaby\Obrazki\Warcaby12.jpg");
                    break;
                case 2:
                    temp = CvInvoke.Imread(@"C:\Users\arekk\source\repos\Warcaby\Warcaby\Warcaby\Obrazki\Warcaby13.jpg");
                    break;
                case 3:
                    temp = CvInvoke.Imread(@"C:\Users\arekk\source\repos\Warcaby\Warcaby\Warcaby\Obrazki\Warcaby14.jpg");
                    break;
				case 4:
					temp = CvInvoke.Imread(@"C:\Users\arekk\source\repos\Warcaby\Warcaby\Warcaby\Obrazki\Warcaby15.jpg");
					break;
				case 5:
					temp = CvInvoke.Imread(@"C:\Users\arekk\source\repos\Warcaby\Warcaby\Warcaby\Obrazki\Warcaby16.jpg");
					break;
				case 6:
					temp = CvInvoke.Imread(@"C:\Users\arekk\source\repos\Warcaby\Warcaby\Warcaby\Obrazki\Warcaby17.jpg");
					break;
				case 7:
					temp = CvInvoke.Imread(@"C:\Users\arekk\source\repos\Warcaby\Warcaby\Warcaby\Obrazki\Warcaby18.jpg");
					break;
                case 8:
                    temp = CvInvoke.Imread(@"C:\Users\arekk\source\repos\Warcaby\Warcaby\Warcaby\Obrazki\Warcaby19.jpg");
                    break;
                case 9:
                    temp = CvInvoke.Imread(@"C:\Users\arekk\source\repos\Warcaby\Warcaby\Warcaby\Obrazki\Warcaby20.jpg");
                    break;
                case 10:
                    temp = CvInvoke.Imread(@"C:\Users\arekk\source\repos\Warcaby\Warcaby\Warcaby\Obrazki\Warcaby21.jpg");
                    break;
                case 11:
                    temp = CvInvoke.Imread(@"C:\Users\arekk\source\repos\Warcaby\Warcaby\Warcaby\Obrazki\Warcaby22.jpg");
                    break;
                case 12:
                    temp = CvInvoke.Imread(@"C:\Users\arekk\source\repos\Warcaby\Warcaby\Warcaby\Obrazki\Warcaby23.jpg");
                    break;
       
                default:
					break;
			}

            CvInvoke.Resize(temp, temp, pictureBox1.Size);
            imgOriginal = temp.ToImage<Bgr, byte>();
            pictureBox1.Image = imgOriginal.Bitmap;
        }

        private void button_plik_Click(object sender, EventArgs e)
        {
            plik();
        }

        private void button_Circles_Click(object sender, EventArgs e)
        {

            if (imgOriginal != null && imgOriginal_gray != null)
            {

                circles = CvInvoke.HoughCircles(imgOriginal_gray, HoughType.Gradient, 1, 20, 300, 25, 10, 50);

                for (int i = 0; i < circles.Length; i++)
                {
                    imgOriginal.Draw(circles[i], new Bgr(255, 0, 255), 2);
                }

                pictureBox1.Image = imgOriginal.Bitmap;
            }
        }

        private void button_Lines_Click(object sender, EventArgs e)
        {
            if (imgOriginal != null && imgOriginal_gray != null)
            {
                wyznacz_rogi_planszy();
                //draw_lines();
                pictureBox1.Image = imgOriginal.Bitmap;
            }
        }

        private void button_Smooth_Click(object sender, EventArgs e)
        {
            if (imgOriginal != null)
            {
                imgOriginal = imgOriginal.SmoothBilateral(0, 30, 10);
                pictureBox1.Image = imgOriginal.Bitmap;

            }
        }

        private void button_Canny_Click_1(object sender, EventArgs e)
        {
            if (imgOriginal != null)
            {
                imgOriginal_gray = imgOriginal.Canny(50, 50);
                pictureBox2.Image = imgOriginal_gray.Bitmap;
            }
        }

        private void button_canny_Click(object sender, EventArgs e)
        {
            CvInvoke.UseOpenCL = true;

            Bitmap bm = new Bitmap(pictureBox1.Image);

            Image<Gray, byte> im = new Image<Gray, byte>(bm);
            UMat u = im.ToUMat();

            CvInvoke.Canny(u, u, 150, 50);

            pictureBox2.Image = u.Bitmap;
        }

        private void button_write_position_Click(object sender, EventArgs e)
        {
            if (imgOriginal != null && circles != null)
            {
                string[] text = new string[circles.Length];
                for (int i = 0; i < circles.Length; i++)
                {
                    string kolor = "brak";
                    char kolumna;
                    string wiersz;
                    string figura = "pionek";

                    var pointF = circles[i].Center;
                    Point point = new Point((int)pointF.X, (int)pointF.Y);
                    


                    //sprawdzanie obszaru 5x5 w centrum kółka
                    for (int y = 0; y < 5; y++)
                    {
                        for (int x = 0; x < 5; x++)
                        {//jeżeli składowa czerwona i niebieska większa
                            if (
                                imgOriginal.Data[point.Y, point.X, 2] > imgOriginal.Data[point.Y, point.X, 0]+10 &&
                                imgOriginal.Data[point.Y, point.X, 2] > imgOriginal.Data[point.Y, point.X, 1]+10)
                            {
                                if (imgOriginal.Data[point.Y - 2 + y, point.X - 2 + x, 2] >= 145 && imgOriginal.Data[point.Y - 2 + y, point.X - 2 + x, 0] >= 110) figura = "damka";
                                kolor = "czerwony";

                              
                            }

                            //jeżeli składowa zielona i czerwona większa
                            else if (
                                    imgOriginal.Data[point.Y, point.X, 1] > imgOriginal.Data[point.Y, point.X, 0]+10 &&
                                    imgOriginal.Data[point.Y, point.X, 1] > imgOriginal.Data[point.Y, point.X, 2]+10)
                            {
                                if (imgOriginal.Data[point.Y - 2 + y, point.X - 2 + x, 1] >= 120 && imgOriginal.Data[point.Y - 2 + y, point.X - 2 + x, 2] >= 115 ) figura = "damka";
                                kolor = "zielony";
                            }
                        }
                    }

                  if(kolor=="brak")
                  {
                      continue;
                  }

                    int[] pole = sprawdz_pole(point);
                    kolumna = (char)('A' + pole[1]);
                    wiersz = (pole[0] + 1).ToString();


                    text[i] = $"{i}\t{kolor}\t {figura},\t wiersz:{wiersz},\t kolumna:{kolumna}";

                }
                textBox1.Lines = text;
            }

            draw_lines();
            pictureBox1.Image = imgOriginal.Bitmap;
        }


        private void wyznacz_rogi_planszy()
        {
            //szukanie rogow szachownicy
            Point lewy_punkt_d = new Point(imgOriginal.Width / 2, imgOriginal.Height / 2);
            Point lewy_punkt_g = new Point(imgOriginal.Width / 2, imgOriginal.Height / 2);
            Point prawy_punkt_d = new Point(imgOriginal.Width / 2, imgOriginal.Height / 2);
            Point prawy_punkt_g = new Point(imgOriginal.Width / 2, imgOriginal.Height / 2);

            Point lewy_punkt = new Point(imgOriginal.Width, imgOriginal.Height);
            Point prawy_punkt = new Point(0, 0);

            for (int y = 0; y < imgOriginal.Height; y++)
            {
                for (int x = 0; x < imgOriginal.Width; x++)
                {
                    if (imgOriginal_gray.Data[y, x, 0] == 255)
                    {
                        //Lewa część planszy
                        if (x < imgOriginal.Width / 2)
                        {   //Górna część planszy
                            if (y < imgOriginal.Height / 2)
                            {
                                if (Math.Sqrt(Math.Pow((imgOriginal.Width / 2) - x, 2) + Math.Pow((imgOriginal.Height / 2) - y, 2)) >
                                    Math.Sqrt(Math.Pow((imgOriginal.Width / 2) - lewy_punkt_g.X, 2) + Math.Pow((imgOriginal.Height / 2) - lewy_punkt_g.Y, 2)))
                                {
                                    lewy_punkt_g.X = x;
                                    lewy_punkt_g.Y = y;
                                }
                            }
                            //Dolna część planszy
                            else
                            {
                                if (Math.Sqrt(Math.Pow((imgOriginal.Width / 2) - x, 2) + Math.Pow((imgOriginal.Height / 2) - y, 2)) >
                                    Math.Sqrt(Math.Pow((imgOriginal.Width / 2) - lewy_punkt_d.X, 2) + Math.Pow((imgOriginal.Height / 2) - lewy_punkt_d.Y, 2)))
                                {
                                    lewy_punkt_d.X = x;
                                    lewy_punkt_d.Y = y;
                                }
                            }
                        }
                        //Prawa część planszy
                        else
                        {
                            //Górna część planszy
                            if (y < imgOriginal.Height / 2)
                            {
                                if (Math.Sqrt(Math.Pow((imgOriginal.Width / 2) - x, 2) + Math.Pow((imgOriginal.Height / 2) - y, 2)) >
                                    Math.Sqrt(Math.Pow((imgOriginal.Width / 2) - prawy_punkt_g.X, 2) + Math.Pow((imgOriginal.Height / 2) - prawy_punkt_g.Y, 2)))
                                {
                                    prawy_punkt_g.X = x;
                                    prawy_punkt_g.Y = y;
                                }
                            }
                            //Dolna część planszy
                            else
                            {
                                if (Math.Sqrt(Math.Pow((imgOriginal.Width / 2) - x, 2) + Math.Pow((imgOriginal.Height / 2) - y, 2)) >
                                    Math.Sqrt(Math.Pow((imgOriginal.Width / 2) - prawy_punkt_d.X, 2) + Math.Pow((imgOriginal.Height / 2) - prawy_punkt_d.Y, 2)))
                                {
                                    prawy_punkt_d.X = x;
                                    prawy_punkt_d.Y = y;
                                }
                            }
                        }



                        if (x < lewy_punkt.X)
                        { lewy_punkt.X = x; }

                        if (y < lewy_punkt.Y)
                        { lewy_punkt.Y = y; }


                        if (x > prawy_punkt.X)
                        { prawy_punkt.X = x; }

                        if (y > prawy_punkt.Y)
                        { prawy_punkt.Y = y; }

                    }

                }
            }

         

            //zaznaczenie rogów planszy
            imgOriginal.Draw(new Rectangle(lewy_punkt_g, new Size(5, 5)), new Bgr(0, 255, 0), 2);
            imgOriginal.Draw(new Rectangle(prawy_punkt_g, new Size(5, 5)), new Bgr(0, 255, 0), 2);
            imgOriginal.Draw(new Rectangle(prawy_punkt_d, new Size(5, 5)), new Bgr(0, 255, 0), 2);
            imgOriginal.Draw(new Rectangle(lewy_punkt_d, new Size(5, 5)), new Bgr(0, 255, 0), 2);

            //Przypisanie linii
            for (int i = 0; i < 9; i++)
            {
                linesY[i].P1 = new Point(lewy_punkt_g.X + (i * (prawy_punkt_g.X - lewy_punkt_g.X) / 8), lewy_punkt_g.Y + ((i * (prawy_punkt_g.Y - lewy_punkt_g.Y) / 8)));
                linesY[i].P2 = new Point(lewy_punkt_d.X + (i * (prawy_punkt_d.X - lewy_punkt_d.X) / 8), lewy_punkt_d.Y + ((i * (prawy_punkt_d.Y - lewy_punkt_d.Y) / 8)));
                linesX[i].P1 = new Point(lewy_punkt_g.X + (i * (lewy_punkt_d.X - lewy_punkt_g.X) / 8), lewy_punkt_g.Y + ((i * (lewy_punkt_d.Y - lewy_punkt_g.Y) / 8)));
                linesX[i].P2 = new Point(prawy_punkt_g.X + (i * (prawy_punkt_d.X - prawy_punkt_g.X) / 8), prawy_punkt_g.Y + ((i * (prawy_punkt_d.Y - prawy_punkt_g.Y) / 8)));
            }



            //  imgOriginal.ROI = r;
            pictureBox1.Image = imgOriginal.Bitmap;
            //pictureBox2.Image = imgOriginal.Bitmap;
        }

      
        private void draw_lines()
        {
            for (int i = 0; i < linesX.Length; i++)
            {
                imgOriginal.Draw(linesX[i], new Bgr(0, 255, 150), 1);
                imgOriginal.Draw(linesY[i], new Bgr(0, 255, 150), 1);
            }
        }

     
        private int[] sprawdz_pole(Point point)
        {
            int x = -1;
            int y = -1;
            int[] wynik;
            //sprawdzamy od którego przedziału nalezy dany punkt
            for (int i = 0; i < linesY.Length - 1; i++)
            {
                if (linesY[i].Side(point) < 0 && linesY[i + 1].Side(point) > 0)
                {
                    x = i;
                    break;
                }
            }

            for (int i = 0; i < linesX.Length - 1; i++)
            {
                if (linesX[i].Side(point) > 0 && linesX[i + 1].Side(point) < 0)
                {
                    y = i;
                    break;
                }
            }
            //Jeżeli przynajmniej w jednym kierunku jest poza granicami to zwraca ze poza plansza
            if (x == -1 || y == -1)
            {
                x = -1;
                y = -1;
            }
            wynik = new int[] { y, x };
            return wynik;
        }

		private void Cam_Click(object sender, EventArgs e)
		{

            Mat temp = new Mat();
            camera.Read(temp);
            CvInvoke.Resize(temp, temp, pictureBox1.Size);
            imgOriginal = temp.ToImage<Bgr, byte>();
            pictureBox1.Image = imgOriginal.Bitmap;
        }
	}
}