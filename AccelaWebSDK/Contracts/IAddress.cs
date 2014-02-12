using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accela.Web.SDK.Models;

namespace Accela.Web.SDK
{
    public interface IAddress
    {
        List<Country> GetCountries(string token);
        List<State> GetStates(string token);
    }
}
