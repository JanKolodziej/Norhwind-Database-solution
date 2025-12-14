using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW_Class_lib
{
    public abstract class Exercise_temp
    {
        public NorthwindContext db;
        public Exercise_temp(NorthwindContext northwindContext)
        {
            db = northwindContext;
        }
    }
}
