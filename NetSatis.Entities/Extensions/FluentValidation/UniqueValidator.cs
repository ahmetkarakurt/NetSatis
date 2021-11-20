using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;
using FluentValidation.Validators;
using NetSatis.Entities.Context;
using NetSatis.Entities.Interfaces;

namespace NetSatis.Entities.Extensions.FluentValidation
{
    public class UniqueValidator<TEntiy>:PropertyValidator
    where TEntiy:class,IEntity,new()
    {
        public UniqueValidator():base("Girdiğiniz {PropertyName} kayıtlarda var.")
        {
            
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            using (var netSatisContext=new NetSatisContext())
            {
                var dataId = context.Instance.GetType().GetProperty("CariKodu").GetValue(context.Instance);
                var result = netSatisContext.Set<TEntiy>().Where($"{context.PropertyName}==@0 And CariKodu!=@1", context.PropertyValue,dataId).Any();
                return !result;
            }
        }
    }
}
