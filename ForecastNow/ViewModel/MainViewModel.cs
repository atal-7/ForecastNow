using ForecastNow.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastNow.ViewModel
{
    public class MainViewModel:ViewModelBase
    {
		private ViewModelBase currentViewModel;

		public ViewModelBase CurrentViewModel
        {
			get { return currentViewModel; }
			set
			{
				currentViewModel = value;
				OnPropertyChanged(nameof(CurrentViewModel));
			}
		}

		public MainViewModel()
		{
            currentViewModel = new WeatherViewModel();
        }
	}
}
