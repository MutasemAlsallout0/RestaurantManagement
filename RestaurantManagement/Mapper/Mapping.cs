using AutoMapper;
using RestaurantManagement.Models;
using RestaurantManagement.ModelsViews;

namespace RestaurantManagement.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Customer, CustomerView>().ReverseMap();
            CreateMap<RestaurantMenu, RestaurantMenuView>().ReverseMap();
            CreateMap<Restaurantt, RestaurantView>().ReverseMap();
        }
    }
}
