using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku_ElsoHet
{
    public partial class Form1 : Form
    {
        private Random _rng = new Random();
        private Sudoku _currentQuiz = null;


        public Form1()
        {
            InitializeComponent();

            CreatePlayField();
            LoadSudokus();
            NewGame();
        }

        private void CreatePlayField()
        {
            int lineWidth = 5;
            for (int sor = 0; sor < 9; sor++)
            {
                for (int oszlop = 0; oszlop < 9; oszlop++)
                {
                    SudokuField sf = new SudokuField();
                    sf.Left = oszlop * sf.Width + (int)(Math.Floor((double)(oszlop / 3))) * lineWidth;
                    sf.Top = sor * sf.Height + (int)(Math.Floor((double)(sor / 3))) * lineWidth;
                    foPanel.Controls.Add(sf);
                    MouseDown += Form1_MouseDown;
                }
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            string er = "";
            foreach (var item in foPanel.Controls.OfType<SudokuField>())
            {
                er += Convert.ToString(item.Value);
            }
            if (er.Equals(_currentQuiz.Solution))
            {
                foreach (var blocks in foPanel.Controls.OfType<SudokuField>())
                {
                    blocks.Active = false;
                }
            }
            MessageBox.Show("Nyertél!!!");
        }

        private Sudoku GetRandomQuiz()
        {
            int randomNumber = _rng.Next(_sudokus.Count);
            return _sudokus[randomNumber];
        }

        private void NewGame()
        {
            _currentQuiz = GetRandomQuiz();

            int counter = 0;
            foreach (var sf in foPanel.Controls.OfType<SudokuField>())
            {
                sf.Value = int.Parse(_currentQuiz.Quiz[counter].ToString());
                sf.Active = sf.Value == 0;
                counter++;
            }

        }

        private List<Sudoku> _sudokus = new List<Sudoku>();
        private void LoadSudokus()
        {
            _sudokus.Clear();
            using (StreamReader sr = new StreamReader("sudoku (1).csv", Encoding.Default))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(',');

                    Sudoku s = new Sudoku();
                    s.Quiz = line[0];
                    s.Solution = line[1];
                    _sudokus.Add(s);
                }
            }
        }
    }
}

