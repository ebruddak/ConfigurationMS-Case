using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.SettingCreateCommand
{
    public class SettingCreateValidator : AbstractValidator<SettingCreateCommand>
    {
        public SettingCreateValidator()
        {

        }
    }
}