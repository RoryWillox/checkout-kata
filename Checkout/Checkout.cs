namespace Checkout;

/// <inheritdoc cref="ICheckout"/>
public class Checkout : ICheckout
{
    private readonly SkuPriceService _skuPriceService;
    
    /// <summary>
    /// Initializes a new instance of <see cref="Checkout"/>.
    /// </summary>
    public Checkout(SkuPriceService skuPriceService)
    {
        _skuPriceService = skuPriceService;
        Items = new List<string>();
    }
    
    public List<string> Items { get; }

    public decimal GetTotalPrice()
    {
        decimal totalPrice = 0;

        foreach (string item in Items)
        {
            decimal? unitPrice =_skuPriceService.GetPrice(item);

            if (unitPrice is null)
            {
                throw new InvalidOperationException($"Price not found for item: {item}");
            }

            totalPrice += (decimal)unitPrice;
        }

        return totalPrice;
    }
    
    public void Scan(string item) => Items.Add(item);
}