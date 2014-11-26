using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Backend
{
    public class SpecialDay
    {
        public string Title { get; private set; }

        public SpecialPayType PayType { get; private set; }

        public SpecialDay(string title, SpecialPayType payType)
        {
            this.Title = title;
            this.PayType = payType;
        }

        public static SpecialDay Weekend = new SpecialDay("Weekend", SpecialPayType.NoPay);

        internal XElement ToXml()
        {
            return new XElement("special-type",
                new XElement("title", this.Title),
                new XElement("type", this.PayType));
        }

        internal static SpecialDay Parse(XElement element)
        {
            if (!element.HasElements)
            {
                return null;
            }
            
            return new SpecialDay((string)element.Element("title"),
                (SpecialPayType)Enum.Parse(typeof(SpecialPayType), (string)element.Element("type")));
        }

        public override string ToString()
        {
            return this.Title;
        }
    }
}
