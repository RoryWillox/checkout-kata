namespace Checkout;

/// <summary>
/// Represents the unit price of product.
/// </summary>
public class SkuPrice
{
    /// <summary>
    /// Initializes a new instance of <see cref="SkuPrice"/>.
    /// </summary>
    /// <param name="sku">Stock keeping unit.</param>
    /// <param name="price">Unit price.</param>
    public SkuPrice(string sku, decimal price)
    {
        Sku = sku;
        Price = price;
    }
    
    /// <summary>
    /// Stock keeping unit.
    /// </summary>
    public string Sku { get; private set; } 
    
    /// <summary>
    /// Unit price.
    /// </summary>
    public decimal Price { get; private set; } 
}