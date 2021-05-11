using System;

namespace Server.ServerCore.Services.Utilities
{
    public interface IServices<in TType> where TType : Enum
    {
        TService Get<TService>(TType type) where TService : IService;
        void Clear();
    }
}