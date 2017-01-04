using ServiceStack;

namespace WebApiModel
{
    [Route("/Authenticate", Verbs = "POST")]
    public class AuthenticationRequest : IReturn<AuthenticationResponse>
    {
        public string SystemId { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public AuthenticationType AuthenticationType { get; set; }
    }

    public enum AuthenticationType
    {
        Windows,
        Basic,
        Aspnet
    };
}
