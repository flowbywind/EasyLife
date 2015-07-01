using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLife.Core
{
    public class EnumDisplayNameAttribute : Attribute
    {
        private string _displayName;
        public EnumDisplayNameAttribute(string displayName)
        {
            _displayName = displayName;
        }

        public string DisplayName
        {
            get
            {
                return _displayName;
            }
        }
    }
}
