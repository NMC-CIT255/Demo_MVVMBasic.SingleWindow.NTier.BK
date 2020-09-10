using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo_MVVMBasic;

namespace Demo_MVVMBasic
{
    public class Widget : ObservableObject
    {        private string _name;
        private string _color;
        private double _unitPrice;
        private int _currentInventory;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public double UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }

        public int CurrentInventory
        {
            get { return _currentInventory; }
            set 
            {
                _currentInventory = value;
                OnPropertyChanged(nameof(CurrentInventory));
            }
        }

        /// <summary>
        /// makes a Shallow Copy of the Widget object
        /// </summary>
        /// <returns>Shallow Copy of the Widget object</returns>
        public Widget Copy()
        {
            return new Widget()
            {
                Name = _name,
                Color = _color,
                UnitPrice = _unitPrice,
                CurrentInventory = _currentInventory
            };
        }
    }
}
