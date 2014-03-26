using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Web.SDK.Models
{
    public interface IBaseTextValue
    {
        string text { get; set; }
        string value { get; set; }
    }


    public class BaseTextValue
    {
        public string text { get; set; }
        public string value { get; set; }
    }
}
