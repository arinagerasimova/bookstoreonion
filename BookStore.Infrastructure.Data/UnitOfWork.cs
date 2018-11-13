using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using BookStore.Domain.Core;
using BookStore.Domain.Core.Model;
using BookStore.Domain.Interfaces;
using BookStore.Infrastructure.Business.Model;
using FluentNHibernate.Data;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;

namespace BookStore.Infrastructure.Data
{
    public class UnitOfWork  //IUnitOfWork // IDisposable// IUnitOfWork
    {
        //private static readonly ISessionFactory _sessionFactory;
        //private ITransaction _transaction;

        //public ISession Session { get; set; }

        //static UnitOfWork()
        //{
        //    //_sessionFactory = Fluently.Configure()
        //    //    .Database(MsSqlConfiguration.MsSql2008.ConnectionString(x => x.FromConnectionStringWithKey("StoreContext")))
        //    //    .Mappings(x => x.AutoMappings.Add(
        //    //        AutoMap.AssemblyOf<Genre>(new AutomappingConfiguration()).UseOverridesFromAssemblyOf<GenreItem>()))
        //    //    .ExposeConfiguration(config => new SchemaUpdate(config).Execute(false, true))
        //    //    .BuildSessionFactory();
        //    Configuration configuration = new Configuration();
        //    configuration.configure();
        //    ServiceRegistry serviceRegistry = new ServiceRegistryBuilder().applySettings(
        //        configuration.getProperties()).buildServiceRegistry();
        //    sessionFactory = configuration.buildSessionFactory(serviceRegistry)
        //}

        //public UnitOfWork()
        //{
        //    Session = _sessionFactory.OpenSession();
        //}

        //public void BeginTransaction()
        //{
        //    _transaction = Session.BeginTransaction();
        //}

        //public void Commit()
        //{
        //    try
        //    {
        //        if (_transaction != null && _transaction.IsActive)
        //            _transaction.Commit();
        //    }
        //    catch
        //    {
        //        if (_transaction != null && _transaction.IsActive)
        //            _transaction.Rollback();

        //        throw;
        //    }
        //    finally
        //    {
        //        Session.Dispose();
        //    }
        //}

        //public void Rollback()
        //{
        //    try
        //    {
        //        if (_transaction != null && _transaction.IsActive)
        //            _transaction.Rollback();
        //    }
        //    finally
        //    {
        //        Session.Dispose();
        //    }
        //}


    }
}
