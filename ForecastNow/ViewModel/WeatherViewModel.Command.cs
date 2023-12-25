using ForecastNow.Management.Helper;
using ForecastNow.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ForecastNow.ViewModel
{
    public partial class WeatherViewModel
    {
        #region ICommands
        public ICommand SearchCommand { get; set; }
        #endregion

        #region Method
        public async void MakeQuery(object parameter)
        {
            var cities = await AccuWeatherHelper.GetCities(Query);
        }

        public bool CanMakeQuery(object parameter)
        {
            string? query = parameter as string;

            if(string.IsNullOrWhiteSpace(query))
                return false;
            return true;
        }
        #endregion
    }
}
