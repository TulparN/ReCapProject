﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DataAccess.Concrete.EntityFramework;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(c => c.CarId).NotEmpty();
            RuleFor(c => c.CustomerId).NotEmpty();
            RuleFor(c => c.RentDate).NotEmpty();
            RuleFor(c => c.ReturnDate).NotEmpty();
            RuleFor(c => c.RentDate).GreaterThanOrEqualTo(DateTime.Today);
            RuleFor(c => c.ReturnDate).GreaterThan(c => c.RentDate);
        }
      



    }
}
