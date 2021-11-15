using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HomeWork6WpfApp
{
    
    class WeatherControl : DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperty; // Свойство зависимость
        private string windDerection; // Направление ветра
        private int windSpeed; // Скорость ветра больше нуля
        private int precipitation1; // Осадки числом
        
        public string WindDerection
        {
            get => windDerection;
            set => windDerection = value;
        }
        public int WindSpeed
        {
            get { return windSpeed; }
            set
            {
                if (value >= 0)
                {
                    windSpeed = value;
                }
                else { windSpeed = 0; }
            }
        }
        public int Precipitation1
        {
            get { return precipitation1; }
            set
            {
                if (value >= 0 && value <= 3)
                {
                    precipitation1 = value;
                }
                else { precipitation1 = 0; }

                //int c;
                //switch ((Precipitation)c)
                //{

                //}
            }
        }
        public enum Precipitation  // Осадки перечислением
        {
            Sunny,
            Cloudy,
            Rain,
            Snow,
        } 

        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }

        public WeatherControl(int temperature, string windDerection, int windSpeed, int precipitation) // Конструктор
        {
            this.Temperature = temperature;
            this.WindDerection = windDerection;
            this.WindSpeed = windSpeed;
            this.Precipitation1 = precipitation;

        }

        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemperature)),
                new ValidateValueCallback(ValidateTemperature));
        }

        private static bool ValidateTemperature(object value)
        {
            int v = (int)value;
            if (v >= -50 && v <= 50)
                return true;
            else
                return false;
        }
        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v >= -50)
                return v;
            else
                return 0;
        }
        public string Print()
        {
            return $" {Temperature} {WindDerection} {WindSpeed} {Precipitation1}  ";
        }


    }
}
