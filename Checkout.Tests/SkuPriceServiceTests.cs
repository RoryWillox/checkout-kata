namespace Checkout.Tests;

public class SkuPriceServiceTests
{
    private readonly SkuPriceService _skuPriceService;
    
    public SkuPriceServiceTests()
    {
        var skuPrices = new List<SkuPrice>()
        {
            new SkuPrice("A", 9.99m),
            new SkuPrice("B", 15m),
            new SkuPrice("C", 60m),
        };
        
        _skuPriceService = new SkuPriceService(skuPrices);
    }

    [Fact]
    public void GetPrice_ValidItem_ReturnsPrice()
    {
        // Arrange
        
        // Act
        decimal? priceA = _skuPriceService.GetPrice("A");
        decimal? priceB = _skuPriceService.GetPrice("B");
        decimal? priceC = _skuPriceService.GetPrice("C");

        // Assert
        Assert.Equal(9.99m, priceA);
        Assert.Equal(15m, priceB);
        Assert.Equal(60m, priceC);
    }

    [Fact]
    public void GetPrice_InvalidItem_ReturnsNull()
    {
        // Arrange
        
        // Act
        decimal? priceD = _skuPriceService.GetPrice("D");

        // Assert
        Assert.Null(priceD);
    }
}