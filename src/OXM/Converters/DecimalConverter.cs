using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace OXM
{
    public class DecimalConverter : SimpleTypeConverter<decimal>
    {
        public override string ToXml(decimal value)
        {
            return XmlConvert.ToString(value);
        }

        public override decimal ToObj(string value)
        {
            return XmlConvert.ToDecimal(value);
        }
    }


    public class NullableDecimalConverter : NullabeConverter<decimal>
    {
        protected override SimpleTypeConverter<decimal> Converter
        {
            get
            {
                return new DecimalConverter();
            }
        }
    }

}