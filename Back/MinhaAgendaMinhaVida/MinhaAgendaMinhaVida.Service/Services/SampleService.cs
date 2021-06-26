using System;
using AutoMapper;
using MinhaAgendaMinhaVida.Domain.Commands.Sample;
using MinhaAgendaMinhaVida.Domain.Interfaces.Infra;
using MinhaAgendaMinhaVida.Domain.Interfaces.Service;
using MinhaAgendaMinhaVida.Domain.ViewModel;
using MinhaAgendaMinhaVida.Service.Validators.Sample;

namespace MinhaAgendaMinhaVida.Service.Services
{
    public class SampleService : BaseService, ISampleService
    {
        private readonly IMapper _mapper;
        private readonly ISampleRepository _sampleRepository;

        public SampleService(
            IMapper mapper,
            ISampleRepository sampleRepository)
        {
            _mapper = mapper;
            _sampleRepository = sampleRepository;
        }

        public SampleViewModel Get(int id)
        {
            return _mapper.Map<SampleViewModel>(_sampleRepository.Get(id));
        }

        public Guid Post(InsertSampleCommand command)
        {
            Validate(command, new InsertSampleValidator());
            return Guid.NewGuid();
        }
    }
}