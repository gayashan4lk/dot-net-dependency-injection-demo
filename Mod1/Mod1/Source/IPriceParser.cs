﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mod1.Model;

namespace Mod1.Source;

public interface IPriceParser
{
    Money Parse(string price);
}