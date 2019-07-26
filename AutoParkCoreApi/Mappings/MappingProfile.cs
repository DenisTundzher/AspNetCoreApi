using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Models;
using DAL.Entity;

namespace AutoParkCoreApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Car, CarModel>();

            CreateMap<CarOwners, CarModel>()
                .ForMember(x => x.Id, _ => _.MapFrom(y => y.Car.Id))
                .ForMember(x => x.Color, _ => _.MapFrom(y => y.Car.Color))
                .ForMember(x => x.Brand, _ => _.MapFrom(y => y.Car.Brand));

            CreateMap<CarModel, Car>();
            CreateMap<ICollection<CarOwners>, ICollection<CarModel>>();
            CreateMap<Owner, OwnerModel>()
                .ForMember(x => x.Cars, _ => _.Ignore());
            //.ForMember(x => x.Cars, _ => _.MapFrom(y => y.CarOwners));

            CreateMap<OwnerModel, Owner>();
            CreateMap<CarOwners, CarOwnersModel>();

            CreateMap<CarOwnersModel, CarOwners>();
        }
    }
}



/*CreateMap<PaginatedList<Owner>, PaginatedList<OwnerModel>>()
                .ForMember(x => x.HasNextPage, _ => _.MapFrom(y => y.HasNextPage))
                .ForMember(x => x.HasPreviousPage, _ => _.MapFrom(y => y.HasPreviousPage))
                .ForMember(x => x.PageIndex, _ => _.MapFrom(y => y.PageIndex))
                .ForMember(x => x.TotalPages, _ => _.MapFrom(y => y.TotalPages));*/
