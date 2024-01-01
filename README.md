# ForecastNow

Welcome to the ForecastNow, a modern and feature-rich weather application built using the MVVM architecture. This application empowers users to explore weather conditions in various cities, providing real-time information with a user-friendly interface.

## Features:

- **MVVM Architecture:**
  The app is designed following the Model-View-ViewModel architectural pattern, ensuring clean separation of concerns for maintainability and scalability.

- **User Interaction:**
  Utilizing a TextBox, users can input queries to retrieve a list of cities displayed in a convenient ListView. Selection of a city enables viewing current weather conditions.

- **Accuweather API Integration:**
  The app leverages the AccuWeather API to fetch cities and retrieve accurate real-time weather conditions, including temperature and local time.

- **Animations and Triggers:**
  Enhance the user experience with dynamic animations through Storyboards, Triggers, DataTriggers, and EventTriggers.

- **Resource Dictionary:**
  A centralized Resource Dictionary is implemented to manage and apply styles consistently across various controls, contributing to a cohesive and visually appealing UI.

- **Custom Styles:**
  Explore customized styles for buttons and TextBox, achieved through ControlTemplates for a unique and polished look.

## Getting Started:

1. **Clone the Repository:**
   ```
   git clone https://github.com/atal-7/ForecastNow.git
   ```

2. **API Key:**
   Obtain an AccuWeather API key from [AccuWeather Developer](https://developer.accuweather.com) and replace the placeholder in the app's configuration.

3. **Build and Run:**
   Open the solution in Visual Studio, build the project, and run the application.

## Dependencies:

- .NET Framework 6.0
- AccuWeather API Key

## Additional Dependency:

- Newtonsoft.Json:
The application utilizes Newtonsoft.Json for efficient deserialization of HTTP responses from the AccuWeather API. This library enhances the handling of JSON data, ensuring seamless integration with the app’s data retrieval processes.

- Installation:
  Ensure that Newtonsoft.Json is installed using NuGet Package Manager:
  ```
  nuget install Newtonsoft.Json
  ```

## Contributing:

If you'd like to enhance or fix issues, please open a pull request. For major changes, please open an issue first to discuss potential updates.

##
Enjoy exploring the weather with the WPF Weather App!



![ForecastNow](https://github.com/atal-7/ForecastNow/assets/84587958/fa9f5633-9ce3-494d-a64d-d60acd7ee3cf)
