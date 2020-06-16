using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSServit.ViewModels.Validations;
using FluentValidation.Validators;
using ServiceStack.FluentValidation.Attributes;

namespace WSServit.ViewModels
{
    [Validator(typeof(CredentialsViewModelValidator))]
    public class CredentialsViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}