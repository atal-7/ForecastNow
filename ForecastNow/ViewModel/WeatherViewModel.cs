using ForecastNow.Management.Helper;
using ForecastNow.Model;
using ForecastNow.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastNow.ViewModel
{
	public partial class WeatherViewModel : ViewModelBase
	{
		#region Properties
		private string query;

		public string Query
		{
			get { return query; }
			set
			{
				query = value;
				OnPropertyChanged(nameof(Query));
			}
		}

		private CurrentWeather currentWeather;

		public CurrentWeather CurrentWeather
		{
			get { return currentWeather; }
			set
			{
				currentWeather = value;
				OnPropertyChanged(nameof(CurrentWeather));
			}
		}

		private City selectedCity;

		public City SelectedCity
		{
			get { return selectedCity; }
			set
			{
				selectedCity = value;
				OnPropertyChanged(nameof(SelectedCity));
			}
		}
		#endregion

		#region Constructor
		public WeatherViewModel()
		{
			if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
			{
				SelectedCity = new City
				{
					LocalizedName = "New York"
				};
				CurrentWeather = new CurrentWeather
				{
					WeatherText = "Partly Cloudy",
					Temperature = new Temperature
					{
						Metric = new Units
						{
							Value = 21
						}
					}
				};
			}

			SearchCommand = new CommandBase(MakeQuery, CanMakeQuery);
		}
		#endregion

	}
}
