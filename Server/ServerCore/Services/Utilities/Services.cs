using System;
using System.Collections.Generic;

namespace Server.ServerCore.Services.Utilities
{
    public class Services<TType> : IServices<TType> where TType : Enum
    {
        private readonly Dictionary<TType, IService> _services = new Dictionary<TType, IService>();
        
        public TService Get<TService>(TType type) where TService : IService
        {
            return (TService) _services[type];
        }

        public void Add(TType type, IService service)
        {
            _services.Add(type, service);
        }

        public void Clear()
        {
            foreach (var service in _services.Values)
            {
                service.Dispose();
            }
            
            _services.Clear();
        }
    }
}