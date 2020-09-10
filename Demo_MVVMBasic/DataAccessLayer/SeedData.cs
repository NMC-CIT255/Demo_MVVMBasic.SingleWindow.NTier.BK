using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_MVVMBasic.DataAccessLayer
{
    public static class SeedData
    {
        public static List<Widget> GetAllWidgets()
        {
            return new List<Widget>()
            {
                new Widget()
                {
                    Name = "Furry",
                    Color = "Red",
                    UnitPrice = 4.95,
                    CurrentInventory = 10
                },

                new Widget()
                {
                    Name = "Woody",
                    Color = "Brown",
                    UnitPrice = 6.95,
                    CurrentInventory = 15
                },

                new Widget()
                {
                    Name = "Rubbery",
                    Color = "Black",
                    UnitPrice = 3.95,
                    CurrentInventory = 20
                }
            };
        }

    }
}
