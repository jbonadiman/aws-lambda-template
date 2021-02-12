using NHibernate;

namespace DefaultLambda.Database
{
    public interface INHibernateHelper
    {
        ISession OpenSession();
    }
}