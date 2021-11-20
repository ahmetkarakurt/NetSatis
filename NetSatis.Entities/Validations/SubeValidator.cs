﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using NetSatis.Entities.Tables;

namespace NetSatis.Entities.Validations
{
    public class SubeValidator:AbstractValidator<Tanim>
    {
        public SubeValidator()
        {
            RuleFor(p => p.Turu).NotEmpty().WithMessage("Tanım Türü alanı boş geçilemez.");
            RuleFor(p => p.Tanimi).NotEmpty().WithMessage("Tanım alanı boş geçilemez.");
        }
    }
}
