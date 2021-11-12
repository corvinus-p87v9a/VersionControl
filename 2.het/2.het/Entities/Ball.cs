using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace _2.het.Entities
{
    class Ball : Label
    {
        class Ball : Toy
        {
            public SolidBrush BallColor { get; private set; }
            public Ball(Color color)
            {
                AutoSize = false;
                Height = 50;
                Width = 50;
                Paint += Ball_Paint;
                BallColor = new SolidBrush(color);

            }

            private void Ball_Paint(object sender, PaintEventArgs e)
            {
                DrawImage(e.Graphics);
            }

            protected override void DrawImage(Graphics g)
            {
                g.FillEllipse(BallColor, 0, 0, Width, Height);
            }

            public void MoveBall()
            {
                Left += 1;
            }
            ű    {
        private Abstractions.Toy _nextToy;
            private List<Abstractions.Toy> _toys = new List<Abstractions.Toy>();
            private Abstractions.IToyFactory _factory;
            private Abstractions.IToyFactory Factory

            {
                get { return _factory; }
                set
                {
                    _factory = value;
                    DisplayNext();
                }
            }


            public Form1()
            {
                InitializeComponent();
                Factory = new Entities.BallFactory();
                mainPanel.Width = Width;
                button3.BackColor = Color.DarkGreen;
            }

            private void createTimer_Tick(object sender, EventArgs e)
            {
                var ball = Factory.CreateNew();
                _toys.Add(ball);
                ball.Left = -ball.Width;
                mainPanel.Controls.Add(ball);
            }

            private void conveyorTimer_Tick(object sender, EventArgs e)
            {
                var maxPosition = 0;
                foreach (var ball in _toys)
                {
                    ball.MoveToy();
                    if (ball.Left > maxPosition)
                        maxPosition = ball.Left;
                }

                if (maxPosition > 1000)
                {
                    var oldestBall = _toys[0];
                    mainPanel.Controls.Remove(oldestBall);
                    _toys.Remove(oldestBall);
                }
            }

            private void button1_Click(object sender, EventArgs e)
            {
                Factory = new CarFactory();

            }

            private void button2_Click(object sender, EventArgs e)
            {
                Factory = new Entities.BallFactory
                {
                    BallColor = button3.BackColor
                };
            }
            private void DisplayNext()
            {
                if (_nextToy != null)
                    Controls.Remove(_nextToy);
                _nextToy = Factory.CreateNew();
                _nextToy.Top = label1.Top + label1.Height + 20;
                _nextToy.Left = label1.Left;
                Controls.Add(_nextToy);
            }

            private void button3_Click(object sender, EventArgs e)
            {
                var button = (Button)sender;
                var colorPicker = new ColorDialog();

                colorPicker.Color = button.BackColor;
                if (colorPicker.ShowDialog() != DialogResult.OK)
                    return;
                button.BackColor = colorPicker.Color;
            }

            private void button4_Click(object sender, EventArgs e)
            {
                Factory = new Entities.PresentFactory
                {
                    PresentColor = button3.BackColor
                };
            }
        }
    }
    }
}
