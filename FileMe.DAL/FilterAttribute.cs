using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMe.DAL
{
    public class FilterAttribute: Attribute
    {
        public Type Type { get; set; }
    }
}
