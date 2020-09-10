using Demo_MVVMBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_MVVMBasic.DataAccessLayer
{
    public interface IDataService
    {
        IEnumerable<Widget> ReadAll();
        void WriteAll(IEnumerable<Widget> characters);
    }
}
