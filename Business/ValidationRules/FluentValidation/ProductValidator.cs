using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product> 
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
            RuleFor(p => p.ProductName).Must(Ailebaslayan).WithMessage("Ürünler A harfi ile başlamalıdır."); //Ürünlerin isimleri A harfi ile başlamalı diye bir şey isterse yönetim 
        }

        private bool Ailebaslayan(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
//AbstractValidator bize FluentValidation kütüphanesinden geliyor.
//Sen kim için br doğrulamasın <Product> dediğimizde Product nesnesi için br doğrulama olduğunu anlıyoruz.
//İlerleyen derslerde AbstractValidator içerisinde bulunan "IValidator" interfacesini kullanacağız.
