namespace Checkout;

/// <summary>
/// Represents a service to retrieve offers for a product.
/// </summary>
public interface IProductOfferService
{
    /// <summary>
    /// Get all offers for a product.
    /// </summary>
    /// <param name="sku">SKU of the item.</param>
    /// <returns>List of all offers for the product.</returns>
    List<ProductOffer> GetOffers(string sku);
}