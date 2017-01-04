using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;
using ServiceStack.Auth;
using ServiceStack.Caching;
using System.Collections.Generic;
using ServiceStack.Configuration;

namespace WebApplicationASP
{
    public class AppHost : AppHostHttpListenerBase
    {
        public AppHost() : base("WebApplicationASP ServiceStack Demo", typeof(AppHost).Assembly)
        {
        }

        public override void Configure(Funq.Container container)
        {            
            container.Register<IDbConnectionFactory>(
                    new OrmLiteConnectionFactory(
                            Properties.Settings.Default.LocalConnectionString,
                            SqlServerOrmLiteDialectProvider.Instance
                        )
                );
            // Below we refer to the connection factory that we just registered
            // with the container and use it to create our table(s).
            using (var db = container.Resolve<IDbConnectionFactory>().Open())
            {
                // We’re just creating a single table, but you could add
                // as many as you need.  Also note the “overwrite: false” parameter,
                // this will only create the table if it doesn’t already exist.
                db.CreateTable<Person>(overwrite: false);
            }

            //config basic authen
            Plugins.Add(new AuthFeature(
                    () => new AuthUserSession(), 
                    new IAuthProvider[] { new BasicAuthProvider() }
                ));
            container.Register<ICacheClient>(new MemoryCacheClient());
            var userStore = new InMemoryAuthRepository();
            container.Register<IUserAuthRepository>(userStore);
            string hash;
            string salt;
            string pass = "pass123";
            new SaltedHash().GetHashAndSaltString(pass, out hash, out salt);
            userStore.CreateUserAuth(
                    new UserAuth
                    {
                        Id = 1,
                        DisplayName = "ThanhNguyen",
                        Email = "thanhbka@gmail.com",
                        UserName = "thanhbka",
                        FirstName = "Thanh",
                        LastName = "Nguyen",
                        PasswordHash = hash,
                        Salt = salt,
                        //Roles = new List<string> { "User" },
                        Roles = new List<string> { RoleNames.Admin },
                        Permissions = new List<string> { "ViewCurrentStatus" }
                    },
                    pass
                );

            //plugin Registration
            Plugins.Add(new RegistrationFeature());
        }
    }
}