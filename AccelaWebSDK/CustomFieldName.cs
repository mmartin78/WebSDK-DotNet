using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accela.SDK.Shared
{
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]
    public class CustomFieldName : System.Attribute
    {
        public string name { get; set; }
        public CustomFieldName(string name)
        {
            this.name = name;
        }
    }
}
