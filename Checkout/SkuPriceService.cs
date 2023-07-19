namespace Checkout;

/// <summary>
/// Represents a service to retrieve the unit price of a product.
/// </summary>
public class SkuPriceService
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

    /// <summary>
    /// Get the unit price of an item.
    /// </summary>
    /// <param name="item">SKU of the item.</param>
    /// <returns>Unit price of the product or null if no pricing information.</returns>
    public decimal? GetPrice(string item)
    {
        if (!_skuPrices.ContainsKey(item))
        {
            return null;
        }

        return _skuPrices[item];
    }
}