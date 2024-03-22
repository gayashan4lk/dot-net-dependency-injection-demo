using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mod1.Model;

namespace Mod1.Target;

public interface IProductTarget
{
    void Open();

    void AddProduct(Product product);

    void Close();
}