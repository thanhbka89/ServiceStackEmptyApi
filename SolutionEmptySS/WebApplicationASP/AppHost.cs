using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;

namespace WebApplicationASP
{
    public class AppHost : AppHostHttpListenerBase
    {
        public AppHost() : base("WebApplicationASP ServiceStack Demo", typeof(AppHost).Assembly)
        {
        }

        public override void Configure(Funq.Container container)
        {
            container.Register<IDbConnectionFactory>
                (
                    new OrmLiteConnectionFactory
                        (Properties.Settings.Default.LocalConnectionString,
                        SqlServerOrmLiteDialectProvider.Instance)
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
        }
    }
}