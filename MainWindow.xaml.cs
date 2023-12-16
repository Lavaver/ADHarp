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
using System.IO.Abstractions;
using MaterialDesignThemes.Wpf;
using System.Windows.Controls.Primitives;
using System.Diagnostics;



namespace ADHarp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonPopUpLogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void GridTitle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void PageSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (JumPage.SelectedItem != null)
            {
                ListViewItem? selectedItem = JumPage.SelectedItem as ListViewItem;
                if (selectedItem != null)
                {
                    string? pageName = selectedItem.Tag?.ToString();
                    if (!string.IsNullOrEmpty(pageName))
                    {
                        PleaseOpenTaskTitle.Visibility = Visibility.Hidden;
                        PleaseOpenTaskTitle.IsEnabled = false;
                        Uri uri = new Uri(pageName + ".xaml", UriKind.Relative);
                        MainFrame.Navigate(uri);
                    }
                }
            }
        }

        private void AboutSoftWare_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ADHarp 1.0\n构建版本号：Build 10\n请支持自由软件事业的开发！谢谢！\nADHarp 是一款基于 Frame 框架的便携式即用即走 ADB 工具集解决方案","关于 ADHarp",MessageBoxButton.OK,MessageBoxImage.Information);
        }

        private void SoftwareUpdate_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("连接在线服务器失败","失败",MessageBoxButton.OK,MessageBoxImage.Error);
        }
    }
}