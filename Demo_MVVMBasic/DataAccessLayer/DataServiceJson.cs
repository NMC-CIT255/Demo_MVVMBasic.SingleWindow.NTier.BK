using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Newtonsoft;
using Newtonsoft.Json;

namespace Demo_MVVMBasic.DataAccessLayer
{
    public class DataServiceJson : IDataService
    {
        private string _dataFilePath;


        /// <summary>
        /// read the json file and load a list of widget objects
        /// </summary>
        /// <returns>list of widgets</returns>
        public IEnumerable<Widget> ReadAll()
        {
            List<Widget> widgets;

            try
            {
                using (StreamReader sr = new StreamReader(_dataFilePath))
                {
                    string jsonString = sr.ReadToEnd();

                    widgets = JsonConvert.DeserializeObject<List<Widget>>(jsonString);
                }

            }
            catch (Exception)
            {
                throw;
            }

            return widgets;
        }

        /// <summary>
        /// write the current list of widgets to the json data file
        /// </summary>
        /// <param name="widgets">list of widgets</param>
        public void WriteAll(IEnumerable<Widget> widgets)
        {
            string jsonString = JsonConvert.SerializeObject(widgets, Formatting.Indented);

            try
            {
                StreamWriter writer = new StreamWriter(_dataFilePath);
                using (writer)
                {
                    writer.WriteLine(jsonString);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataServiceJson()
        {
            _dataFilePath = DataConfig.DataPathJson;
        }
    }
}
