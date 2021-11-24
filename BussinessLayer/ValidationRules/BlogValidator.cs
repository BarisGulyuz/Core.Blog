using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
  public  class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Başlık bölümü boş geçilemez");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("İçerik bölümü boş geçilemez.");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Görsel bölümü boş geçilemez.");
            RuleFor(x => x.BlogTitle).MinimumLength(3).WithMessage("Minimum 3 karakter");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Maksimum 150 karakter");
           
        }
    }
}
