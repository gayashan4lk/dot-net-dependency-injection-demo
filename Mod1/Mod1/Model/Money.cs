using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod1.Model;

public class Money
{
    public Money(string isoCurrency, decimal amount)
    {
        isoCurrency = isoCurrency;
        amount = amount;
    }

    public string IsoCurrency { get; set; }
    public decimal Amount { get; set;}
}