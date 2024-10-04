namespace Products.Catalogs.Domain.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductCommand, Product>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<UpdateProductCommand, Product>();
    }
}
