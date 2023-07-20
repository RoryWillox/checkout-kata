namespace Checkout;

/// <inheritdoc cref="ISkuPriceService"/>
public class SkuPriceService : ISkuPriceService
{
    private readonly Dictionary<string, decimal> _skuPrices;
    
    /// <summary>
    /// Initializes a new instance of <see cref="SkuPriceService"/> using a list of <see cref="SkuPrice"/>.
    /// </summary>
    /// <param name="skuPrices">SKU unit prices.</param>
    public SkuPriceService(List<SkuPrice> skuPrices)
    {
        _skuPrices = skuPrices.ToDictionary(sp => sp.Sku, sp => sp.Price);
    }

    public decimal? GetPrice(string item)
    {
        if (!_skuPrices.ContainsKey(item))
        {
            return null;
        }

        return _skuPrices[item];
    }
}