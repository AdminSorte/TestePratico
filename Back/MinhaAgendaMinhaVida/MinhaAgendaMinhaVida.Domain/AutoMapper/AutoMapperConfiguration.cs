using AutoMapper;

namespace MinhaAgendaMinhaVida.Domain.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static IMapperConfigurationExpression RegisterMappings(IMapperConfigurationExpression conf)
        {
            conf.AddProfile(new DomainToViewModelMappingProfile());
            conf.AddProfile(new ViewModelToDomainMappingProfile());
            conf.AddProfile(new CommandToDomainMappingProfile());
            conf.AddProfile(new CommandToFilterMappingProfile());
            return conf;
        }
    }
}