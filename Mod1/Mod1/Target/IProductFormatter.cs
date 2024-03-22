using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mod1.Model;

namespace Mod1.Target;

public interface IProductFormatter
{
    string Format(Product  product);

    string GetHeaderLine();
}