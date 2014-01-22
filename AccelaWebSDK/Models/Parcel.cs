using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Web.SDK.Models
{
    public class Subdivision
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class Parcel
    {
        public double improvedValue { get; set; }
        public string text { get; set; }
        public string councilDistrict { get; set; }
        public Primary primary { get; set; }
        public double landValue { get; set; }
        public double exemptionValue { get; set; }
        public string id { get; set; }
        public string township { get; set; }
        public int section { get; set; }
        public string planArea { get; set; }
        public int gisSequenceNumber { get; set; }
        public string book { get; set; }
        public string lot { get; set; }
        public string legalDescription { get; set; }
        public string status { get; set; }
        public string parcel { get; set; }
        public string tract { get; set; }
        public string supervisorDistrict { get; set; }
        public string mapReferenceInfo { get; set; }
        public Subdivision subdivision { get; set; }
        public string mapNumber { get; set; }
        public string censusTract { get; set; }
        public string range { get; set; }
        public double parcelArea { get; set; }
        public string page { get; set; }
        public string block { get; set; }
    }
}
