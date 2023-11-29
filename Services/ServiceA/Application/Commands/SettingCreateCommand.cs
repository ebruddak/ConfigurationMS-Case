
using MediatR;
using Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.SettingCreateCommand
{
    public class SettingCreateCommand : IRequest<SettingResponse>
    {
        public string ConnectionString { get; set; }
        public string MaxItemCount { get; set; }

    }
}