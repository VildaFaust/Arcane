using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Server.ServerCore.Handlers.Authorization;
using Server.ServerCore.Handlers.Base;
using Server.ServerCore.Handlers.Registration;
using Server.ServerCore.Handlers.World;
using Server.ServerCore.Handlers.World.CreateWorld;
using Server.ServerCore.Handlers.World.ExitWorld;
using Server.ServerCore.Handlers.World.JoinWorld;

namespace Server.ServerCore.Handlers
{
    public class HandlersFactory
    {
        public Dictionary<string, Func<IFormCollection, HttpResponse, HttpRequest, IExecuteHandler>> HandlerFactory;
        
        public HandlersFactory()
        {
            HandlerFactory = new Dictionary<string, Func<IFormCollection, HttpResponse, HttpRequest, IExecuteHandler>>
            {
                {nameof(RegistrationHandler), (form, response, request) => new RegistrationHandler(form, response, request)},
                {nameof(AuthorizationHandler), (form, response, request) => new AuthorizationHandler(form, response, request)},
                {nameof(CreateWorldHandler), (form, response, request) => new CreateWorldHandler(form, response, request)},
                {nameof(JoinWorldHandler), (form, response, request) => new JoinWorldHandler(form, response, request)},
                {nameof(ExitWorldHandler), (form, response, request) => new ExitWorldHandler(form, response, request)}
            };
        }
    }
}