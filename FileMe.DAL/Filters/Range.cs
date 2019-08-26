﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMe.DAL.Filters
{
    public struct Range<T>
        where T: struct
    {
        public T? From { get; set; }

        public T? To { get; set; }
    }
}
