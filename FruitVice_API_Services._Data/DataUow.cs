﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FruitVice_API_Services_Data
{
    public class DataUow : IDataUoW
    {
       protected Dictionary<Type, object> Repositories { get; set; }

    }
}
