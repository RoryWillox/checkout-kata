namespace Checkout;

/// <inheritdoc cref="IProductOfferService"/>
public class ProductOfferService : IProductOfferService
{
    private readonly List<ProductOffer> _productOffers;
    
    /// <summary>
    /// Initializes a new instance of <see cref="ProductOfferService"/> using a list of <see cref="ProductOffer"/>.
    /// </summary>
    /// <param name="productOffers">List of product offers.</param>
    public ProductOfferService(List<ProductOffer> productOffers)
    {
        _productOffers = productOffers;
    }

    public List<ProductOffer> GetOffers(string sku)
    {
        return _productOffers.Where(po => po.Sku == sku).ToList();
    }
}