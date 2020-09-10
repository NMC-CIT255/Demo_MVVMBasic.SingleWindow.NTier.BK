using Demo_MVVMBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_MVVMBasic.BusinessLayer
{
    public interface IWidgetRepository
    {
        IEnumerable<Widget> GetAll();
        Widget GetById(string name);
        void Add(Widget character);
        void Update(Widget character);
        void Delete(string name);
    }
}
