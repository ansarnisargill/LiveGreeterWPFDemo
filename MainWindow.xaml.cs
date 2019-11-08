using LiveGreeterWpfDemo.Models;
using LiveGreeterWpfDemo.Services;
using LiveGreeterWpfDemo.Views;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LiveGreeterWpfDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IHost _host;
        public MainWindow(IHost host)
        {
            _host = host;
            InitializeComponent();
        }

        private void RestApiDemoButton_Click(object sender, RoutedEventArgs e)
        {

            var _restApiDemo = _host.Services.GetService(typeof(RestApiDemo)) as RestApiDemo;
            _restApiDemo.Show();
            _restApiDemo.Owner = this;
            _restApiDemo.Show();
        }
    }
}
