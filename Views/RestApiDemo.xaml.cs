using LiveGreeterWpfDemo.Models;
using LiveGreeterWpfDemo.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.Specialized;
using HandyControl.Data;
using HandyControl.Tools;
using HandyControl.Controls;

namespace LiveGreeterWpfDemo.Views
{
    /// <summary>
    /// Interaction logic for RestApiDemo.xaml
    /// </summary>
    public partial class RestApiDemo : System.Windows.Window
    {
        public bool HasDataLoaded { get; set; } = false;
        private readonly IRestApiService _service;
        public ObservableCollection<Vehicle> List { get; set; } = new ObservableCollection<Vehicle>();
        public RestApiDemo(IRestApiService service)
        {
            InitializeComponent();
            this._service = service;
            VehiclesGrid.ItemsSource = this.List;

            this.List.CollectionChanged += List_CollectionChanged;
        }

        private async void List_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (this.HasDataLoaded)
            {
                if (
                e.Action == NotifyCollectionChangedAction.Remove)
                {
                    foreach (Vehicle item in e.OldItems)
                    {
                        Loading.Visibility = Visibility.Visible;
                        await DeleteData(item);
                        Loading.Visibility = Visibility.Hidden;
                    }
                }
             
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.HasDataLoaded = false;
            Loading.Visibility = Visibility.Visible;
            await LoadData();
            Loading.Visibility = Visibility.Hidden;
            this.HasDataLoaded = true;
        }
        private async Task LoadData()
        {
            var list = await Task.Run(() =>

                  this._service.GetVehicles()
            );
            this.List.Clear();
            foreach(var item in list)
            {
                this.List.Add(item);
            }
            
        }

        private async void BTNAdd_Click(object sender, RoutedEventArgs e)
        {
            var vehicle = new Vehicle(_service)
            {
                Active = true,
                Color = TBColor.Text,
                Make = TBMake.Text,
                RegNo = TBRegNo.Text,
                Model = TBModel.Text
            };
            Loading.Visibility = Visibility.Visible;
            await PostData(vehicle);
            await LoadData();
            Loading.Visibility = Visibility.Hidden;

        }
        private async Task PostData(Vehicle vehicle)
        {
            var res = await Task.Run(() =>this._service.PostVehicle(vehicle));

        }
        private async Task DeleteData(Vehicle vehicle)
        {
            var res = await Task.Run(() => this._service.DeleteVehicle(vehicle.VehicleID));
            if (res)
            {
                HandyControl.Controls.MessageBox.Info("Vehicle Deletd");
              
            }
            else
            {
                HandyControl.Controls.MessageBox.Error("Vehicle Can Not Be Deletd");

            }

        }
    }
}
