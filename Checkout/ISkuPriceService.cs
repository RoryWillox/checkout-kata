namespace Checkout;

/// <summary>
/// Represents a service to retrieve the unit price of a product.
/// </summary>
public interface ISkuPriceService
{
    /// <summary>
    /// Get the unit price of an item.
    /// </summary>
    /// <param name="item">SKU of the item.</param>
    /// <returns>Unit price of the product or null if no pricing information.</returns>
    decimal? GetPrice(string item);
}