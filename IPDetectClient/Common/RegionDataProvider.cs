using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;

namespace IPDectect.Client.Common
{
    public class RegionModel
    {
        public string Name
        {
            get;
            set;
        }

        public string Code
        {
            get;
            set;
        }

        public string ParentCode
        {
            get;
            set;
        }
    }

    internal static class RegionDataProvider
    {
        public static RegionModel EMPTY_ITEM
        {
            get
            {
                RegionModel model = new RegionModel();
                model.Name = "--请选择--";
                model.Code = "-1";
                model.ParentCode = "-1";
                return model;
            }
        }
        public static List<RegionModel> GetProvinces()
        {
            List<RegionModel> result = new List<RegionModel>();
            foreach (RegionModel r in StandardRegions)
            {
                if(r.ParentCode == "0")
                {
                    result.Add(r);
                }
            }

            return result;
        }

        public static List<RegionModel> GetChildren(string parentCode)
        {
            List<RegionModel> result = new List<RegionModel>();
            foreach (RegionModel r in StandardRegions)
            {
                if (r.ParentCode == parentCode)
                {
                    result.Add(r);
                }
            }
            return result;
        }

        private static List<RegionModel> _standardRegions = null;
        private static List<RegionModel> StandardRegions
        {
            get
            {
                if (_standardRegions == null)
                {
                    InitRegionData();
                }

                return _standardRegions;
            }
        }

        private static void InitRegionData()
        {
            try
            {
                _standardRegions = new List<RegionModel>();

                Assembly assembly;
                //StreamReader textStreamReader;

               assembly = Assembly.GetExecutingAssembly();
               //textStreamReader = new StreamReader(assembly.GetManifestResourceStream("MyNamespace.region.txt"));

                //using (StreamReader sr = new StreamReader("region.txt"))
               using (StreamReader sr = new StreamReader(assembly.GetManifestResourceStream("IPDectect.Client.region.txt")))
                {
                    String line;
                    // Read and create region object from the file until the end of the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (!String.IsNullOrEmpty(line))
                        {
                            // parse the txt  region,code,parentcode
                            line = line.Trim();
                            string[] arr = line.Split('\t');
                            if (arr != null && arr.Length == 3)
                            {
                                RegionModel reg = new RegionModel();
                                reg.Name = arr[0];
                                reg.Code = arr[1];
                                reg.ParentCode = arr[2];
                                _standardRegions.Add(reg);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //private static DataTable _standardRegions = null;
        //public static DataTable StandardRegions
        //{
        //    get
        //    {
        //        if (_standardRegions == null)
        //        {
        //            InitRegionData();
        //        }

        //        return _standardRegions;
        //    }
        //}

        //private static void InitRegionData()
        //{
        //    DataTable table = new DataTable("Regions");
        //    table.Columns.Add("RegionName");
        //    table.Columns.Add("Code");
        //    table.Columns.Add("ParentCode");

        //    var row = table.NewRow();
        //    row["RegionName"] = "";
        //    row["Code"] = "";
        //    row["ParentCode"] = "";
        //}
    }


}
