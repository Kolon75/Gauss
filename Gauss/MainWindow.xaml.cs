using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gauss
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Classes.Point> points = new List<Classes.Point>();
        int scale = 20; //Маштаб отрисовки фигуры



        public MainWindow()
        {
            InitializeComponent();
            points.Add(new Classes.Point(2, 2));
            points.Add(new Classes.Point(4, 4));
            points.Add(new Classes.Point(6, 4));
            points.Add(new Classes.Point(7, 2));
            LoadData();
        }
        private void LoadData()
        {
            for (int i = 0; i < points.Count; i++)
            {
                points[i]._id = i+1;
            }
            PointsGrid.ItemsSource = points;
            PointsGrid.Items.Refresh();
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            points.RemoveAt(PointsGrid.SelectedIndex);
            LoadData();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            points.Add(new Classes.Point(0,0));
            LoadData();
        }

        private void btnSolution_Click(object sender, RoutedEventArgs e)
        {
            if (points.Count >= 3)
            {
                Grafic.Points = new PointCollection();
                double s = 0;
                for (int i = 0; i < points.Count; i++)
                {
                    s += points[i]._x * points[(i + 1) % points.Count]._y - points[(i + 1) % points.Count]._x * points[i]._y;
                    Grafic.Points.Add(new Point(points[i]._x * scale, points[i]._y * scale));
                }
                Grafic.RenderTransform = new ScaleTransform { ScaleY = -1 };
                Grafic.Stroke = Brushes.Black;
                lSolution.Content = "Плошадь фигуры :" + 0.5 * Math.Abs(s);
            }
            else
            {
                MessageBox.Show("Введите 3 или более точки");
            }
            

        }

        
    }
}
