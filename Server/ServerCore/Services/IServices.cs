using System;

namespace Server.ServerCore.Services
{
    public interface IServices<in TType> where TType : Enum
    {
        TService Get<TService>(TType type) where TService : IService;
        void Clear();
    }
}