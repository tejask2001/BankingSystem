﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Exception_Handling_Collection.User_Exceptions
{
    internal class InsufficientFundException:ApplicationException
    {
        public InsufficientFundException(string message) : base(message) { }
    }
}
