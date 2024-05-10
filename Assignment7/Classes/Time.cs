/// <summary>
/// Filename: Time.cs
/// Created on: 2024-05-05 00:00:00
/// Author: Samuel Jeffman
/// </summary>
/// 

namespace Assignment7.Classes
{
    public class Time
    {
        private TimeSpan _time;

        public TimeSpan T
        {
            get => _time; 
            set => _time = value;
        }

        public Time() : this(new TimeSpan())
        { 
        }

        public Time(TimeSpan time)
        {
            _time = time;
        }

        public Time(Time objToCopyFrom)
        {
            T = objToCopyFrom.T;
        }
    }
}