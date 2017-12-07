using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetThatPepsiMax
{
    public partial class Form1 : Form
    {
        private int _x = 0;
        private int _y=0;
        private int Width = 40;
        private int Heigth = 60;
        private int _score = 0;
        private Random rand;
        private Graphics View;

        

        private int pepsix;
        private int pepsiy;
        private int pepsiWidth = 20;
        private int pepsiHeigth = 40;
        private List<int> pepsCollisonX = new List<int>();
        private List<int> pepsCollisonY = new List<int>();

        enum Position
        {
            Left, Right, Up, Down
        }

        private Position objPositon;


        public Form1()
        {
            InitializeComponent();
            rand = new Random();
            MakeRandomPos();
            _x = 150;
            _y = 150;
           
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            View = e.Graphics;
            View.DrawImage(new Bitmap("Jacob1.PNG"), _x,_y, Width,Heigth );
            label2.Text = _score.ToString();
            View.DrawImage(new Bitmap("Cola.PNG"), pepsix,pepsiy, pepsiWidth,pepsiHeigth);
            
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (objPositon == Position.Right)
            {
                _x += 15;
               
            }
            if (objPositon == Position.Left)
            {
                _x -= 15;
                
            }
            if (objPositon == Position.Up)
            {
                _y -= 15;
                
            }
            if (objPositon == Position.Down)
            {
                _y += 15;
            }
            Collision();
            Invalidate();
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Right)
            {
                objPositon = Position.Right;
            }
            if (e.KeyCode == Keys.Left)
            {
                objPositon = Position.Left;
            }
            if (e.KeyCode == Keys.Up)
            {
                objPositon = Position.Up;
            }
            if (e.KeyCode == Keys.Down)
            {
                objPositon = Position.Down;
            }
        }

        private void MakeRandomPos()
        {
            pepsix = rand.Next(10, 790);
            pepsiy = rand.Next(10, 510);
        }

        private void Collision()
        {
            for (int i = pepsix; i <= pepsix + pepsiWidth; i++)
            {
                pepsCollisonX.Add(i);
            }
            for (int i = pepsiy; i <= pepsiy + pepsiHeigth; i++)
            {
                pepsCollisonY.Add(i);
            }

            if (pepsCollisonX.Contains(_x))
            {
                ScoreTick();
                MakeRandomPos();
            }
            if (pepsCollisonY.Contains(_y))
            {
                ScoreTick();
                MakeRandomPos();
            }
            pepsCollisonX.Clear();
            pepsCollisonY.Clear();
        }

        private void ScoreTick()
        {
            _score++;
        }
    }
}
