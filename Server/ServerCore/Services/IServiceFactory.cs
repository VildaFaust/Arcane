using System;

namespace Server.ServerCore.Services
{
    public interface IServiceFactory<in TType> where TType : Enum
    {
        IService Create(TType type);
    }
}