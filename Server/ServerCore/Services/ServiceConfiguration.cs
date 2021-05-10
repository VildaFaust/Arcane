using System;

namespace Server.ServerCore.Services
{
    public class ServiceConfiguration<TType> where TType : Enum
    {
        private readonly IServiceFactory<TType> _factory;
        private readonly Services<TType> _services;

        public ServiceConfiguration(IServiceFactory<TType> factory, Services<TType> services)
        {
            _factory = factory;
            _services = services;
        }

        public void Configuration()
        {
            var serviceTypes = (TType[]) Enum.GetValues(typeof(TType));
            
            foreach (var serviceType in serviceTypes)
            {
                _services.Add(serviceType,_factory.Create(serviceType));
            }
        }
    }
}