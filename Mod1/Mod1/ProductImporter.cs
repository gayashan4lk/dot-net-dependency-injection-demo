using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mod1.Source;
using Mod1.Target;

namespace Mod1;

public class ProductImporter
{
    private readonly IProductSource _productSource;
    private readonly IProductTarget _productTarget;

    public ProductImporter(IProductSource productSource, IProductTarget productTarget)
    {
        _productSource = productSource;
        _productTarget = productTarget;
    }

    public void Run()
    {
        _productSource.Open();
        _productTarget.Open();

        while (_productSource.HasMoreProducts())
        {
            var product = _productSource.GetNextProduct();
            _productTarget.AddProduct(product);
        }

        _productSource.Close();
        _productTarget.Close();

        Console.WriteLine("Successfully written new file.");
    }
}