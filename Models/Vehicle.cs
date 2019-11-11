using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LiveGreeterWpfDemo.Models
{

    public class Vehicle : INotifyPropertyChanged
    {
        private string color;
        public string Color
        {
            get { return this.color; }
            set
            {
                if (this.color != value)
                {
                    this.color = value;
                    this.NotifyPropertyChanged("Color");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public int VehicleID { get; set; }

        public string RegNo { get; set; }


        public string Make { get; set; }

        public string Model { get; set; }

        public string EngineNo { get; set; }

        public string ChasisNo { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public bool Active { get; set; }
    }
}
