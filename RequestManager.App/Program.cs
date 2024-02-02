
using RequestManager.App.Models.Request.Brands;
using RequestManager.App.Services;

TrendyolRequestManager trendyolRequestManager = new TrendyolRequestManager();

do
{
    Console.Clear();
    Console.Write("Aranacak Trendyol Marka İsmi Giriniz=");
    string brandName = Console.ReadLine();

    var trendyolBrands = trendyolRequestManager.SearchTrendyolBrands(new GetTrendyolBrandByNameRequest
    {
        BrandName = brandName
    });

    if (trendyolBrands is not null && trendyolBrands.TrendyolBrands is not null)
        foreach (var brand in trendyolBrands.TrendyolBrands)
        {
            Console.WriteLine($"{brand.BrandId} ---- {brand.BrandName}");
        }

} while (Console.ReadKey().Key == ConsoleKey.R);
