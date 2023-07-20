namespace Checkout;

/// <inheritdoc cref="IProductOfferService"/>
public class ProductOfferService : IProductOfferService
{
    /// <summary>
    /// Initializes a new instance of <see cref="ProductOfferService"/> using a list of <see cref="ProductOffer"/>.
    /// </summary>
    /// <param name="productOffers">List of product offers.</param>
    public ProductOfferService(List<ProductOffer> productOffers)
    {
        
    }

    public List<ProductOffer> GetOffers(string sku)
    {
        throw new NotImplementedException();
    }
}