using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using Mod1.Model;
using Mod1.Shared;

namespace Mod1.Source;

public class ProductSource: IProductSource
{
    private readonly IPriceParser _priceParser;
    private readonly Configuration _configuration;
    private TextFieldParser? _textFieldParser;

    public ProductSource(IPriceParser priceParser, Configuration configuration)
    {
        _priceParser = priceParser;
        _configuration = configuration;
    }


    public void Open()
    {
        _textFieldParser = new TextFieldParser(_configuration.SourceCsvPath);
        _textFieldParser.SetDelimiters(",");
    }

    public bool HasMoreProducts()
    {
        if (_textFieldParser == null)
            throw new InvalidOperationException("cannot read from a source that is not yet open");

        return !_textFieldParser.EndOfData;
    }

    public Product GetNextProduct()
    {
        if (_textFieldParser == null)
            throw new InvalidOperationException("cannot read from a source that is not yet open");

        var fields = _textFieldParser.ReadFields() ?? throw new InvalidOperationException("Could not read from source");

        var id = Guid.Parse(fields[0]);
        var name = fields[1];
        var price = _priceParser.Parse(fields[2]);
        var stock = int.Parse(fields[3]);

        var product = new Product(id, name, price, stock);
        return product;
    }

    public void Close()
    {
        if (_textFieldParser == null)
            throw new InvalidOperationException("cannot read from a source that is not yet open");

        _textFieldParser.Close();
        ((IDisposable)_textFieldParser).Dispose();
    }
}