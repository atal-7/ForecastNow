using ForecastNow.Management.Helper;
using ForecastNow.Model;
using ForecastNow.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastNow.ViewModel
{
	public partial class WeatherViewModel : ViewModelBase
	{
		#region Properties
		private string? query;

		public string Query
		{
			get { return query; }
			set
			{
				query = value;
				OnPropertyChanged(nameof(Query));
			}
		}

		private CurrentWeather? currentWeather;

		public CurrentWeather CurrentWeather
		{
			get { return currentWeather; }
			set
			{
				currentWeather = value;
				OnPropertyChanged(nameof(CurrentWeather));
			}
		}

		private DateTime localDateTime;

		public DateTime LocalDateTime
		{
			get { return localDateTime; }
			set
			{
				localDateTime = value;
				OnPropertyChanged(nameof(LocalDateTime));
			}
		}


		private City? selectedCity;

		public City SelectedCity
		{
			get { return selectedCity; }
			set
			{
				selectedCity = value;
				if (value != null)
				{
					SelectedCityName = SelectedCity.LocalizedName;
					GetCurrentWeather();
				}
				OnPropertyChanged(nameof(SelectedCity));
			}
		}

		private string selectedCityName = string.Empty;

		public string SelectedCityName
		{
			get { return selectedCityName; }
			set
			{
				selectedCityName = value;
				OnPropertyChanged(nameof(SelectedCityName));
			}
		}


		private readonly ObservableCollection<City>? citiesList;

		public IEnumerable<City> CitiesList => citiesList;

		private bool isLoadingList;

		public bool IsLoadingList
		{
			get { return isLoadingList; }
			set
			{
				isLoadingList = value;
				OnPropertyChanged(nameof(IsLoadingList));
			}
		}

		private bool isLoadingWeather;

		public bool IsLoadingWeather
		{
			get { return isLoadingWeather; }
			set
			{
				isLoadingWeather = value;
				OnPropertyChanged(nameof(IsLoadingWeather));
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
					LocalObservationDateTime = DateTime.Now,
					Temperature = new Temperature
					{
						Metric = new Units
						{
							Value = "21"
						}
					}
				};
			}

			citiesList = new ObservableCollection<City>();
			SearchCommand = new CommandBase(MakeQuery, CanMakeQuery);
		}
		#endregion

		private async void GetCurrentWeather()
		{
			Query = string.Empty;
			IsLoadingWeather = true;

			try
			{
				CurrentWeather = await AccuWeatherHelper.GetCurrentWeather(SelectedCity.Key);
				LocalDateTime = CurrentWeather.LocalObservationDateTime;
				IsLoadingWeather = false;
			}
			catch (Exception ex) { }
		}
	}
}
