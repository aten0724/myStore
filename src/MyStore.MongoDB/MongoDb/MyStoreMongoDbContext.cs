using MongoDB.Driver;
using MyStore.Models;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace MyStore.MongoDB;

[ConnectionStringName("Default")]
public class MyStoreMongoDbContext : AbpMongoDbContext
{
    public IMongoCollection<Product> Products => Collection<Product>();
    public IMongoCollection<Customer> Customers => Collection<Customer>();
    public IMongoCollection<Cart> Carts => Collection<Cart>();
    public IMongoCollection<ProductDiscount> ProductDiscounts => Collection<ProductDiscount>();
    public IMongoCollection<CartDiscount> CartDiscounts => Collection<CartDiscount>();

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.Entity<Product>(b =>
        {
            b.CollectionName = "Store.Products";
        });

        modelBuilder.Entity<Customer>(b =>
        {
            b.CollectionName = "Store.Customers";
        });

        modelBuilder.Entity<Cart>(b =>
        {
            b.CollectionName = "Store.Carts";
        });

        modelBuilder.Entity<ProductDiscount>(b =>
        {
            b.CollectionName = "Store.ProductDiscounts";
        });

        modelBuilder.Entity<CartDiscount>(b =>
        {
            b.CollectionName = "Store.CartDiscounts";
        });
    }
}
