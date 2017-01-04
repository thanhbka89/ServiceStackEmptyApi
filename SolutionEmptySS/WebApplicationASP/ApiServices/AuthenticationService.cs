using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiModel;

namespace WebApplicationASP.ApiServices
{
    public class AuthenticationService : ServiceStack.Service
    {
        public object Post(AuthenticationRequest request)
        {
            if (request.AuthenticationType == AuthenticationType.Basic)
            {
                //validate the user name with the password stored in EGIS metadatabase
            }

            if (request.AuthenticationType == AuthenticationType.Windows)
            {
                //validate the user name with Active directory
            }

            if (request.AuthenticationType == AuthenticationType.Aspnet)
            {

            }

            return new AuthenticationResponse
            {
                Message = String.Format("Success!. Welcome {0}.", request.UserName)
            };
        }
    }
}