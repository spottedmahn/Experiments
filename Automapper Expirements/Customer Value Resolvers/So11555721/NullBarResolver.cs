using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerValueResolvers.So11555721
{
    public class NullBarResolver : IMemberValueResolver<object, object, Bar, BarViewModel>
    {
        public BarViewModel Resolve(object source, object destination, Bar sourceMember, BarViewModel destMember, ResolutionContext context)
        {
            if (sourceMember == null)
                return new BarViewModel
                {
                    Name = nameof(NullBarResolver)
                };

            return Mapper.Map(sourceMember, destMember);
        }
    }
}
