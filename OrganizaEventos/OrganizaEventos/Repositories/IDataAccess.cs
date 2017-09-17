using System.Collections.Generic;

namespace OrganizaEventosApi.Repositories {
    public interface IDataAccess<TEntity, T> where TEntity : class {
        IEnumerable<TEntity> GetItens();
        TEntity GetItem(T id);
        int Add(TEntity item);
    }
}