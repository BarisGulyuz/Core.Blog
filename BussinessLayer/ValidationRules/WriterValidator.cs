using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class WriterValidator: AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Ad-Soyad bölümü boş geçilemez. Dilerseniz bir takma ad kullanabilirsiniz.");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail bölümü boş geçilemez.");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre bölümü boş geçilemez.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Minumum karakter sayısı 2 olmalıdır.");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Maximum karakter sayısı 50 olmalıdır.");
            RuleFor(x => x.WriterMail).EmailAddress().WithMessage("E-mail adresi geçerli bir e-mail olmalıdır.");
        }
    }
}
