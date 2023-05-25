using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtElem.Text) && !lstElem.Items.Contains(txtElem.Text))
            {
                if (MessageBox.Show("Вы действительно хотите добавить этот элемент?", "Добавление в список", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    lstElem.Items.Add(txtElem.Text);
                    txtElem.Clear();
                }
            }
            else if (lstElem.Items.Contains(txtElem.Text)) MessageBox.Show("Прости, но такой элемент уже есть...", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            else MessageBox.Show("Ну чё ты, не ломайся, введи что-нибудь!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lstElem.Items.Clear();
        }

        private void btnClearSelected_Click(object sender, RoutedEventArgs e)
        {
            while (lstElem.SelectedItems.Count > 0)
            {
                lstElem.Items.Remove(lstElem.SelectedItems[0]);
            }
        }

        private void Form_Load(object sender, RoutedEventArgs e)
        {
            ColorAnimation ca = new ColorAnimation(Colors.PapayaWhip, Colors.LightGreen, new Duration(TimeSpan.FromSeconds(4)));
            Storyboard.SetTarget(ca, this);
            Storyboard.SetTargetProperty(ca, new PropertyPath("Background.Color"));

            Storyboard stb = new Storyboard();
            stb.Children.Add(ca);
            stb.Begin();
        }
    }
}
