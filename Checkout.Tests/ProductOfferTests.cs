namespace Checkout.Tests;

public class ProductOfferTests
{
    [Fact]
    public void ProductOffer_ValidOffer_InstantiatesProductOffer()
    {
        // Arrange
        string sku = "A";
        int quantity = 3;
        decimal specialPrice = 130;

        // Act
        ProductOffer productOffer = new ProductOffer(sku, quantity, specialPrice);
        
        // Assert
        Assert.Equal(sku, productOffer.Sku);
        Assert.Equal(quantity, productOffer.Quantity);
        Assert.Equal(specialPrice, productOffer.SpecialPrice);
    }
    
    [Fact]
    public void ProductOffer_ZeroQuantity_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        string sku = "A";
        int quantity = 0;
        decimal specialPrice = 130;

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new ProductOffer(sku, quantity, specialPrice));
    }
    
    [Fact]
    public void ProductOffer_NegativeQuantity_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        string sku = "A";
        int quantity = -3;
        decimal specialPrice = 130;

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new ProductOffer(sku, quantity, specialPrice));
    }
}