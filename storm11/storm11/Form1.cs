using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace storm11
{
    public partial class Form1 : Form
    {
        private List<Point> points;
        private List<Triangle> triangles = new List<Triangle>();
        private string initPath = "C:\\Users\\sukhy\\source\\repos\\storm11\\storm11\\files\\Vertices.txt";
        private string finalResult = "C:\\Users\\sukhy\\source\\repos\\storm11\\storm11\\files\\Triangles.txt";
        public Form1()
        {
            InitializeComponent();
        }
        private List<Point> FileRead(string filepath)
        {
            var result = new List<Point>();
            try
            {
                string content = File.ReadAllText(filepath);
                string pattern = @"\d+ \d+";
                Regex regex = new Regex(pattern);
                MatchCollection matches = regex.Matches(content);
                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {
                        var res = match.Value.Split(" ");
                        result.Add(
                            new Point(int.Parse(res[0]), int.Parse(res[1])));
                    }
                }
            }
            catch
            {
                throw new Exception("Error to read file");
            }
            return result;
        }
        private void WriteToFile(List<Triangle> finalTriangle, string filepath)
        {
            var res = string.Empty;
            foreach (var i in finalTriangle)
            {
                res += $"""
                T: A = {i.A.X} {i.A.Y} B = {i.B.X} {i.B.Y} C = {i.C.X} {i.C.Y}
                """;
                res += "\n";
            }
            try
            {
                File.WriteAllText(filepath, res);
            }
            catch
            {
                throw new Exception("Error write to file");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_init_Click(object sender, EventArgs e)
        {
            points = FileRead(initPath);
            for (int i = 0; i < points.Count; i += 3)
            {
                triangles.Add(new Triangle(points[i], points[i + 1], points[i + 2]));
            }
            if (triangles.Count > 0)
            {
                draw_panel.Controls.Clear();
                draw_panel.Paint += new PaintEventHandler(
                    (object sender, PaintEventArgs e) =>
                    {
                        foreach (var i in triangles)
                        {
                            DrawingTriangle(i, e.Graphics, i.Color);
                        }

                    }
                );
                draw_panel.Refresh();
            }
        }
        private List<Triangle> FindIsoscelesTriangle()
        {
            var result = new List<Triangle>();
            double Distance(Point p1, Point p2) => Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
            foreach (var i  in triangles)
            {
               
                var a = (int)Distance(i.A, i.B);
                var b = (int)Distance(i.B, i.C);
                var c = (int)Distance(i.A, i.C);
                if(a==b|| a==c|| b == c)
                {
                     i.Color = Color.Red;
                    result.Add(i);
                }
            }
            return result;
        }
        private void FindIntersect()
        {
           
            for(int i = 0; i < triangles.Count; i++)
            {
                for (int j = i+1; j < triangles.Count; j++)
                {                     
                        if (DoIntersect(triangles[i].A, triangles[i].B, triangles[j].A, triangles[j].B) ||
                            DoIntersect(triangles[i].A, triangles[i].B, triangles[j].B, triangles[j].C) ||
                            DoIntersect(triangles[i].A, triangles[i].B, triangles[j].C, triangles[j].A) ||
                            DoIntersect(triangles[i].B, triangles[i].C, triangles[j].A, triangles[j].B) ||
                            DoIntersect(triangles[i].B, triangles[i].C, triangles[j].B, triangles[j].C) ||
                            DoIntersect(triangles[i].B, triangles[i].C, triangles[j].C, triangles[j].A) ||
                            DoIntersect(triangles[i].C, triangles[i].A, triangles[j].A, triangles[j].B) ||
                            DoIntersect(triangles[i].C, triangles[i].A, triangles[j].B, triangles[j].C) ||
                            DoIntersect(triangles[i].C, triangles[i].A, triangles[j].C, triangles[j].A))
                        {
                            triangles[i].Color = Color.Aquamarine;
                            triangles[j].Color = Color.Aquamarine;
                        }
                }
            }
            
        }
        private bool DoIntersect(Point p1, Point q1, Point p2, Point q2)
        {
            int o1 = Orientation(p1, q1, p2);
            int o2 = Orientation(p1, q1, q2);
            int o3 = Orientation(p2, q2, p1);
            int o4 = Orientation(p2, q2, q1);

            if (o1 != o2 && o3 != o4)
                return true;

            if (o1 == 0 && OnSegment(p1, p2, q1)) return true;
            if (o2 == 0 && OnSegment(p1, q2, q1)) return true;
            if (o3 == 0 && OnSegment(p2, p1, q2)) return true;
            if (o4 == 0 && OnSegment(p2, q1, q2)) return true;

            return false;
        }
        private int Orientation(Point p, Point q, Point r)
        {
            int val = (q.Y - p.Y) * (r.X - q.X) - (q.X - p.X) * (r.Y - q.Y);
            if (val == 0) return 0;
            return (val > 0) ? 1 : 2;
        }
        private bool OnSegment(Point p, Point q, Point r) => q.X <= Math.Max(p.X, r.X) && q.X >= Math.Min(p.X, r.X) &&
                   q.Y <= Math.Max(p.Y, r.Y) && q.Y >= Math.Min(p.Y, r.Y);
        private void DrawingTriangle(Triangle triangle, Graphics g, Color color)
        {
            var pen = new Pen(color, 3);
            g.DrawLine(pen, triangle.A, triangle.B);
            g.DrawLine(pen, triangle.B, triangle.C);
            g.DrawLine(pen, triangle.C, triangle.A);
        }

        private void button_draw_Click(object sender, EventArgs e)
        {
            
            var a = FindIsoscelesTriangle();
            FindIntersect();
            WriteToFile(a, finalResult);
            if(triangles.Count> 0)
            {
                draw_panel.Controls.Clear();
                draw_panel.Paint += new PaintEventHandler(
                    (object sender, PaintEventArgs e) =>
                    {
                        foreach(var i in triangles)
                        {
                            DrawingTriangle(i, e.Graphics, i.Color);
                        }
                        
                    }
                );
                draw_panel.Refresh();
            }
        }
        
    }
}