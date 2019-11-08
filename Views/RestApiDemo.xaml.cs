using LiveGreeterWpfDemo.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LiveGreeterWpfDemo.Views
{
    /// <summary>
    /// Interaction logic for RestApiDemo.xaml
    /// </summary>
    public partial class RestApiDemo : Window
    {
        private readonly IRestApiService _service;
        public RestApiDemo(IRestApiService service)
        {
            InitializeComponent();
            this._service = service;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VehiclesGrid.ItemsSource = this._service.GetVehicles();
        }
    }
}
