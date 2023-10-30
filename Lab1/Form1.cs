using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Викликаємо обробник.
            this.Load += Form1_Load;
        }
        #region Поля: змінні та константи.
        /// <summary>
        /// Ліва межа графіка функції.
        /// </summary>
        private double XMin = 0;
        /// <summary>
        /// Права межа графіка функції.
        /// </summary>
        private double XMax = 45;
        /// <summary>
        /// Крок графіка функції.
        /// </summary>
        private double Step = 1;
        /// <summary>
        /// Масив значень X.
        /// </summary>
        private double[] x;
        /// <summary>
        /// Масиви значень Y.
        /// </summary>
        private double[] y1;
        private double[] y2;
        private const int ArrayLength = 11;

        private const string areaName = "myGraph";
        /// <summary>
        /// Глобальну змінну типу Chart.
        /// </summary>
        static Chart chart;
        #endregion

        #region Методи.
        /// <summary>
        /// Розрахунок значень графіка функції.
        /// </summary>
        private void Calculate()
        {
            // Створюємо масиви відповідних розмірів.
            SetX();
            SetY1();
            SetY2();
        }

        private void SetX()
        {
            x = new double[ArrayLength];
            x[0] = 0;
            x[1] = 2;
            for(int i = 1; i < x.Length-1; i++)
            {
                x[i+1] = i * 5;
            }
        }

        private void SetY1()
        {
            y1 = new double[ArrayLength];
            y1[0] = 0;
            y1[1] = 0.1;
            // Розраховуємо крапки для графіків функції.
            double delta = 0.25;
            for(int i = 1;i < y1.Length/2; i++)
            {
                y1[i+1] = y1[y1.Length-i-1] = delta*i;
            }

        }

        private void SetY2()
        {
            y2 = new double[ArrayLength];
            for (int i = 0; i < y2.Length; i++)
            {
                y2[i] = Math.Pow(y1[i], 2);
            }
        }

        /// <summary>
        /// Створюємо елемент управління Chart та налаштовуємо його.
        /// </summary>
        private void CreateChart()
        {
            // Створюємо new елемент керування Chart.
            chart = new Chart();
            // Поміщаємо його форму.
            chart.Parent = this;
            // Задаємо розміри елемента.
            chart.SetBounds(10, 10, ClientSize.Width - 20, ClientSize.Height - 20);

            // Додаємо область у діаграму.
            chart.ChartAreas.Add(GetArea());
            // Додаємо до списку графіків діаграми.
            chart.Series.Add(GetSeries(y1, areaName, "Рівень звичайного комфорту", Color.Red));
            chart.Series.Add(GetSeries(y2, areaName, "Підвищений комфорт.", Color.Green));
            
            // Створюємо легенду, яка показуватиме назви.
            chart.Legends.Add(new Legend());
            // Задаємо шрифт та стиль легенди.
            chart.Legends[0].Font = new Font("Times new Roman", 12, FontStyle.Bold);
        }
        private ChartArea GetArea()
        {
            // Створюємо нову область для побудови графіка.
            ChartArea area = new ChartArea();
            // Даємо їй ім'я (щоб потім додавати графіки).
            area.Name = areaName;
            // Задаємо ліву та праву межі осі X.
            area.AxisX.Minimum = XMin;
            area.AxisX.Maximum = XMax;
            // Визначаємо крок сітки.
            area.AxisX.MajorGrid.Interval = Math.Abs(Step);
            // Підписи до осей.
            area.AxisX.Title = "T,℃";
            area.AxisY.Title = "μ(T)";
            // Задаємо шрифт та стиль підписів осей графіка.

            Font title = new Font("Times new Roman", 12, FontStyle.Bold);
            area.AxisX.TitleFont = title;
            area.AxisY.TitleFont = title;

            return area;
        }
        private Series GetSeries(double[] points, string chartArea, string legend, Color seriesColor)
        {
            // Створюємо об'єкт для графіка.
            Series series1 = new Series();
            // Посилаємося область для побудови графіка.
            series1.ChartArea = chartArea;
            // Задаємо тип графіка – лінії.
            series1.ChartType = SeriesChartType.Line;
            // Вказуємо ширину лінії графіка.
            series1.BorderWidth = 4;
            // Назва графіка для відображення у легенді.
            series1.LegendText = legend;
            // Додаємо колекцію крапок.
            series1.Points.Add(points);

            // Завдання іміджу точок.
            series1.MarkerStyle = MarkerStyle.Circle;
            // Завдання розміру точок.
            series1.MarkerSize = 10;
            // Завдання кроку між точками.
            series1.MarkerStep = 1;
            // Завдання кольору крапок.
            series1.MarkerColor = seriesColor;

            return series1;
        }

        /// <summary>
        /// Обробник подій форми.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            // Створюємо елемент управління.
            CreateChart();
            // Розраховуємо значення точок графіка функції.
            Calculate();
            // Додаємо обчислені значення графіки функцій.
            chart.Series[0].Points.DataBindXY(x, y1);
            chart.Series[1].Points.DataBindXY(x, y2);
        }
#endregion
    }
}
