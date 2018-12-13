using AutoMapper;
using CustomerValueResolversAttempt2.So11555721;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomerValueResolversAttempt2
{
    [TestClass]
    public class UnitTest1
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Bar, BarViewModel>();
            });
        }

        [TestMethod]
        public void Inline()
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

            Assert.IsNotNull(fooViewModel);
            Assert.IsNotNull(fooViewModel.BarViewModel);

            Assert.AreEqual("Mike D", fooViewModel.BarViewModel.Name);

            var fooWithNullBar = new Foo();

            var fooViewModel2 = mapper.Map<FooViewModel>(fooWithNullBar);

            Assert.AreEqual("NULL HELPER", fooViewModel2.BarViewModel.Name);
        }

        [TestMethod]
        public void IMemberValueResolver()
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

            Assert.IsNotNull(fooViewModel);
            Assert.IsNotNull(fooViewModel.BarViewModel);

            Assert.AreEqual("Mike D", fooViewModel.BarViewModel.Name);

            var fooWithNullBar = new Foo();

            var fooViewModel2 = mapper.Map<FooViewModel>(fooWithNullBar);

            Assert.AreEqual(nameof(NullBarResolver), fooViewModel2.BarViewModel.Name);
        }
    }
}
