namespace Checkout;

public interface ICheckout
{
    List<string> Items { get; }
    
    decimal GetTotalPrice();
    
    void Scan(string item);
}