namespace Checkout.Tests;

public class ProductOfferServiceTests
{
    private readonly ProductOfferService _productOfferService;
    
    public ProductOfferServiceTests()
    {
        var productOffers = new List<ProductOffer>()
        {
            new ProductOffer("A", 3, 130m),
            new ProductOffer("B", 2, 45m),
        };

        _productOfferService = new ProductOfferService(productOffers);
    }

    [Fact]
    public void GetOffer_SkuWithOffer_ReturnsCorrectProductOffer()
    {
        // Arrange
        
        // Act
        List<ProductOffer> productOffers = _productOfferService.GetOffers("A");
        
        // Assert
        Assert.Single(productOffers);
        var expectedProductOffer = new ProductOffer("A", 3, 130m);
        Assert.Equal(expectedProductOffer, productOffers[0]);
    }
    
    [Fact]
    public void GetOffer_SkuWithoutOffer_ReturnsEmpty()
    {
        // Arrange
        
        // Act
        List<ProductOffer> productOffers = _productOfferService.GetOffers("C");
        
        // Assert
        Assert.Empty(productOffers);
    }
}