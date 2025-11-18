using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq;

namespace Lab2Console.Part1
{
    public class Password
    {
        private string _passwordValue;
        private const string DefaultPassword = "defaultPassword";

        public string Value
        {
            get { return _passwordValue; }
            private set { _passwordValue = value; }
        }

        public Password(string password)
        {
            _passwordValue = password;
        }

        public override string ToString() => $"Password: [ {Value} ]";

        public static Password operator -(Password p, char newItem)
        {
            if (string.IsNullOrEmpty(p.Value)) return new Password("");
            char[] chars = p.Value.ToCharArray();
            chars[chars.Length - 1] = newItem;
            return new Password(new string(chars));
        }

        public static Password operator ++(Password p)
        {
            p.Value = DefaultPassword;
            return p;
        }

        public static bool operator >(Password p1, Password p2) => p1.Value.Length > p2.Value.Length;
        public static bool operator <(Password p1, Password p2) => p1.Value.Length < p2.Value.Length;

        public static bool operator !=(Password p1, Password p2) => !(p1 == p2);
        public static bool operator ==(Password p1, Password p2)
        {
            if (ReferenceEquals(p1, p2)) return true;
            if (p1 is null || p2 is null) return false;
            return p1.Value == p2.Value;
        }

        public static bool operator true(Password p)
        {
            if (string.IsNullOrEmpty(p.Value) || p.Value.Length < 8) return false;
            return p.Value.Any(char.IsUpper) && p.Value.Any(char.IsLower) && p.Value.Any(char.IsDigit);
        }

        public static bool operator false(Password p)
        {
            if (string.IsNullOrEmpty(p.Value) || p.Value.Length < 8) return true;
            return !p.Value.Any(char.IsUpper) || !p.Value.Any(char.IsLower) || !p.Value.Any(char.IsDigit);
        }

        public override bool Equals(object obj)
        {
            if (obj is Password other)
            {
                return this.Value == other.Value;
            }
            return false;
        }

        public override int GetHashCode() => Value?.GetHashCode() ?? 0;
    }
}
