using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;

namespace JwStore.Core.Contexts.SharedContext.UseCases
{
    public abstract class Response
    {
        public string Message { get; set; } = string.Empty;
        public int Status { get; set; } = 400;
        public bool IsSuccess => Status is > 200 and <= 299;
        public IEnumerable<Notification>? Notifications{ get; set; }
        
    }
}