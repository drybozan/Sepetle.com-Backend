using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.product_name).NotEmpty();
            RuleFor(p => p.product_name).MinimumLength(2);
            RuleFor(p => p.unit_price).NotEmpty();
            RuleFor(p => p.unit_price).GreaterThan(0);
            //RuleFor(p => p.unit_price).GreaterThanOrEqualTo(10).When(p=>p.category_id==1);
           /// RuleFor(p => p.product_name).Must(StartWithA).WithMessage("Ürün ismi A harfi ile başlamalı"); //a harfi ile başlamalı ürünler
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
