using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Essentials;

namespace WeatherApp4
{
    class WeatherForcast : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        string _name;
        string _dt;
        string _dt2;
        string _main;
        string _description;
        string _day;
        string _speed;
        string _pressure;
        string _humidity;
        string _icon;
        public string name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("name");
            }
        }
        public string dt
        {
            get { return _dt; }
            set
            {
                _dt = value;
                OnPropertyChanged("dt");
            }
        }
        public string dt2
        {
            get { return _dt2; }
            set
            {
                _dt2 = value;
                OnPropertyChanged("dt2");
            }
        }
        public string main
        {
            get { return _main; }
            set
            {
                _main = value;
                OnPropertyChanged("main");
            }
        }
        public string description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("description");
            }
        }
        public string day
        {
            get { return _day; }
            set
            {
                _day = value;
                OnPropertyChanged("day");
            }
        }
        public string speed
        {
            get { return _speed; }
            set
            {
                _speed = value;
                OnPropertyChanged("speed");
            }
        }
        public string pressure
        {
            get { return _pressure; }
            set
            {
                _pressure = value;
                OnPropertyChanged("pressure");
            }
        }
        public string humidity
        {
            get { return _humidity; }
            set
            {
                _humidity = value;
                OnPropertyChanged("humidity");
            }
        }
        public string icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                OnPropertyChanged("icon");
            }
        }
        public city city { get; set; }
        public List<list> list { get; set; }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(
                    this, new PropertyChangedEventArgs(propName));
        }
    }
    public class city
    {
        public string name { get; set; }
    }
    public class temp
    {
        public double day { get; set; }
    }
    public class weather
    {
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
    public class list
    {
        public double dt { get; set; }
        public double speed { get; set; }
        public double pressure { get; set; }
        public double humidity { get; set; }
        public temp temp { get; set; }
        public List<weather> weather { get; set; }
    }
}
