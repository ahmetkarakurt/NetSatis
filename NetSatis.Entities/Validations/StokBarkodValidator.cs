using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using NetSatis.Entities.Tables;

namespace NetSatis.Entities.Validations
{
    public class StokBarkodValidator : AbstractValidator<StokBarkod>
    {
        public StokBarkodValidator()
        {
            
            RuleFor(p => p.Barkod).NotEmpty().WithMessage("Barkod alanı boş geçilemez.").Length(5, 13)
                .WithMessage("Stok Adı alanı 5 ile 13 karakter arasında olabilir.");
            RuleFor(p => p.StokKodu).NotEmpty().WithMessage("Stok alanı boş geçilemez.");


        }
    }
}
