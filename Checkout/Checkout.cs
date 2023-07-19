namespace Checkout;

/// <inheritdoc cref="ICheckout"/>
public class Checkout : ICheckout
{
    /// <summary>
    /// Initializes a new instance of <see cref="Checkout"/>.
    /// </summary>
    public Checkout()
    {
        Items = new List<string>();
    }
    
    public List<string> Items { get; }

    public decimal GetTotalPrice()
    {
        throw new NotImplementedException();
    }
    
    public void Scan(string item) => Items.Add(item);
}