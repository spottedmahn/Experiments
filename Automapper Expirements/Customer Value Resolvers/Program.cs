using AutoMapper;
using CustomerValueResolvers.So11555721;
using System;

namespace CustomerValueResolvers
{
    class Program
    {
        static void Main(string[] args)
        {
            So11555721();

            So11555721_Inline();

            So11555721_IMemberValueResolver();

            Console.ReadLine();
        }

        private static void So11555721()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Bar, BarViewModel>();
            });
        }

        private static void So11555721_Inline()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Foo, FooViewModel>()
                   .ForMember(dest => dest.BarViewModel, opt => opt.MapFrom((src, dest) =>
                   {
                       if (src.Bar == null)
                           return new BarViewModel { Name = "NULL HELPER" };

                       return Mapper.Map<Bar, BarViewModel>(src.Bar);
                   }));
            });

            var foo = new Foo
            {
                Bar = new Bar
                {
                    Id = 1,
                    Name = "Mike D"
                }
            };

            var mapper = config.CreateMapper();

            var fooViewModel = mapper.Map<FooViewModel>(foo);

            var fooWithNullBar = new Foo();

            var fooViewModel2 = mapper.Map<FooViewModel>(fooWithNullBar);

            //put a break point at this curly brace and review the objects
        }

        private static void So11555721_IMemberValueResolver()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Foo, FooViewModel>()
   .ForMember(dest => dest.BarViewModel, opt => opt.MapFrom<NullBarResolver, Bar>(src => src.Bar));
            });

            var mapper = config.CreateMapper();

            var foo = new Foo
            {
                Bar = new Bar
                {
                    Id = 1,
                    Name = "Mike D"
                }
            };

            var fooViewModel = mapper.Map<FooViewModel>(foo);

            var fooWithNullBar = new Foo();

            var fooViewModel2 = mapper.Map<FooViewModel>(fooWithNullBar);
        }
    }
}
