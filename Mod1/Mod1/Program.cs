using Mod1;
using Mod1.Shared;
using Mod1.Source;
using Mod1.Target;

IPriceParser priceParser = new PriceParser();
IProductFormatter productFormatter = new ProductFormatter();

IProductSource productSource = new ProductSource(priceParser, new Configuration());
IProductTarget productTarget = new ProductTarget(productFormatter, new Configuration());

var productImporter = new ProductImporter(productSource, productTarget);

productImporter.Run();