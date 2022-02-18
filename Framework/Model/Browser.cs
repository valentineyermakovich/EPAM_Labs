using System;
using System.Collections.Generic;
using System.Text;


namespace Framework.Model
{
    class Browser
    {
        private string _browserName;
        public string BrowserName
        {
            get
            {
                return _browserName;
            }
            set
            {
                _browserName = value;
            }
        }

        public Browser() { }

        public Browser(string browser)
        {
            _browserName = browser;
        }

        public override string ToString()
        {
            return $"Browser[browser = {BrowserName}]";
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (!(typeof(Browser).IsInstanceOfType(obj))) return false;
            Browser user = (Browser)obj;

            return Equals(BrowserName, user.BrowserName);
        }

        public override int GetHashCode()
        {
            return BrowserName.GetHashCode();
        }
    }
}
