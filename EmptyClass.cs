using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

public class Sword
{
    public Point Start { get; set; }
    public Point End { get; set; }

    public Sword(Point start, Point end)
    {
        Start = start;
        End = end;
    }

    public void Draw(Graphics g)
    {
        using (Pen pen = new Pen(Color.Gray, 5))
        {
            g.DrawLine(pen, Start, End); // Рисуем лезвие меча
            g.DrawEllipse(pen, Start.X - 5, Start.Y - 5, 10, 10); // Рисуем ручку
        }
    }
}

public class Shield
{
    public Rectangle Rect { get; set; }

    public Shield(Rectangle rect)
    {
        Rect = rect;
    }

    public void Draw(Graphics g)
    {
        using (Brush brush = new SolidBrush(Color.Blue))
        {
            g.FillRectangle(brush, Rect); // Рисуем щит
            g.DrawRectangle(Pens.Black, Rect); // Рисуем обводку щита
        }
    }
}

public class GameForm : Form
{
    private Sword sword;
    private Shield shield;

    public GameForm()
    {
        this.Text = "Sword and Shield";
        this.Size = new Size(800, 600);

        // Создаем меч и щит
        sword = new Sword(new Point(400, 50), new Point(400, 300));
        shield = new Shield(new Rectangle(350, 300, 100, 150));

        this.Paint += new PaintEventHandler(this.OnPaint);
    }

    private void OnPaint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        // Рисуем меч и щит
        sword.Draw(g);
        shield.Draw(g);
    }

    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new GameForm());
    }
}