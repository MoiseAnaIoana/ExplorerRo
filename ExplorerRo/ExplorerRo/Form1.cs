using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExplorerRo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.Init(this, pictureBox1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Engine.robot == null)
                Engine.robot = new Explorer();
            else
            {
                Engine.grp.Clear(Color.PeachPuff);
                for (int i = 0; i < Engine.n; i++)
                    for (int j = 0; j < Engine.m; j++)
                        if (!Engine.fog[i, j])
                            Engine.grp.FillRectangle(new SolidBrush(Color.Green), i * Engine.size, j * Engine.size, Engine.size, Engine.size);
                Engine.grp.FillRectangle(new SolidBrush(Color.Gold), Engine.robot.destination.X * Engine.size, Engine.robot.destination.Y * Engine.size, Engine.size, Engine.size);
                Engine.robot.Do();
                pictureBox1.Image = Engine.bmp;
            }
        }
    }
}
