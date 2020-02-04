using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExplorerRo
{
    public abstract class RoBoT
    {
        public List<Point> path = new List<Point>();
        public Point position, destination;
        
        public RoBoT()
        {
            position = Engine.Base;
            DrawRoBoT();
        }

        public abstract void Do();
        public abstract Point GetNewDestination();

        public void DrawRoBoT()
        {
            Engine.grp.FillEllipse(new SolidBrush(Color.DodgerBlue), position.X * Engine.size, position.Y * Engine.size, Engine.size, Engine.size);
        }
    }

    public class Explorer : RoBoT
    {
        public override void Do()
        {
            if (path.Count == 0)
            {
                destination = GetNewDestination();
                path = Engine.Lee(position, destination);
            }
            else
            {
                position = path[path.Count - 1];
                path.RemoveAt(path.Count - 1);
                for (int i = position.X - 2; i <= position.X + 2; i++)
                    for (int j = position.Y - 2; j <= position.Y + 2; j++)
                        if (i >= 0 && i < Engine.n && j >= 0 && j < Engine.m)
                            Engine.fog[i, j] = false;
                DrawRoBoT();
            }
        }

        public override Point GetNewDestination()
        {
            List<Point> points = new List<Point>();
            for (int i = 0; i < Engine.n; i++)
                for (int j = 0; j < Engine.m; j++)
                    if (Engine.fog[i, j])
                        points.Add(new Point(i, j));
            int p = Engine.rnd.Next(points.Count);
            if(points.Count==0)
            {
                Engine.form.timer1.Stop();
                MessageBox.Show("You uncovered the whole map!");
                Engine.form.Close();
                return new Point();
            }
            return points[p];
        }
    }
}
