using AutoMapper;
using UltraSoundWeb.Entities;
using UltraSoundWeb.Models;

namespace UltraSoundWeb.Common.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Info, InfoVM>();
            CreateMap<InfoVM, Info>();
            CreateMap<User, UserVM>();
            CreateMap<SpecializedVM, Specialized>();
            CreateMap<ResultImage, ResultImageVM>();
            CreateMap<PatientVM, Patient>();
            CreateMap<Patient, PatientVM>();
            CreateMap<Doctor, DoctorVM>();
            CreateMap<Specialized, SpecializedVM>();
            CreateMap<UltraSoundSampleVM, UltraSoundSample>();
            CreateMap<UltraSoundSample, UltraSoundSampleVM>();
            CreateMap<UltraSoundResultVM, UltraSoundResult>().ForMember(des => des.ResultImages, act => act.Ignore());
            CreateMap<UltraSoundResult, UltraSoundResultVM>().ForMember(des => des.ResultImages, act => act.Ignore()).ForMember(des => des.Images, act => act.MapFrom(x => x.ResultImages));
        }
    }
}
