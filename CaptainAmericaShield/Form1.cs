using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptainAmericaShield
{
    public partial class Form1 : Form
    {

        private Graphics graphics = null;
        private int centralHorizontalLine;
        private int centralVerticalLine;
        private int circleSize = 225;

        public Form1()
        {
            InitializeComponent();
            graphics = this.CreateGraphics();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Draw();
        }

        private void Draw()
        {
            centralHorizontalLine = (this.Width / 2) - 8;
            centralVerticalLine = (this.Height / 2) - 7;
            //
            DrawCircle(Color.Red, centralHorizontalLine, centralVerticalLine - ((circleSize + 337) / 2), (circleSize + 337));//#1 CIRCLE
            //
            DrawCircle(Color.White, centralHorizontalLine, centralVerticalLine - ((circleSize + 225) / 2), (circleSize + 225));//#2 CIRCLE
            //
            DrawCircle(Color.Red, centralHorizontalLine, centralVerticalLine - ((circleSize + 112) / 2), (circleSize + 112));//#3 CIRCLE
            //
            //DrawVerticalLine(Color.Red, centralHorizontalLine, 0, this.Height);// -- MARCAÇÃO VERTICAL VERTICAL USO NOS TESTES
            //DrawHorizontalLine(Color.Red, 0, this.Width, centralVerticalLine);//-7 --- MARCAÇÃO HORIZONTAL VERTICAL USO NOS TESTES
            //
            DrawCircle(Color.DarkBlue, centralHorizontalLine, centralVerticalLine - (circleSize / 2), circleSize);//#4 CIRCLE
            //
            Point center = new Point(centralHorizontalLine, centralVerticalLine);
            int outerRadius = 100;
            int innerRadius = 50;
            Color color = Color.White;

            DrawStar(graphics, center, outerRadius, innerRadius, color);
        }

        private void DrawHorizontalLine(Color color, int x1, int x2, int y)
        {
            graphics = this.CreateGraphics();
            graphics.DrawLine(new Pen(new SolidBrush(color), 2), x1, y, x2, y);
        }

        private void DrawVerticalLine(Color color, int x, int y1, int y2)
        {
            graphics = this.CreateGraphics();
            graphics.DrawLine(new Pen(new SolidBrush(color), 2), x, y1, x, y2);
        }

        /// <summary>
        /// this part of the code was created by chatGPT
        /// </summary>
        /// <param name="g"></param>
        /// <param name="center"></param>
        /// <param name="outerRadius"></param>
        /// <param name="innerRadius"></param>
        /// <param name="color"></param>
        private void DrawStar(Graphics g, Point center, int outerRadius, int innerRadius, Color color)
        {
            PointF[] points = new PointF[10];

            double angle = Math.PI / 5;
            double startAngle = -Math.PI / 2;
            for (int i = 0; i < 10; i++)
            {
                double r = (i % 2 == 0) ? outerRadius : innerRadius;
                double a = startAngle + angle * i;
                points[i] = new PointF(
                    (float)(center.X + r * Math.Cos(a)),
                    (float)(center.Y + r * Math.Sin(a))
                );
            }

            using (SolidBrush brush = new SolidBrush(color))
            {
                g.FillPolygon(brush, points);
            }
        }

        private void DrawCircle(Color color, int x, int y, int circleSize)
        {
            graphics = this.CreateGraphics();
            Rectangle rectangle = new Rectangle((x - (circleSize / 2)), y, circleSize, circleSize);
            graphics.FillEllipse(new SolidBrush(color), rectangle);
        }
    }
}
