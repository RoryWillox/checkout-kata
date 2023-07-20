namespace Checkout.Tests;

public class SkuPriceServiceTests
{
    private readonly SkuPriceService _skuPriceService;
    
    public SkuPriceServiceTests()
    {
        var skuPrices = new List<SkuPrice>()
        {
            new SkuPrice("A", 50),
            new SkuPrice("B", 30),
            new SkuPrice("C", 20),
            new SkuPrice("D", 15),
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
        decimal? priceD = _skuPriceService.GetPrice("D");

        // Assert
        Assert.Equal(50, priceA);
        Assert.Equal(30, priceB);
        Assert.Equal(20, priceC);
        Assert.Equal(15, priceD);
    }

    [Fact]
    public void GetPrice_InvalidItem_ReturnsNull()
    {
        // Arrange
        
        // Act
        decimal? priceE = _skuPriceService.GetPrice("E");

        // Assert
        Assert.Null(priceE);
    }
}