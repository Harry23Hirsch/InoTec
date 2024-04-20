using System;

namespace InoTec
{
    public class ClsLogFileLine
    {
        private DateTime _datum;
        private string _text;
        private string _year;
        private string _month;
        private string _day;
        private string _time;

        public DateTime Datum => DateTime.Parse(String.Format($"{_day}/{_month}/{_year} {_time}"));
        public string Year => _year;
        public string Month => _month;
        public string Day => _day;
        public string Time => _time;
        public string Text => _text;

        public ClsLogFileLine(string year, string month, string day, string time, string text)
        {
            _year = year;
            _month = month;
            _day = day;
            _time = time;
            _text = text;
        }
    }
}
