namespace Checkout.Tests;

public class CheckoutTests
{
    [Fact]
    public void Scan_SingleItem_AddedToCheckout()
    {
        // Arrange
        var item = "A";
        var checkout = new Checkout();

        // Act
        checkout.Scan(item);

        // Assert
        List<string> items = checkout.Items;
        Assert.Single(items);
        Assert.Equal(item, items[0]);
    }

    [Fact]
    public void Scan_ItemTwice_BothAddedToCheckout()
    {
        // Arrange
        var item0 = "A";
        var item1 = "A";
        var checkout = new Checkout();

        // Act
        checkout.Scan(item0);
        checkout.Scan(item1);

        // Assert
        List<string> items = checkout.Items;
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
        var checkout = new Checkout();

        // Act
        checkout.Scan(item0);
        checkout.Scan(item1);
        checkout.Scan(item2);

        // Assert
        List<string> items = checkout.Items;
        Assert.Equal(3, items.Count);
        Assert.Equal(item0, items[0]);
        Assert.Equal(item1, items[1]);
        Assert.Equal(item2, items[2]);
    }

    [Fact]
    public void GetTotalPrice_EmptyCart_ReturnsZero()
    {
        // Arrange
        var checkout = new Checkout();

        // Act
        decimal totalPrice = checkout.GetTotalPrice();

        // Assert
        Assert.Equal(0, totalPrice);
    }

    [Fact]
    public void GetTotalPrice_ItemsWithNoOffers_CalculatesBasicPrice()
    {
        // Arrange
        var checkout = new Checkout();
        checkout.Scan("A");
        checkout.Scan("B");
        checkout.Scan("C");

        // Act
        decimal totalPrice = checkout.GetTotalPrice();

        // Assert
        Assert.Equal(0, totalPrice);
    }
}