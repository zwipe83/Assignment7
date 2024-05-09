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

        public Date () : this (new DateTime())
        {
        }

        public Date(DateTime date)
        {
            _date = date;
        }
    }
}