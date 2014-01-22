using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Web.SDK.Models
{
    public class Name
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class Options
    {
        public string Key { get; set; }
    }

    public class Field
    {
        public Name name { get; set; }
        public bool required { get; set; }
        public string value { get; set; }
        public string isRequired { get; set; }
        public string fieldType { get; set; }
        public int maxLength { get; set; }
        public Options options { get; set; }
    }

    public class ItemValue
    {
        public Name name { get; set; }
        public string value { get; set; }
    }

    public class Row
    {
        public int rowIndex { get; set; }
        public List<ItemValue> values { get; set; }
    }

    public class Subgroup
    {
        public List<Field> fields { get; set; }
        public List<Row> rows { get; set; }
        public Name name { get; set; }
    }

    public class Entity
    {
        public int entityId { get; set; }
        public string entityKey { get; set; }
    }

    public class Form
    {
        public string name { get; set; }
        public List<Subgroup> subgroups { get; set; }
    }

    public class Table
    {
        public string name { get; set; }
        public List<Subgroup> subgroups { get; set; }
    }

    public class Template
    {
        public List<Form> forms { get; set; }
        public List<Table> tables { get; set; }
        public Entity entity { get; set; }
    }
}
