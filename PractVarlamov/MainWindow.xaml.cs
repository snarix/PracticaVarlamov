using System;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PractVarlamov
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] mas = new int[5];

        public MainWindow()
        {
            InitializeComponent();
            this.Height += 25;
            DataGrid1.ItemsSource = mas.ToDataTable().DefaultView;
        }

        private void Enter(object sender, RoutedEventArgs e)
        {
            canvas1.Children.Clear();
            var selectedRow = DataGrid1.SelectedItem as DataRowView;

            if (selectedRow != null)
            {
                for (int i = 0; i < mas.Length; i++)
                {
                    mas[i] = Convert.ToInt32(selectedRow.Row.ItemArray[i]);
                }
                Class class1 = new(mas);

                if (class1.Task())
                {
                    MessageBox.Show("Последовательность имеет все простые числа");
                }
                else
                {
                    MessageBox.Show("Последовательность имеет не простые числа");
                }
                DrawGraph();
            }
            else
            {
                MessageBox.Show("Заполните DataGrid");
            }
        }

        private void DrawGraph()
        {
            double maxX = mas.Count() - 1;
            double maxY = mas.Max();
            double minY = mas.Min();

            double xCanvas = canvas1.ActualWidth / maxX;
            double yCanvas = canvas1.ActualHeight / (maxY - minY);

            Polyline _polyline = new Polyline
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1,
            };
            

            for (int i = 0; i < mas.Count(); i++)
            {
                double x = i * xCanvas;
                double y = canvas1.ActualHeight - ((mas[i] - minY) * yCanvas);

                _polyline.Points.Add(new Point(x, y));
            }

            canvas1.Children.Add(_polyline);
        }

        
    }
}