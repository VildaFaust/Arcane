using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using Core.Controllers.Commands.Base;
using Core.Utilities;
using Utilities.Libs.fastJSON;

namespace Commands.Base
{
    public abstract class ExecuteCommand : IExecuteCommand
    {
        private readonly HttpClient _client = new HttpClient();
        protected GlobalEnvironmentModel Context;
        protected Dictionary<string, object> Recieve = new Dictionary<string, object>();
        public string NameCommand { get; }
        protected Dictionary<string, string> UserParams = new Dictionary<string, string>();

        protected ExecuteCommand(string nameCommand)
        {
            NameCommand = nameCommand;
            UserParams.Add("Command", nameCommand);
        }

        protected async void Send()
        {
            var stringUserParams = JSON.ToJSON(UserParams);
            HttpContent content = new StringContent(stringUserParams);
            var response = _client.PostAsync("http://25.57.84.220:8000/game_request",content);
            await response;
            if (response.Exception != null)
            { 
            Console.WriteLine(response.Exception);
            }
            
            if (response.IsCompleted)
            {
                Recieve = (Dictionary<string, object>) JSON.Parse(response.Result.Content.ToString());
            }
            CallBack();
        }

        public virtual void Execute(GlobalEnvironmentModel environment)
        {
            Context = environment;
            Console.WriteLine(NameCommand);
        }

        
        protected abstract void CallBack();
    }
}