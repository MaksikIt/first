using System;
using System.Windows.Forms;
using System.Diagnostics;


namespace обучениепрактикаунивер
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            double a, b, c, d, h1, h2;
            a = Convert.ToDouble(aTextBox.Text);
            b = Convert.ToDouble(bTextBox.Text);
            h1 = Convert.ToDouble(h1TextBox.Text);
            c = Convert.ToDouble(cTextBox.Text);
            d = Convert.ToDouble(dTextBox.Text);
            h2 = Convert.ToDouble(h2TextBox.Text);
            Solution(a, b, h1, c, d, h2);

        }
        private double Function(double x, double y)
        {
            return (x * Math.Pow((x - 1) + y, 1.0 / 3.0));
        }
        private void Solution(double a, double b, double h1, double c, double d, double h2)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int n1, n2;
            double x, y, min, func;
            n1 = GetCount(a, b, h1);
            n2 = GetCount(c, d, h2); 
            CreateTable(n1, n2);
            x = a;
            y = c;
            min = Double.MaxValue;
            for (int i = 0; i < n1; i++)
            {
                Table.Columns[i].Name = Convert.ToString(Math.Round(a+h1*i, 6));
            }
            for (int j = 0; j < n2; j++)
            {
                Table.Rows[j].HeaderCell.Value = Convert.ToString(Math.Round(c + h2 * j, 6));
                
            }
            for (int j = 0; j < n2; j++)
            {
                x = a;
                for (int i = 0; i < n1; i++)
                {
                    func = Function(x, y);
                    Table.Rows[j].Cells[i].Value = Math.Round(func, 6);
                    x += h1;
                    if (func < min)
                        min = func;
                }
                y += h2;
            }
            OutputMin(min, TextBoxMin);
            watch.Stop();
            label8.Text = $"Время выполнения: {watch.ElapsedMilliseconds.ToString()}  ms.( {n1.ToString()} x {n2.ToString()} = {(n1 * n2).ToString()} ячеек)"; 

        }
        private int GetCount (double start, double finish, double step)
        {
            int n = Convert.ToInt32(Math.Floor(Math.Round((finish - start) / step + 1, 6)));
            return n;
        }
        private void OutputMin(double min, TextBox textBoxMin)
        {
            textBoxMin.Text = Convert.ToString(Math.Round(min, 6));
        }
        private void CreateTable(int n1, int n2)
        {
            Table.ColumnCount = n1;
            Table.RowCount = n2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

