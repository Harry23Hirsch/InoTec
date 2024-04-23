using System;
using System.Runtime.InteropServices;

namespace InoTec
{
    public class ClsLogFileLineType
    {
        private string _text;
        private string _year;
        private string _month;
        private string _day;
        private string _time;

        public string Year => _year;
        public string Month => _month;
        public string Day => _day;
        public string Time => _time;
        public string Text => _text;

        public ClsLogFileLineType(string year, string month, string day, string time, string text)
        {
            _year = year;
            _month = month;
            _day = day;
            _time = time;
            _text = text;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != this.GetType())
                return false;


            return Equals((ClsLogFileLineType)obj);
        }

        public bool Equals(ClsLogFileLineType other)
        {
            if (this.Time == other.Time &&
                this.Text == other.Text)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(ClsLogFileLineType other)
        {
            int result = this.Year.CompareTo(other.Year);
            if (result == 0)
            {
                result = this.Month.CompareTo(other.Month);
                if (result == 0)
                {
                    result = this.Day.CompareTo(other.Day);
                    {
                        if (result == 0)
                        {
                            result = this.Time.CompareTo(other.Time);
                        }
                    }
                }
            }

            return result;
        }
    }
}
