namespace Checkout;

/// <summary>
/// Represents a checkout service, allowing items to be scanned and costs calculated.
/// </summary>
public interface ICheckout
{
    /// <summary>
    /// Get items scanned and in the checkout.
    /// </summary>
    List<string> Items { get; }
    
    /// <summary>
    /// Calculate the total price of the items in the checkout.
    /// </summary>
    /// <returns>Total price of items in the checkout.</returns>
    decimal GetTotalPrice();
    
    /// <summary>
    /// Add an item to the checkout.
    /// </summary>
    /// <param name="item">The item to be added to the checkout.</param>
    void Scan(string item);
}