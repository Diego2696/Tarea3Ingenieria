using Domain;
using Infraestructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Infraestructure.IoC
{
    public sealed class FactoryIoC
    {
        private static readonly FactoryIoC _container = new FactoryIoC();
        private readonly IUnityContainer _unityContainer;

        private FactoryIoC()
        {
            _unityContainer = new Unity.UnityContainer();


            //Registro de las clases
            _unityContainer.RegisterType<IRepositoryPerson, RepositoryPerson>();

        }

        public static FactoryIoC Container
        {
            get { return _container; }
        }


        public TService Resolver<TService>()
        {
            return _unityContainer.Resolve<TService>();
        }
    }
}
