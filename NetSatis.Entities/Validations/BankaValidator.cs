using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using NetSatis.Entities.Tables;

namespace NetSatis.Entities.Validations
{
    public class BankaValidator : AbstractValidator<Banka>
    {
        public BankaValidator()
        {
            RuleFor(p => p.BankaKodu).NotEmpty().WithMessage("Banka Kodu alanı boş geçilemez.");
            RuleFor(p => p.BankaAdi).NotEmpty().WithMessage("Banka Adı alanı boş geçilemez.");
        }
    }
}
