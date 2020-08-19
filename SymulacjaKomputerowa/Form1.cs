using System;
using System.Drawing;
using System.Windows.Forms;

namespace SymulacjaKomputerowa
{
    public partial class Form1 : Form
    {
        private int ticks;
        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            try
            {
                try
                {
                    string wymiary = textBox2.Text + ".";
                    int rows = Convert.ToInt32(wymiary.Substring(0, wymiary.IndexOf(",")));
                    int columns = Convert.ToInt32(wymiary.Substring(wymiary.IndexOf(",") + 1, wymiary.IndexOf(".") - wymiary.IndexOf(",") - 1));
                    int[,] macierzLiczb = new int[rows, columns];
                    dataGridView1.RowCount = rows;
                    dataGridView1.ColumnCount = columns;
                    for (int i = 0; i < columns; i++)
                    {
                        dataGridView1.Columns[i].Width = 10;
                    }
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            int p = rand.Next(0, 101);
                            if (p <= 50)
                                dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Green;
                            else
                                dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Red;
                        }
                    }
                }
                catch (FormatException) { }
            }
            catch (ArgumentOutOfRangeException) { }
            ticks = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = ticks.ToString();
            if (timer1.Enabled)
                timer1.Stop();
            else
                timer1.Start();
            if (timer2.Enabled)
                timer2.Stop();
            else
                timer2.Start();
        }

        private void MeetingSznajd(int row, int col)
        {
            if (col == 0 || col == 1 || col == dataGridView1.ColumnCount - 2 || col == dataGridView1.ColumnCount - 1 || row == 0 || row == dataGridView1.RowCount - 1)
            {
                if (row == 0)
                {
                    if (col == 0 || col == 1)
                    {
                        if (dataGridView1.Rows[row].Cells[0].Style.BackColor == dataGridView1.Rows[row].Cells[1].Style.BackColor)
                        {
                            dataGridView1.Rows[row].Cells[2].Style.BackColor = dataGridView1.Rows[row].Cells[1].Style.BackColor;
                            dataGridView1.Rows[row].Cells[dataGridView1.ColumnCount - 1].Style.BackColor = dataGridView1.Rows[row].Cells[1].Style.BackColor;
                            dataGridView1.Rows[row + 1].Cells[0].Style.BackColor = dataGridView1.Rows[row].Cells[1].Style.BackColor;
                            dataGridView1.Rows[row + 1].Cells[1].Style.BackColor = dataGridView1.Rows[row].Cells[1].Style.BackColor;
                            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0].Style.BackColor = dataGridView1.Rows[row].Cells[1].Style.BackColor;
                            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[1].Style.BackColor = dataGridView1.Rows[row].Cells[1].Style.BackColor;
                        }
                    }
                    if (col == dataGridView1.ColumnCount - 2 || col == dataGridView1.ColumnCount - 1)
                    {
                        if (dataGridView1.Rows[row].Cells[dataGridView1.ColumnCount - 1].Style.BackColor == dataGridView1.Rows[row].Cells[dataGridView1.ColumnCount - 2].Style.BackColor)
                        {
                            dataGridView1.Rows[row].Cells[dataGridView1.ColumnCount - 3].Style.BackColor = dataGridView1.Rows[row].Cells[dataGridView1.ColumnCount - 1].Style.BackColor;
                            dataGridView1.Rows[row].Cells[0].Style.BackColor = dataGridView1.Rows[row].Cells[dataGridView1.ColumnCount - 1].Style.BackColor;
                            dataGridView1.Rows[row + 1].Cells[dataGridView1.ColumnCount - 1].Style.BackColor = dataGridView1.Rows[row].Cells[dataGridView1.ColumnCount - 1].Style.BackColor;
                            dataGridView1.Rows[row + 1].Cells[dataGridView1.ColumnCount - 2].Style.BackColor = dataGridView1.Rows[row].Cells[dataGridView1.ColumnCount - 1].Style.BackColor;
                            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[dataGridView1.ColumnCount - 1].Style.BackColor = dataGridView1.Rows[row].Cells[dataGridView1.ColumnCount - 1].Style.BackColor;
                            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[dataGridView1.ColumnCount - 2].Style.BackColor = dataGridView1.Rows[row].Cells[dataGridView1.ColumnCount - 1].Style.BackColor;
                        }
                    }
                    if (col != 0 && col != 1 && col != dataGridView1.ColumnCount - 2 && col != dataGridView1.ColumnCount - 1 && col % 2 == 0)
                    {
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[col].Style.BackColor = dataGridView1.Rows[row].Cells[col].Style.BackColor;
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[col + 1].Style.BackColor = dataGridView1.Rows[row].Cells[col].Style.BackColor;
                        dataGridView1.Rows[row + 1].Cells[col].Style.BackColor = dataGridView1.Rows[row].Cells[col].Style.BackColor;
                        dataGridView1.Rows[row + 1].Cells[col + 1].Style.BackColor = dataGridView1.Rows[row].Cells[col].Style.BackColor;
                        dataGridView1.Rows[row].Cells[col - 1].Style.BackColor = dataGridView1.Rows[row].Cells[col].Style.BackColor;
                        dataGridView1.Rows[row].Cells[col + 2].Style.BackColor = dataGridView1.Rows[row].Cells[col].Style.BackColor;
                    }
                    if (col != 0 && col != 1 && col != dataGridView1.ColumnCount - 2 && col != dataGridView1.ColumnCount - 1 && col % 2 != 0)
                    {
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[col].Style.BackColor = dataGridView1.Rows[row].Cells[col].Style.BackColor;
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[col - 1].Style.BackColor = dataGridView1.Rows[row].Cells[col].Style.BackColor;
                        dataGridView1.Rows[row + 1].Cells[col].Style.BackColor = dataGridView1.Rows[row].Cells[col].Style.BackColor;
                        dataGridView1.Rows[row + 1].Cells[col - 1].Style.BackColor = dataGridView1.Rows[row].Cells[col].Style.BackColor;
                        dataGridView1.Rows[row].Cells[col + 1].Style.BackColor = dataGridView1.Rows[row].Cells[col].Style.BackColor;
                        dataGridView1.Rows[row].Cells[col - 2].Style.BackColor = dataGridView1.Rows[row].Cells[col].Style.BackColor;
                    }
                }
                if (row == dataGridView1.RowCount - 1)
                {
                    if (col == 0 || col == 1)
                    {
                        if (dataGridView1.Rows[row].Cells[0].Style.BackColor == dataGridView1.Rows[row].Cells[1].Style.BackColor)
                        {
                            dataGridView1.Rows[row].Cells[2].Style.BackColor = dataGridView1.Rows[row].Cells[1].Style.BackColor;
                            dataGridView1.Rows[row].Cells[dataGridView1.ColumnCount - 1].Style.BackColor = dataGridView1.Rows[row].Cells[1].Style.BackColor;
                            dataGridView1.Rows[row - 1].Cells[0].Style.BackColor = dataGridView1.Rows[row].Cells[1].Style.BackColor;
                            dataGridView1.Rows[row - 1].Cells[1].Style.BackColor = dataGridView1.Rows[row].Cells[1].Style.BackColor;
                            dataGridView1.Rows[0].Cells[0].Style.BackColor = dataGridView1.Rows[row].Cells[1].Style.BackColor;
                            dataGridView1.Rows[0].Cells[1].Style.BackColor = dataGridView1.Rows[row].Cells[1].Style.BackColor;
                        }
                    }
                    if (col == dataGridView1.ColumnCount - 2 || col == dataGridView1.ColumnCount - 1)
                    {
                        if (dataGridView1.Rows[row].Cells[dataGridView1.ColumnCount - 1].Style.BackColor == dataGridView1.Rows[row].Cells[dataGridView1.ColumnCount - 2].Style.BackColor)
                        {
                            dataGridView1.Rows[row].Cells[dataGridView1.ColumnCount - 3].Style.BackColor = dataGridView1.Rows[row].Cells[dataGridView1.ColumnCount - 1].Style.BackColor;
                            dataGridView1.Rows[row].Cells[0].Style.BackColor = dataGridView1.Rows[row].Cells[dataGridView1.ColumnCount - 1].Style.BackColor;
                            dataGridView1.Rows[row - 1].Cells[dataGridView1.ColumnCount - 1].Style.BackColor = dataGridView1.Rows[row].Cells[dataGridView1.ColumnCount - 1].Style.BackColor;
                            dataGridView1.Rows[row - 1].Cells[dataGridView1.ColumnCount - 2].Style.BackColor = dataGridView1.Rows[row].Cells[dataGridView1.ColumnCount - 1].Style.BackColor;
                            dataGridView1.Rows[0].Cells[dataGridView1.ColumnCount - 1].Style.BackColor = dataGridView1.Rows[row].Cells[dataGridView1.ColumnCount - 1].Style.BackColor;
                            dataGridView1.Rows[0].Cells[dataGridView1.ColumnCount - 2].Style.BackColor = dataGridView1.Rows[row].Cells[dataGridView1.ColumnCount - 1].Style.BackColor;
                        }
                    }
                    if (col != 0 && col != 1 && col != dataGridView1.ColumnCount - 2 && col != dataGridView1.ColumnCount - 1 && col % 2 == 0)
                    {
                        dataGridView1.Rows[0].Cells[col].Style.BackColor = dataGridView1.Rows[row].Cells[col].Style.BackColor;
                        dataGridView1.Rows[0].Cells[col + 1].Style.BackColor = dataGridView1.Rows[row].Cells[col].Style.BackColor;
                        dataGridView1.Rows[row - 1].Cells[col].Style.BackColor = dataGridView1.Rows[row].Cells[col].Style.BackColor;
                        dataGridView1.Rows[row - 1].Cells[col + 1].Style.BackColor = dataGridView1.Rows[row].Cells[col].Style.BackColor;
                        dataGridView1.Rows[row].Cells[col - 1].Style.BackColor = dataGridView1.Rows[row].Cells[col].Style.BackColor;
                        dataGridView1.Rows[row].Cells[col + 2].Style.BackColor = dataGridView1.Rows[row].Cells[col].Style.BackColor;
                    }
                    if (col != 0 && col != 1 && col != dataGridView1.ColumnCount - 2 && col != dataGridView1.ColumnCount - 1 && col % 2 != 0)
                    {
                        dataGridView1.Rows[0].Cells[col].Style.BackColor = dataGridView1.Rows[row].Cells[col].Style.BackColor;
                        dataGridView1.Rows[0].Cells[col - 1].Style.BackColor = dataGridView1.Rows[row].Cells[col].Style.BackColor;
                        dataGridView1.Rows[row - 1].Cells[col].Style.BackColor = dataGridView1.Rows[row].Cells[col].Style.BackColor;
                        dataGridView1.Rows[row - 1].Cells[col - 1].Style.BackColor = dataGridView1.Rows[row].Cells[col].Style.BackColor;
                        dataGridView1.Rows[row].Cells[col + 1].Style.BackColor = dataGridView1.Rows[row].Cells[col].Style.BackColor;
                        dataGridView1.Rows[row].Cells[col - 2].Style.BackColor = dataGridView1.Rows[row].Cells[col].Style.BackColor;
                    }
                }
                if (row != 0 && row != dataGridView1.RowCount - 1)
                {
                    if (col == 0 || col == 1)
                    {
                        if (dataGridView1.Rows[row].Cells[0].Style.BackColor == dataGridView1.Rows[row].Cells[1].Style.BackColor)
                        {
                            dataGridView1.Rows[row].Cells[2].Style.BackColor = dataGridView1.Rows[row].Cells[1].Style.BackColor;
                            dataGridView1.Rows[row].Cells[dataGridView1.ColumnCount - 1].Style.BackColor = dataGridView1.Rows[row].Cells[1].Style.BackColor;
                            dataGridView1.Rows[row + 1].Cells[0].Style.BackColor = dataGridView1.Rows[row].Cells[1].Style.BackColor;
                            dataGridView1.Rows[row + 1].Cells[1].Style.BackColor = dataGridView1.Rows[row].Cells[1].Style.BackColor;
                            dataGridView1.Rows[row - 1].Cells[0].Style.BackColor = dataGridView1.Rows[row].Cells[1].Style.BackColor;
                            dataGridView1.Rows[row - 1].Cells[1].Style.BackColor = dataGridView1.Rows[row].Cells[1].Style.BackColor;
                        }
                    }
                    if (col == dataGridView1.ColumnCount - 2 || col == dataGridView1.ColumnCount - 1)
                    {
                        if (dataGridView1.Rows[row].Cells[dataGridView1.ColumnCount - 1].Style.BackColor == dataGridView1.Rows[row].Cells[dataGridView1.ColumnCount - 2].Style.BackColor)
                        {
                            dataGridView1.Rows[row].Cells[dataGridView1.ColumnCount - 3].Style.BackColor = dataGridView1.Rows[row].Cells[dataGridView1.ColumnCount - 1].Style.BackColor;
                            dataGridView1.Rows[row].Cells[0].Style.BackColor = dataGridView1.Rows[row].Cells[dataGridView1.ColumnCount - 1].Style.BackColor;
                            dataGridView1.Rows[row + 1].Cells[dataGridView1.ColumnCount - 1].Style.BackColor = dataGridView1.Rows[row].Cells[dataGridView1.ColumnCount - 1].Style.BackColor;
                            dataGridView1.Rows[row + 1].Cells[dataGridView1.ColumnCount - 2].Style.BackColor = dataGridView1.Rows[row].Cells[dataGridView1.ColumnCount - 1].Style.BackColor;
                            dataGridView1.Rows[row - 1].Cells[dataGridView1.ColumnCount - 1].Style.BackColor = dataGridView1.Rows[row].Cells[dataGridView1.ColumnCount - 1].Style.BackColor;
                            dataGridView1.Rows[row - 1].Cells[dataGridView1.ColumnCount - 2].Style.BackColor = dataGridView1.Rows[row].Cells[dataGridView1.ColumnCount - 1].Style.BackColor;
                        }
                    }
                }
            }
            else
            {
                if (col % 2 == 0)
                {
                    if (dataGridView1.Rows[row].Cells[col].Style.BackColor == dataGridView1.Rows[row].Cells[col + 1].Style.BackColor)
                    {
                        dataGridView1.Rows[row + 1].Cells[col].Style.BackColor = dataGridView1.Rows[row].Cells[col].Style.BackColor;
                        dataGridView1.Rows[row + 1].Cells[col + 1].Style.BackColor = dataGridView1.Rows[row].Cells[col].Style.BackColor;
                        dataGridView1.Rows[row - 1].Cells[col].Style.BackColor = dataGridView1.Rows[row].Cells[col].Style.BackColor;
                        dataGridView1.Rows[row - 1].Cells[col + 1].Style.BackColor = dataGridView1.Rows[row].Cells[col].Style.BackColor;
                        dataGridView1.Rows[row].Cells[col - 1].Style.BackColor = dataGridView1.Rows[row].Cells[col].Style.BackColor;
                        dataGridView1.Rows[row].Cells[col + 2].Style.BackColor = dataGridView1.Rows[row].Cells[col].Style.BackColor;
                    }
                }
                if (col % 2 != 0)
                {
                    if (dataGridView1.Rows[row].Cells[col].Style.BackColor == dataGridView1.Rows[row].Cells[col - 1].Style.BackColor)
                    {
                        dataGridView1.Rows[row].Cells[col + 1].Style.BackColor = dataGridView1.Rows[row].Cells[col].Style.BackColor;
                        dataGridView1.Rows[row].Cells[col - 2].Style.BackColor = dataGridView1.Rows[row].Cells[col].Style.BackColor;
                        dataGridView1.Rows[row - 1].Cells[col].Style.BackColor = dataGridView1.Rows[row].Cells[col].Style.BackColor;
                        dataGridView1.Rows[row - 1].Cells[col - 1].Style.BackColor = dataGridView1.Rows[row].Cells[col].Style.BackColor;
                        dataGridView1.Rows[row + 1].Cells[col].Style.BackColor = dataGridView1.Rows[row].Cells[col].Style.BackColor;
                        dataGridView1.Rows[row + 1].Cells[col - 1].Style.BackColor = dataGridView1.Rows[row].Cells[col].Style.BackColor;
                    }
                }
            }
        }

        private void MeetingRandom(int randRow, int randCol)
        {
            try
            {
                int posibility = Convert.ToInt32(textBox6.Text);
                int inf = InfluenceGreen(randRow, randCol);
                int power = posibility * inf;
                int random = rand.Next(0, 101);
                if (random <= power)
                    dataGridView1.Rows[randRow].Cells[randCol].Style.BackColor = Color.Green;
                else
                    dataGridView1.Rows[randRow].Cells[randCol].Style.BackColor = Color.Red;
            }
            catch (FormatException) { }
        }

        private int InfluenceGreen(int randRow, int randCol)
        {                      
            int inf = 0;
            for (int i = randRow - 1; i < randRow + 2; i++)
            {
                int j = Math.Abs(i % dataGridView1.RowCount);
                if (dataGridView1.Rows[j].Cells[randCol].Style.BackColor == Color.Green && i != randRow)
                    inf++;
            }
            for (int i = randCol - 1; i < randCol + 2; i++)
            {
                int j = Math.Abs(i % dataGridView1.ColumnCount);
                if (dataGridView1.Rows[randRow].Cells[j].Style.BackColor == Color.Green && i != randCol)
                    inf++;
            }
            return inf;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int randRow = rand.Next(dataGridView1.RowCount);
            int randCol = rand.Next(dataGridView1.ColumnCount);
            if (!Stop())
            {
                if (radioButton1.Checked)
                    MeetingSznajd(randRow, randCol);
                else
                    MeetingRandom(randRow, randCol);
            }
            else
                timer1.Stop();         
        }

        private bool Stop()
        {
            bool stop = true;
            try
            {
                Color color = dataGridView1.Rows[0].Cells[0].Style.BackColor;
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Style.BackColor != color)
                        {
                            stop = false;
                            break;
                        }
                    }
                }
            }
            catch (ArgumentOutOfRangeException) { }
            return stop;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            if (radioButton2.Checked)
                panel1.Visible = true;
            else
                panel1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int speed = Convert.ToInt32(textBox8.Text);
                timer1.Interval = speed;
            }
            catch (FormatException) { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Na początku podajemy wymiary siatki, która będzie służyła nam za populację i tworzymy losowo agentów. " +
                "Podajemy liczbę wierszy oraz kolumn (w tej kolejności) oddzielamy je przecinkiem. Potem wybieramy model dynamiki. " +
                "Jeśli wybierzemy Sznajdów, to możemy zaczynać symulację. " +
                "Jeśli będzie to losowa, wtedy musimy podać prawdopodobieństwo z jakim dany agent zmieni opinię na zieloną z powodu wpływu jednego sąsiada zielonego. " +
                "Ta wartość zostanie przemnożona razy liczbę zielonych sąsiadów i z takim prawdopodobieństwem nastąpi zmiana opinii na zieloną. " +
                "Możemy, także zmieniać szybkość zegara, wartość podajemy w milisekundach. " +
                "Czas trwania symulacji jest podany w sekundach. Przycisk start rozpoczyna jak i zatrzymuje symulację.");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Stop())
            {
                timer2.Stop();
            }
            ticks++;
            textBox3.Text = ticks.ToString();
        }
    }
}
