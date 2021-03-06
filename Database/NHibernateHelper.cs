using DefaultLambda.DependencyInjection.ConfigurationService;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace DefaultLambda.Database
{
    public class NHibernateHelper
        #if (AddDependencyInjection)
        : INHibernateHelper
        #endif
    {
        private readonly ISessionFactory _hbnSessionFactory;

        public NHibernateHelper(IConfigurationService configurationService)
        {
            Configuration hbnConfiguration = Fluently.Configure()
                .Database(
                    SQLiteConfiguration.Standard // Add database here
                        .ConnectionString(
                            configurationService
                                .GetConfiguration()["DB_HOST"])
                        .ShowSql())
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