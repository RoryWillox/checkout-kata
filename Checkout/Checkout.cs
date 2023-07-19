namespace Checkout;

public class Checkout : ICheckout
{
    public List<string> Items { get; }

    public decimal GetTotalPrice()
    {
        throw new NotImplementedException();
    }
    
    public void Scan(string item)
    {
        throw new NotImplementedException();
    }
}