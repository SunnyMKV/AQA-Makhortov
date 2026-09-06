using System.Text.Json;

using AQA_Makhortov.DTO.OrderDataDTO;
using FluentAssertions;
using FluentAssertions.Execution;

namespace AQA_Makhortov.AutoTests;

public class OrderJsonTests
{
    private OrderDTO _order;
    
    [OneTimeSetUp]
    public void Setup()
    {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "OrderData.json");
        string json = File.ReadAllText(path);

        _order = JsonSerializer.Deserialize<OrderDTO>(json);
    }

    [Test]
    public void Test1_CheckItemIsNotNull()
    {
        foreach (var item in _order.Items)
        {
            TestContext.WriteLine($"{item.ProductId} | {item.Name} | {item.Category} | {item.Quantity} | {item.Price}");
        }
        _order.Items.Should().NotBeNull();
        _order.Items.Should().HaveCount(3);
    }

    [Test]
    public void Test2_CheckSumOfItems()
    {
        var sum = _order.Items.Select(item => item.Quantity * item.Price).Sum();
        sum.Should().Be(_order.Summary.ItemsTotal);
    }

    [Test]
    public void Test3_CheckElectronicsQuantity()
    {
        var electronics = _order.Items.Where(item => item.Category == "Electronics").ToList();
        
        using (new AssertionScope())
        {
            electronics.Should().OnlyContain(item => item.Category == "Electronics");
            electronics.Should().HaveCount(2);
        }
    }
}