﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystemUI.Application
{
    public class WinAccount :IWinAccount
    {
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public override string ToString() => Name;
    }
}
