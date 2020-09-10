using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_MVVMBasic
{
    public class WidgetOperation
    {
        public enum OperationStatus { OKAY, CANCEL }
        public OperationStatus Status { get; set; }
        public Widget Widget { get; set; }
    }
}
