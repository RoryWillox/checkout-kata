namespace Checkout.Tests;

public class CheckoutTests
{
    private readonly Checkout _checkout;
    
    public CheckoutTests()
    {
        var skuPrices = new List<SkuPrice>()
        {
            new SkuPrice("A", 50),
            new SkuPrice("B", 30),
            new SkuPrice("C", 20),
            new SkuPrice("D", 15),
        };

        var skuPriceService = new SkuPriceService(skuPrices);

        var productOffers = new List<ProductOffer>()
        {
            new ProductOffer("A", 3, 130m),
            new ProductOffer("B", 2, 45m),
        };

        var productOfferService = new ProductOfferService(productOffers);
        
        _checkout = new Checkout(skuPriceService, productOfferService);
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
        _checkout.Scan("D");

        // Act
        decimal totalPrice = _checkout.GetTotalPrice();

        // Assert
        Assert.Equal(115, totalPrice);
    }
    
    [Fact]
    public void GetTotalPrice_ItemWithNoPrice_ThrowsInvalidOperationException()
    {
        // Arrange
        _checkout.Scan("E");

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => _checkout.GetTotalPrice());
    }
    
    [Fact]
    public void GetTotalPrice_ItemsWithOffer_CalculatesReducedPrice()
    {
        // Arrange
        _checkout.Scan("A");
        _checkout.Scan("A");
        _checkout.Scan("A");

        // Act 
        decimal totalPrice = _checkout.GetTotalPrice();
        
        // Assert
        Assert.Equal(130m, totalPrice);
    }
    
    [Fact]
    public void GetTotalPrice_ItemsWithOfferAppliesTwice_CalculatesReducedPrice()
    {
        // Arrange
        _checkout.Scan("B");
        _checkout.Scan("B");
        _checkout.Scan("B");
        _checkout.Scan("B");

        // Act 
        decimal totalPrice = _checkout.GetTotalPrice();
        
        // Assert
        Assert.Equal(90m, totalPrice);
    }
    
    [Fact]
    public void GetTotalPrice_MultipleItemsInOrderWithOffers_CalculatesReducedPrice()
    {
        // Arrange
        _checkout.Scan("A");
        _checkout.Scan("A");
        _checkout.Scan("A");
        _checkout.Scan("B");
        _checkout.Scan("B");
        _checkout.Scan("C");
        _checkout.Scan("D");

        // Act 
        decimal totalPrice = _checkout.GetTotalPrice();
        
        // Assert
        Assert.Equal(210m, totalPrice);
    }
    
    [Fact]
    public void GetTotalPrice_MultipleItemsOutOfOrderWithOffers_CalculatesReducedPrice()
    {
        // Arrange
        _checkout.Scan("A");
        _checkout.Scan("C");
        _checkout.Scan("B");
        _checkout.Scan("A");
        _checkout.Scan("B");
        _checkout.Scan("D");
        _checkout.Scan("A");

        // Act 
        decimal totalPrice = _checkout.GetTotalPrice();
        
        // Assert
        Assert.Equal(210m, totalPrice);
    }
    
    [Fact]
    public void GetTotalPrice_SingleItemWithMultipleOffers_CalculatesReducedPrice()
    {
        // Arrange
        var skuPrices = new List<SkuPrice>()
        {
            new SkuPrice("A", 50),
        };
        var skuPriceService = new SkuPriceService(skuPrices);

        var productOffers = new List<ProductOffer>()
        {
            new ProductOffer("A", 3, 130m),
            new ProductOffer("A", 5, 200m),
        };
        var productOfferService = new ProductOfferService(productOffers);
        
        var checkout = new Checkout(skuPriceService, productOfferService);

        for (int i = 0; i < 8; i++)
        {
            checkout.Scan("A");
        }

        // Act 
        decimal totalPrice = checkout.GetTotalPrice();
        
        // Assert
        Assert.Equal(330m, totalPrice);
    }
}