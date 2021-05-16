using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Data.SQLite;

namespace PaintApp
{
    public partial class Form1 : Form
    {
        String connectionString = "Data Source=PaintDB.db;Version=3;";
        SQLiteConnection conn;
        public int ch;
        Graphics mg;
        Pen p;
        public int x1, x2, y1, y2;
        public int m1, m2, n1, n2;
        public int u1, u2, v1, v2;
        public int g1, g2, f1, f2;
        public bool drag;
        public string d = DateTime.Now.ToString();
        int countDown = 2;
        int countDown2 = 2;
        int countDown3 = 2;
        Random random;
        public Form1()
        {
            InitializeComponent();
            ch = 0;
            mg = this.CreateGraphics();
            p = new Pen(Color.Black);
            drag = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ch = 1;
            conn.Open();
            String insertQuery = "Insert into Info(Shape, Timestamp) values('" + button1.Text + "','" + d + "')";
            SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn);
            int count = cmd.ExecuteNonQuery();
            conn.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ch = 2;
            conn.Open();
            String insertQuery = "Insert into Info(Shape, Timestamp) values('" + button2.Text + "','" + d + "')";
            SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn);
            int count = cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult rs;
            rs = colorDialog1.ShowDialog();
            if (rs==DialogResult.OK)
            {
                p.Color = colorDialog1.Color;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            x1 = e.X;
            y1 = e.Y;

            if (radioButton1.Checked)
            {
                p.Width = 5;
            }
            if (radioButton2.Checked)
            {
                p.Width = 10;
            }
            if (radioButton3.Checked)
            {
                p.Width = 15;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
            if (ch == 2)
            {
                if (x2 - x1 == y2 - y1)
                {
                    mg.DrawEllipse(p, x1, y1, x2 - x1, y2 - y1);
                }
            }
            else if (ch == 3)
            {
                mg.DrawLine(p, x1, y1, x2, y2);
            }
            else if (ch == 4)
            {
                mg.DrawRectangle(p, x1, y1, x2 - x1, y2 - y1);
            }
            else if (ch == 5)
            {
                mg.DrawEllipse(p, x1, y1, x2 - x1, y2 - y1);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            x2 = e.X;
            y2 = e.Y;

            if(drag == true && ch == 1)
            {
                mg.DrawLine(p, x1, y1, x2, y2);
                x1 = x2;
                y1 = y2;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            mg.Clear(Color.White);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new SQLiteConnection(connectionString);
            random = new Random();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            g1 += 250;
            f1 = 150;
            g2 = g1;
            f2 = 300;
            mg.DrawLine(p, g1, f1, g2, f2);
            countDown--;          
            if (countDown == 0)
            {
                timer1.Enabled = false;
                countDown = 2;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (timer3.Enabled)
                timer3.Enabled = false;
            else
                timer3.Enabled = true;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            u1 = 375;
            v1 = 75;
            u2 += 250;
            v2 = 150;
            mg.DrawLine(p, u1, v1, u2, v2);
            countDown3--;
            if (countDown3 == 0)
            {
                timer3.Enabled = false;
                countDown3 = 2;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
                timer1.Enabled = false;
            else
                timer1.Enabled = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (timer2.Enabled)
                timer2.Enabled = false;
            else
                timer2.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {      
            m1 = 250;
            n1 += 150;
            n2 = n1;
            m2 = 500;
            mg.DrawLine(p, m1, n1, m2, n2);
            countDown2--;
            if (countDown2 == 0)
            {
                timer2.Enabled = false;
                countDown2 = 2;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ch = 3;
            conn.Open();
            String insertQuery = "Insert into Info(Shape, Timestamp) values('" + button3.Text + "','" + d + "')";
            SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn);
            int count = cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ch = 4;
            conn.Open();
            String insertQuery = "Insert into Info(Shape, Timestamp) values('" + button4.Text + "','" + d + "')";
            SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn);
            int count = cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ch = 5;
            conn.Open();
            String insertQuery = "Insert into Info(Shape, Timestamp) values('" + button5.Text + "','" + d + "')";
            SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn);
            int count = cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
