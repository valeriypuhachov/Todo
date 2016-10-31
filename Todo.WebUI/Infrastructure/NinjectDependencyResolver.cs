using Microsoft.AspNet.Identity.EntityFramework;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Todo.Domain.Context;
using Todo.Domain.Identity;
using Todo.Domain.Models;
using Todo.Domain.Repository.Abstract;
using Todo.Domain.Repository.Concrete;

namespace Todo.WebUI.Infrastructure {
    public class NinjectDependencyResolver : IDependencyResolver {
        private IKernel _kernel;
        public NinjectDependencyResolver(IKernel kernelParam) {
            _kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
            => _kernel.TryGet(serviceType);

        public IEnumerable<object> GetServices(Type serviceType)
            => _kernel.GetAll(serviceType);

        private void AddBindings() {
            //_kernel.Bind<IRepository<ApplicationUser>>()
            //    .To<AppUserRepository>()
            //    .WhenInjectedInto<ApplicationSignInManager>()
            //    .InSingletonScope();

            //_kernel.Bind<IdentityDbContext<ApplicationUser>>()
            //    .To<ApplicationDbContext>()
            //    .WhenInjectedInto<ApplicationDbContext>()
            //    .InSingletonScope();

            _kernel.Bind<IRepositoryFactory>().To<EFRepositoryFactory>().InSingletonScope();
            _kernel.Bind<IdentityDbContext<ApplicationUser>>().To<ApplicationDbContext>().InSingletonScope();
            //_kernel.Bind<IUserTaskRepository>().To<AppTaskRepository>().InSingletonScope();
            //_kernel.Bind<IUserRepository>().To<AppUserRepository>().InSingletonScope();
        }
    }
}