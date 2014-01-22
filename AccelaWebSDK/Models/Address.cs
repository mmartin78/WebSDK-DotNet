using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Web.SDK.Models
{
    public class StreetSuffix
    {
        public string value { get; set; }
        public string text { get; set; }
    }

    public class State
    {
        public string value { get; set; }
        public string text { get; set; }
    }

    public class Country
    {
        public string value { get; set; }
        public string text { get; set; }
    }

    public class UnitType
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class StreetDirection
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class Direction
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class StreetSuffixDirection
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class AddressTypeFlag
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class I18NStreetSuffixdirection
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class HouseFractionStart
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class HouseFractionEnd
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class Address
    {
        public int secondaryStreetNumber { get; set; }
        public string neighborhood { get; set; }
        public string levelStart { get; set; }
        public string fullAddress { get; set; }
        public string addressLine1 { get; set; }
        public string houseNumberStart { get; set; }
        public Primary primary { get; set; }
        public string unitEnd { get; set; }
        public string county { get; set; }
        public UnitType unitType { get; set; }
        public string addressLine2 { get; set; }
        public string levelPrefix { get; set; }
        public StreetDirection streetDirection { get; set; }
        public int id { get; set; }
        public string city { get; set; }
        public string houseAlphaStart { get; set; }
        public double yCoordinate { get; set; }
        public RecordId recordId { get; set; }
        public Direction direction { get; set; }
        public int streetEnd { get; set; }
        public string streetPrefix { get; set; }
        public State state { get; set; }
        public string postalCode { get; set; }
        public string levelEnd { get; set; }
        public RecordType type { get; set; }
        public int refAddressId { get; set; }
        public StreetSuffixDirection streetSuffixDirection { get; set; }
        public double xCoordinate { get; set; }
        public string inspectionDistrict { get; set; }
        public string unitStart { get; set; }
        public string description { get; set; }
        public AddressTypeFlag addressTypeFlag { get; set; }
        public string neighberhoodPrefix { get; set; }
        public StreetSuffix streetSuffix { get; set; }
        public I18NStreetSuffixdirection i18NStreetSuffixdirection { get; set; }
        public HouseFractionStart houseFractionStart { get; set; }
        public int streetStart { get; set; }
        public string streetName { get; set; }
        public double distance { get; set; }
        public string houseAlphaEnd { get; set; }
        public string serviceProviderCode { get; set; }
        public Country country { get; set; }
        public string inspectionDistrictPrefix { get; set; }
        public Status status { get; set; }
        public HouseFractionEnd houseFractionEnd { get; set; }
        public string secondaryRoad { get; set; }
    }
}
