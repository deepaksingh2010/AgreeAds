using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Xml;

namespace AgreeAdsWebApp.Controller
{
    public class ProductXMLController : ApiController
    {
        [HttpGet]
        public string GetCommandDetails(string fileType)
        {
            IFileCommand cmd = null;
            FileTypes ft;
            Enum.TryParse<FileTypes>(fileType, out ft);
            if (ft != null)
                cmd = ConvertorJson.FileFactory(ft);

            return cmd.getFileDataInJson();
        }
    }
    public enum FileTypes
    {
        Product,
        PatchSetupFileNames,
        SOSetupFileNames,
        LogLocations,
        RepositoryFolder,
        SharedFolder
    }
    public interface IFileCommand
    {
        string getFileDataInJson();
    }
    public class ConvertorJson
    {
        private ConvertorJson()
        { }
        public static string GetJsonFromXMLFelepath(string filepath)
        {
            string jsonText = string.Empty;
            XmlDocument doc = new XmlDocument();
            if (!string.IsNullOrEmpty(filepath))
            {
                doc.Load(filepath);
                jsonText = JsonConvert.SerializeXmlNode(doc);
            }
            else
            {
                jsonText = "No Content";
            }
            return jsonText;
        }
        public static IFileCommand FileFactory(FileTypes ft)
        {
            string strfilepath = string.Empty;
            switch (ft)
            {
                case FileTypes.Product:
                    {
                        return new ProductXML();
                    }
                case FileTypes.LogLocations:
                    {
                        return new clsLogLocations();
                    }
                case FileTypes.PatchSetupFileNames:
                    {
                        return new clsPatchSetupFileNames();
                    }
                case FileTypes.RepositoryFolder:
                    {
                        return new clsRepositoryFolder();
                    }
                case FileTypes.SharedFolder:
                    {
                        return new clsSharedFolder();
                    }
                case FileTypes.SOSetupFileNames:
                    {
                        return new clsSOSetupFileNames();
                    }
                default:
                    {
                        return new clsDefultXML();
                    }
            }
        }
    }
    public class clsDefultXML : IFileCommand
    {
        public string getFileDataInJson()
        {
            string strfilepath = HttpContext.Current.Server.MapPath("~/XMLDataSources/clsCustomSetupFileNames.xml");
            return ConvertorJson.GetJsonFromXMLFelepath(strfilepath);
        }
    }
    public class ProductXML : IFileCommand
    {
        public string getFileDataInJson()
        {
            string strfilepath = HttpContext.Current.Server.MapPath("XMLDataSources/ProductXML.xml");
            return ConvertorJson.GetJsonFromXMLFelepath(strfilepath);
        }
    }
    public class clsSOSetupFileNames : IFileCommand
    {
        public string getFileDataInJson()
        {
            string strfilepath = HttpContext.Current.Server.MapPath("/XMLDataSources/clsSOSetupFileNames.xml");
            return ConvertorJson.GetJsonFromXMLFelepath(strfilepath);
        }
    }
    public class clsPatchSetupFileNames : IFileCommand
    {
        public string getFileDataInJson()
        {
            string strfilepath = HttpContext.Current.Server.MapPath("/XMLDataSources/clsPatchSetupFileNames.xml");
            return ConvertorJson.GetJsonFromXMLFelepath(strfilepath);
        }
    }
    public class clsLogLocations : IFileCommand
    {
        public string getFileDataInJson()
        {
            string strfilepath = HttpContext.Current.Server.MapPath("/XMLDataSources/clsLogLocations.xml");
            return ConvertorJson.GetJsonFromXMLFelepath(strfilepath);
        }
    }
    public class clsRepositoryFolder : IFileCommand
    {
        public string getFileDataInJson()
        {
            string strfilepath = HttpContext.Current.Server.MapPath("/XMLDataSources/clsRepositoryFolder.xml");
            return ConvertorJson.GetJsonFromXMLFelepath(strfilepath);
        }
    }
    public class clsSharedFolder : IFileCommand
    {
        public string getFileDataInJson()
        {
            string strfilepath = HttpContext.Current.Server.MapPath("/XMLDataSources/clsSharedFolder.xml");
            return ConvertorJson.GetJsonFromXMLFelepath(strfilepath);
        }
    }
}
