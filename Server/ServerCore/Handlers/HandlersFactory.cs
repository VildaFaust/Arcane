using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Server.ServerCore.Handlers.Authorization;
using Server.ServerCore.Handlers.Base;
using Server.ServerCore.Handlers.Registration;

namespace Server.ServerCore.Handlers
{
    public class HandlersFactory
    {
        public readonly Dictionary<string, Func<IFormCollection, HttpResponse, HttpRequest, IExecuteHandler>> HandlerFactory;
        
        public HandlersFactory()
        {
            HandlerFactory = new Dictionary<string, Func<IFormCollection, HttpResponse, HttpRequest, IExecuteHandler>>
            {
                {nameof(RegistrationHandler), (form, response, request) => new RegistrationHandler(form, response, request)},
                {nameof(AuthorizationHandler), (form, response, request) => new AuthorizationHandler(form, response, request)},
            };
        }
    }
}