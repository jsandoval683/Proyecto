using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSServit.ViewModels;
using WSServit.Models;
using WSServit.Models.Entities;

namespace WSServit.ViewModels.Validations
{
    public class RegistrationViewModelValidator : AbstractValidator<RegistrationViewModel>
    {
        public RegistrationViewModelValidator()
        {
            RuleFor(vm => vm.Email).NotEmpty().WithMessage("Email cannot be empty");
            RuleFor(vm => vm.Password).NotEmpty().WithMessage("Password cannot be empty");
            RuleFor(vm => vm.Name).NotEmpty().WithMessage("FirstName cannot be empty");
            RuleFor(vm => vm.NickName).NotEmpty().WithMessage("NickName cannot be empty");
            RuleFor(vm => vm.FamilyName).NotEmpty().WithMessage("LastName cannot be empty");
            RuleFor(vm => vm.Location).NotEmpty().WithMessage("Location cannot be empty");
        }
    }
}