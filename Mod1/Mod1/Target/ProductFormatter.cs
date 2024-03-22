using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mod1.Model;

namespace Mod1.Target;

public class ProductFormatter : IProductFormatter
{
    private const string HeaderLine = "Id,Name,Currency,Price,Stock";

    public string Format(Product product)
    {
        var stringBuilder = new StringBuilder();

        AppendItem(stringBuilder, product.Id.ToString(), true);
        AppendItem(stringBuilder, product.Name, false);
        AppendItem(stringBuilder, product.Price.IsoCurrency, false);
        AppendItem(stringBuilder, product.Price.Amount.ToString(CultureInfo.InvariantCulture), false);
        AppendItem(stringBuilder, product.Stock.ToString(), false);

        return stringBuilder.ToString();
    }

    public string GetHeaderLine()
    {
        return HeaderLine;
    }

    private void AppendItem(StringBuilder stringBuilder, string item, bool isFirst)
    {
        if (!isFirst)
        {
            stringBuilder.Append(",");

        }

        if (item.Any(c => char.IsWhiteSpace(c)))
        {
            stringBuilder.Append("\"");
            stringBuilder.Append(item);
            stringBuilder.Append("\"");
        }
        else
        {
            stringBuilder.Append(item);
        }
    }
}
