using System;

namespace Server.ServerCore.Services.Utilities
{
    public interface IServiceFactory<TType> where TType : Enum
    {
        IService Create(TType type);
    }
}