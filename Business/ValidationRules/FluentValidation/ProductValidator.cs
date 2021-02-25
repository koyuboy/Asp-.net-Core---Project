using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator() //sadece product taki leri kontrol eder,, iş kodları ayzılmaz buraya karıştırma
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2); //burdaki p product olur yukarıdan gelir
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı!");

        }

        private bool StartWithA(string arg)//arg gelen parametre,, burda productName
        {//false dönerse rulefor patlar 
            return arg.StartsWith("A");//string fonksiyonu bu
        }
    }
}
