
using Demo_MVVMBasic.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_MVVMBasic.BusinessLayer
{
    /// <summary>
    /// Repository for CRUD
    /// Note: the _dataService object is instantiated with either the XML or Json class based on the value set in the DataConfig class
    /// </summary>
    class WidgetRepository : IWidgetRepository, IDisposable
    {
        private IDataService _dataService;
        List<Widget> _widgets;

        /// <summary>
        /// set the correct data service (XML or Json) data service and read in a list of all widgets
        /// </summary>
        public WidgetRepository()
        {
            _dataService = SetDataService();

            try
            {
                _widgets = _dataService.ReadAll() as List<Widget>;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// instantiate and return the correct data service (XML or Json) 
        /// </summary>
        /// <returns>data service object</returns>
        private IDataService SetDataService()
        {
            switch (DataConfig.dataType)
            {
                case DataType.XML:
                    return new DataServiceXml();

                case DataType.JSON:
                    return new DataServiceJson();

                default:
                    throw new Exception();
            }
        }

        /// <summary>
        /// retrieve all widgets
        /// </summary>
        /// <returns>all widgets</returns>
        public IEnumerable<Widget> GetAll()
        {
            return _widgets;
        }

        /// <summary>
        /// retrieve a widget by the id
        /// </summary>
        /// <param name="name">widget name</param>
        /// <returns></returns>
        public Widget GetById(string name)
        {
            return _widgets.FirstOrDefault(c => c.Name == name);
        }

        /// <summary>
        /// add a new widget
        /// </summary>
        /// <param name="widget">widget</param>
        public void Add(Widget widget)
        {
            try
            {
                _widgets.Add(widget);
                _dataService.WriteAll(_widgets);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// delete a widget
        /// </summary>
        /// <param name="name">widget id</param>
        public void Delete(string name)
        {
            try
            {
                _widgets.Remove(_widgets.FirstOrDefault(c => c.Name == name));

                _dataService.WriteAll(_widgets);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// update a widget
        /// </summary>
        /// <param name="widget">widget</param>
        public void Update(Widget widget)
        {
            try
            {
                _widgets.Remove(_widgets.FirstOrDefault(c => c.Name == widget.Name));
                _widgets.Add(widget);

                _dataService.WriteAll(_widgets);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// required if class will be use in a 'using" block
        /// </summary>
        public void Dispose()
        {
            _dataService = null;
            _widgets = null;
        }
    }
}
