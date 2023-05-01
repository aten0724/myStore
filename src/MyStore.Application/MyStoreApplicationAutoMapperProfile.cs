using AutoMapper;
using MyStore.Carts.Dto;
using MyStore.Customers.Dto;
using MyStore.Products.Dto;
using MyStore.Models;
using MyStore.Discounts.Dto;

namespace MyStore;

public class MyStoreApplicationAutoMapperProfile : Profile
{
    public MyStoreApplicationAutoMapperProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<CreateUpdateProductDto, Product>().ReverseMap();

        CreateMap<Customer, CustomerDto>().ReverseMap();
        CreateMap<CreateUpdateCustomerDto, Customer>().ReverseMap();

        CreateMap<Cart, CartDto>().ReverseMap();
        CreateMap<CartItem, CartItemDto>().ReverseMap();

        CreateMap<ProductDiscount, ProductDiscountDto>().ReverseMap();
        CreateMap<CreateUpdateProductDiscountDto, ProductDiscount>().ReverseMap();
        CreateMap<Period, PeriodDto>().ReverseMap();

        CreateMap<CartDiscount, CartDiscountDto>().ReverseMap();
        CreateMap<CreateUpdateCartDiscountDto, CartDiscount>().ReverseMap();
    }
}
