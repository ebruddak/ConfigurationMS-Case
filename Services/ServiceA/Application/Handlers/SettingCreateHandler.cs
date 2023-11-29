using AutoMapper;
using MediatR;
using Application.Commands.SettingCreateCommand;
using Application.Responses;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class SettingCreateHandler : IRequestHandler<SettingCreateCommand, SettingResponse>
    {
        private readonly ISettingRepository _settingRepository;
        private readonly IMapper _mapper;

        public SettingCreateHandler(
            ISettingRepository settingRepository,
            IMapper mapper)
        {
            _settingRepository = settingRepository;
            _mapper = mapper;
        }

        public async Task<SettingResponse> Handle(SettingCreateCommand request, CancellationToken cancellationToken)
        {
            var settingEntity = _mapper.Map<Setting>(request);
            if (settingEntity == null)
                throw new ApplicationException("Entity could not be mapped!");

            var setting = await _settingRepository.AddAsync(settingEntity);

            var settingResponse = _mapper.Map<SettingResponse>(setting);

            return settingResponse;
        }
    }
}