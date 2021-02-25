using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRulesFluentValidation
{
   public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Renk adı en az 2 karakter uzunluğunda olmalıdır.");
        }
    }
}
