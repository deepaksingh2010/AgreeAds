using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace AgreeAdsWebApp.XMLProcesser
{
    public class clsXMLProcesser
    {
        public enum XMLTypes
        {
            Product,
            Category,
            SubCategory
        }
        public string GetXML(XMLTypes xml)
        {
            XmlDocument xmlProduct = new XmlDocument();
            if (xml==XMLTypes.Product)
            {
                string xmlPath = HttpContext.Current.Server.MapPath("XMLDataSources/Product.xml");               
                xmlProduct.Load(xmlPath);               
            }
            string json = JsonConvert.SerializeXmlNode(xmlProduct);
            return json;
        }
    }
}