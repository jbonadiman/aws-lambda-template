using DefaultLambda.DependencyInjection.ConfigurationService;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
#if (!AddDependencyInjection)
using System;
#endif

namespace DefaultLambda.Database
{
    public class NHibernateHelper
#if (AddDependencyInjection)
        : INHibernateHelper
#endif
    {
        private readonly ISessionFactory _hbnSessionFactory;

        public NHibernateHelper(
#if (AddDependencyInjection)
            IConfigurationService configurationService
#endif
            )
        {
            Configuration hbnConfiguration = Fluently.Configure()
                .Database(
                    SQLiteConfiguration.Standard // Add database here
                        .ConnectionString(
#if (AddDependencyInjection)
                            configurationService
                                .GetConfiguration()["DB_HOST"]
#else
                            Environment.GetEnvironmentVariable("DB_HOST")
#endif
                        ).ShowSql())
                .Mappings(m =>
                    {
                        // Add mappings here
                    }
                )
                .ExposeConfiguration(cfg =>
                    new SchemaUpdate(cfg).ExecuteAsync(true, true))
                .BuildConfiguration();

            this._hbnSessionFactory = hbnConfiguration.BuildSessionFactory();
        }

        public ISession OpenSession()
        {
            return this._hbnSessionFactory.OpenSession();
        }
    }
}