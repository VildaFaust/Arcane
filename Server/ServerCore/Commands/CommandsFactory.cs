using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Server.ServerCore.Commands.Base;

namespace Server.ServerCore.Commands
{
    public class CommandsFactory
    {
        public Dictionary<string, Func<IFormCollection, HttpResponse, HttpRequest, IExecuteCommand>> CommandFactory;
        private ServerContext _context;
        
        public CommandsFactory(ServerContext context)
        {
            _context = context;
            CommandFactory = new Dictionary<string, Func<IFormCollection, HttpResponse, HttpRequest, IExecuteCommand>>
            {
                
            };
        }
    }
}