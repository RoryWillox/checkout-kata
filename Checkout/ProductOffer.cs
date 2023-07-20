namespace Checkout;

/// <summary>
/// Represents a special offer for a product.
/// </summary>
public record ProductOffer
{
    /// <summary>
    /// Initializes a new instance of <see cref="ProductOffer"/>.
    /// </summary>
    /// <param name="sku">Stock keeping unit.</param>
    /// <param name="quantity">Quantity of products the offer applies to.</param>
    /// <param name="specialPrice">Price of the products after offer is applied.</param>
    public ProductOffer(string sku, int quantity, decimal specialPrice)
    {
        if (quantity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity), quantity,
                "Quantity must be a positive value greater than 0.");
        }
        
        Sku = sku;
        Quantity = quantity;
        SpecialPrice = specialPrice;
    }

    /// <summary>
    /// Stock keeping unit.
    /// </summary>
    public string Sku { get; private set; }

    /// <summary>
    /// Quantity of products the offer applies to.
    /// </summary>
    public int Quantity { get; private set; }

    /// <summary>
    /// Price of the products after offer is applied.
    /// </summary>
    public decimal SpecialPrice { get; private set; }
}