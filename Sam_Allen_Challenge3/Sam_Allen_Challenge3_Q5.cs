/*
CS3020-001 Advanced OO Tech Using C#/.Net
Sam Allen 
Coding Challenge #3 - Question #5

Objective: Create a weather station notification system
that notifies subscribers when temperature changes.
*/

using System;

namespace WeatherNotificationSystem
{
    public class WeatherStation
    {
        /*
        This class represents a weather station 
        which keeps track of the local weather.
        */

        public event Action<int> TemperatureChanged;
        public void UpdateTemperature(int newTemp)
        {
            /*
            This method updates the current temperature
            */
            Console.WriteLine($"Updating temperature to {newTemp} degrees Celsius.");
            TemperatureChanged?.Invoke(newTemp);
        }
    }

    public class User
    {
        /*
        This class represents an ordinary user.
        */
        public void OnTemperatureChanged(int temp)
        {
            /*
            This method notifies the user that the temperature 
            has been changed.
            */
            Console.WriteLine($"User: New temperature is {temp} degrees Celsius.");
        }
    }

    public class Admin
    {
        /*
        This class represents an admin of the weather system.
        */
        public void OnTemperatureChanged(int temp)
        {
            Console.WriteLine($"Admin: Temperature updated to {temp} degrees Celsius.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nTASK 5:\n");

            // create WeatherStation, User, and Admin 
            var myWeatherStation = new WeatherStation();
            var myUser = new User();
            var myAdmin = new Admin();

            // subscribe handlers and call UpdateTemperature
            myWeatherStation.TemperatureChanged += myUser.OnTemperatureChanged;
            myWeatherStation.TemperatureChanged += myAdmin.OnTemperatureChanged;
            myWeatherStation.UpdateTemperature(10);
        }
    }
}