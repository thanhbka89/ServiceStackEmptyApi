using ServiceStack;

namespace WebApplicationASP
{
    [Route("/Person", Verbs = "GET")]
    public class GetPeopleRequest { }

    [Route("/Person", Verbs = "POST")]
    [Route("/Person/PersonID", Verbs = "PUT")]
    public class PersonRequest
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }

    [Route("/Person/{PersonID}", Verbs = "GET, DELETE")]
    public class PersonIDRequest
    {
        public int PersonID { get; set; }
    }
}