﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Inventory_Management_System
{
    [Serializable]
    class UserData
    {

        public string user { get; set; }
        public string username { get; set; }
        public string viewrecord { get; set; }
        public string barcode { get; set; }
    }
}

