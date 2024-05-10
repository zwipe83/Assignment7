/// <summary>
/// Filename: Date.cs
/// Created on: 2024-05-05 00:00:00
/// Author: Samuel Jeffman
/// </summary>
/// 

namespace Assignment7.Classes
{
    public class Date
    {
        private DateTime _date;

        public DateTime D
        {
            get => _date;
            set => _date = value;
        }

        public Date () : this (new DateTime().Date)
        {
        }

        public Date(DateTime date)
        {
            _date = date;
        }

        public Date(Date objToCopyFrom)
        {
            D = objToCopyFrom.D;
        }
    }
}