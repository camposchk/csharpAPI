using System;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using csharpAPI.Model;

namespace csharpAPI.Services;

public class OrderRepository : IOrderRepository
{
    private readonly CsharpApiContext ctx;
    public OrderRepository(CsharpApiContext ctx)
        => this.ctx = ctx;

    public async Task AddItem(int orderId, int productId)
    {
        var order = await GetOrder(orderId);
        if (order is null)  
            throw new Exception("Order doesn't exist");

        var products = 
            from product in ctx.Products
            where product.Id == productId
            select product;

        var selectedProducts = await products.FirstOrDefaultAsync();

        if (selectedProducts is null)
            throw new Exception("Product doesn't exist");

            var item = new ClientOrderItem();
            item.ClientOrderId= orderId;
            item.ProductId = productId;

            ctx.Add(item);
            await ctx.SaveChangesAsync();
    }

    public async Task CancelOrder(int orderId)
    {
        var currentOrder = await GetOrder(orderId);

        if (currentOrder is null)
            throw new Exception("The order doesn't exist");

        ctx.Remove(currentOrder);
        await ctx.SaveChangesAsync();
    }

    public async Task<int> CreateOrder(int storeId)
    {
        var selectedStore = 
            from store in ctx.Stores
            where store.Id == storeId
            select store;
        if (!selectedStore.Any())
            throw new Exception("Store doesn't exist");


        var clientOrder = new ClientOrder();

        clientOrder.StoreId = storeId;
        clientOrder.OrderCode = "abcd1234";

        ctx.Add(clientOrder);
        await ctx.SaveChangesAsync();

        return clientOrder.Id;
    }

    public Task DeliveryOrder(int orderId)
    {
        throw new NotImplementedException();
    }

    public Task FinishOrder(int orderId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetMenu(int orderId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetOrderItems(int orderId)
    {
        throw new NotImplementedException();
    }

    public Task RemoveItem(int orderId, int productId)
    {
        throw new NotImplementedException();
    }

    private async Task <ClientOrder> GetOrder(int orderId)
    {
        var orders =
            from order in ctx.ClientOrders
            where order.Id == orderId
            select order;

        return await orders.FirstOrDefaultAsync();
    }
}