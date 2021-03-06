﻿using DefaultLambda.DependencyInjection.ConfigurationService;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
#if (AddDependencyInjection == false)
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
#if (AddDependencyInjection)
            var connectionString = configurationService
                .GetConfiguration()["DB_CONN_STRING"]
#else
            var connectionString = Environment.GetEnvironmentVariable("DB_CONN_STRING");
#endif
            Configuration hbnConfiguration = Fluently.Configure()
                .Database(
#if (UsePostgres)
                    PostgreSQLConfiguration.PostgreSQL82
                        .ConnectionString(connectionString)
#else
                    SQLiteConfiguration.Standard // Add database here
                        .ConnectionString(connectionString)
#endif
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