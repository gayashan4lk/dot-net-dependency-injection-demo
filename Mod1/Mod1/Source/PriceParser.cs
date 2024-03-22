using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mod1.Model;

namespace Mod1.Source;

public class PriceParser : IPriceParser
{
    public Money Parse(string price)
    {
        var parts = price.Split(' ');
        
        var currency = parts[0];
        var amount = decimal.Parse(parts[1]);

        var money = new Money(currency, amount);
        return money;
    }
}