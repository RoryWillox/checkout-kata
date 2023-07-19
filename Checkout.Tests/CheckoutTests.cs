namespace Checkout.Tests;

public class CheckoutTests
{
    private readonly Checkout _checkout;
    
    public CheckoutTests()
    {
        var skuPrices = new List<SkuPrice>()
        {
            new SkuPrice("A", 9.99m),
            new SkuPrice("B", 15m),
            new SkuPrice("C", 60m),
        };

        var skuPriceService = new SkuPriceService(skuPrices);
        _checkout = new Checkout(skuPriceService);
    }
    
    [Fact]
    public void Scan_SingleItem_AddedToCheckout()
    {
        // Arrange
        var item = "A";

        // Act
        _checkout.Scan(item);

        // Assert
        List<string> items = _checkout.Items;
        Assert.Single(items);
        Assert.Equal(item, items[0]);
    }

    [Fact]
    public void Scan_ItemTwice_BothAddedToCheckout()
    {
        // Arrange
        var item0 = "A";
        var item1 = "A";

        // Act
        _checkout.Scan(item0);
        _checkout.Scan(item1);

        // Assert
        List<string> items = _checkout.Items;
        Assert.Equal(2, items.Count);
        Assert.Equal(item0, items[0]);
        Assert.Equal(item1, items[1]);
    }

    [Fact]
    public void Scan_MultipleItems_AllAddedToCheckout()
    {
        // Arrange
        var item0 = "A";
        var item1 = "B";
        var item2 = "C";

        // Act
        _checkout.Scan(item0);
        _checkout.Scan(item1);
        _checkout.Scan(item2);

        // Assert
        List<string> items = _checkout.Items;
        Assert.Equal(3, items.Count);
        Assert.Equal(item0, items[0]);
        Assert.Equal(item1, items[1]);
        Assert.Equal(item2, items[2]);
    }

    [Fact]
    public void GetTotalPrice_EmptyCart_ReturnsZero()
    {
        // Arrange

        // Act
        decimal totalPrice = _checkout.GetTotalPrice();

        // Assert
        Assert.Equal(0, totalPrice);
    }

    [Fact]
    public void GetTotalPrice_ItemsWithNoOffers_CalculatesBasicPrice()
    {
        // Arrange
        _checkout.Scan("A");
        _checkout.Scan("B");
        _checkout.Scan("C");

        // Act
        decimal totalPrice = _checkout.GetTotalPrice();

        // Assert
        Assert.Equal(84.99m, totalPrice);
    }
}