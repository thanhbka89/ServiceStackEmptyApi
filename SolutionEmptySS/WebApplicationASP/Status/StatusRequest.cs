using ServiceStack;
using System;

namespace WebApplicationASP.Status
{
    [Route("/status")]
    [Route("/status/{Date}")]
    [Authenticate]
    [RequiredRole("User")]
    [RequiredPermission("ViewCurrentStatus")]
    public class StatusRequest : IReturn<StatusResponse>
    {
        public DateTime DateStatus { get; set; }
    }

    public class StatusResponse
    {
        public int Total { get; set; }
        public int Goal { get; set; }
        public string Message { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }
}