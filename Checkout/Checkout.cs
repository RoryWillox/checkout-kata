namespace Checkout;

/// <inheritdoc cref="ICheckout"/>
public class Checkout : ICheckout
{
    private readonly ISkuPriceService _skuPriceService;
    private readonly IProductOfferService _productOfferService;
    
    /// <summary>
    /// Initializes a new instance of <see cref="Checkout"/>.
    /// </summary>
    public Checkout(ISkuPriceService skuPriceService, IProductOfferService productOfferService)
    {
        _skuPriceService = skuPriceService;
        _productOfferService = productOfferService;
        Items = new List<string>();
    }
    
    public List<string> Items { get; }

    public decimal GetTotalPrice()
    {
        List<SkuQuantity> skuQuantities = GetSkuQuantities();
        return skuQuantities.Sum(GetTotalPriceForSkuQuantity);
    }
    
    public void Scan(string item) => Items.Add(item);

    /// <summary>
    /// Get a list of SKUs and their quantities that have been scanned.
    /// </summary>
    /// <returns>List of all SKUs and their quantities that have been scanned.</returns>
    private List<SkuQuantity> GetSkuQuantities()
    {
        return Items.GroupBy(s => s)
            .Select(g => new SkuQuantity(g.Key, g.Count()))
            .ToList();
    }

    /// <summary>
    /// Apply applicable offers for a product.
    /// </summary>
    /// <param name="skuQuantity">SKU and quantity of the product.</param>
    /// <returns>Total price of product with offers applied.</returns>
    ///  <exception cref="InvalidOperationException">
    /// Throws <see cref="InvalidOperationException"/> when no pricing information is found for a scanned product.
    /// </exception>
    private decimal GetTotalPriceForSkuQuantity(SkuQuantity skuQuantity)
    {
        decimal totalPrice = 0;
        decimal baseUnitPrice = _skuPriceService.GetPrice(skuQuantity.Sku) 
                                 ?? throw new InvalidOperationException($"Price not found for item: {skuQuantity.Sku}");
            
        // Get product offers and order them by price per unit (best deal first)
        List<ProductOffer> productOffers = _productOfferService.GetOffers(skuQuantity.Sku)
            .OrderBy(po => po.SpecialPrice / po.Quantity)
            .ToList();

        int quantityRemaining = skuQuantity.Quantity;
        foreach (var productOffer in productOffers)
        {
            while (quantityRemaining >= productOffer.Quantity)
            {
                // Apply offer
                totalPrice += productOffer.SpecialPrice;
                quantityRemaining -= productOffer.Quantity;
            }
        }

        totalPrice += baseUnitPrice * quantityRemaining;
        return totalPrice;
    }
}