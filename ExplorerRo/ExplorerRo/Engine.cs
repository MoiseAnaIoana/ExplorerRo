using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExplorerRo
{
    public static class Engine
    {
        public static int[,] map;
        public static bool[,] fog;
        public static int n, m, size = 25;
        public static PictureBox display;
        public static Form1 form;
        public static Point Base;
        public static Graphics grp;
        public static Bitmap bmp;
        public static Random rnd= new Random();
        public static Explorer robot = null;
         
        public static void Init(Form1 f, PictureBox p)
        {
            form = f;
            Base = new Point(2, 3);
            display = p;
            bmp = new Bitmap(p.Width, p.Height);
            grp = Graphics.FromImage(bmp);
            n = p.Width / size;
            m = p.Height / size;
            map = new int[n, m];
            fog = new bool[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    fog[i, j] = true;
            grp.Clear(Color.PeachPuff);
            p.Image = bmp;
        }

        public static List<Point> Lee(Point start, Point end)
        {
            List<Point> path = new List<Point>();
            Coada A = new Coada();
            A.Push(new Nod(start.X, start.Y, 1));
            int[,] Aux = new int[n, m];

            while (A.dim != 0)
            {
                Nod curent = A.Pop();
                if (curent.i - 1 >= 0 && Aux[curent.i - 1, curent.j] == 0)
                {
                    A.Push(new Nod(curent.i - 1, curent.j, curent.val + 1));
                    Aux[curent.i - 1, curent.j] = curent.val + 1;
                }
                if (curent.j - 1 >= 0 && Aux[curent.i, curent.j - 1] == 0)
                {
                    A.Push(new Nod(curent.i, curent.j - 1, curent.val + 1));
                    Aux[curent.i, curent.j - 1] = curent.val + 1;
                }
                if (curent.i + 1 < n && Aux[curent.i + 1, curent.j] == 0)
                {
                    A.Push(new Nod(curent.i + 1, curent.j, curent.val + 1));
                    Aux[curent.i + 1, curent.j] = curent.val + 1;
                }
                if (curent.j + 1 < m && Aux[curent.i, curent.j + 1] == 0)
                {
                    A.Push(new Nod(curent.i, curent.j + 1, curent.val + 1));
                    Aux[curent.i, curent.j + 1] = curent.val + 1;
                }
            }

            if (Aux[end.X, end.Y] == 0)
                return null;
            path.Add(end);
            Point crt = end;

            while (Aux[crt.X, crt.Y] > 2)
            {
                if (crt.X - 1 >= 0 && Aux[crt.X - 1, crt.Y] == Aux[crt.X, crt.Y] - 1)
                    crt.X--;
                else if (crt.Y - 1 >= 0 && Aux[crt.X, crt.Y - 1] == Aux[crt.X, crt.Y] - 1)
                    crt.Y--;
                else if (crt.X + 1 < n && Aux[crt.X + 1, crt.Y] == Aux[crt.X, crt.Y] - 1)
                    crt.X++;
                else if (crt.Y + 1 < m && Aux[crt.X, crt.Y + 1] == Aux[crt.X, crt.Y] - 1)
                    crt.Y++;
                path.Add(new Point(crt.X, crt.Y));
            }
            return path;
        }
    }
}
