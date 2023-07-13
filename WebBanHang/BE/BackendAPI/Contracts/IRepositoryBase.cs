
using BackendAPI.Entities;
using BackendAPI.Helpers;
using BackendAPI.Models;
using System.Linq.Expressions;

namespace BackendAPI.Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        T GetById(Guid id);
        List<ProductRequest> GetProductById(Guid id);
        List<HoadonbanRequest> GetIdHDB(Guid id);
        List<ProductRequest> SearchProduct(SearchRequest request);
        List<CategoryRequest> SearchCategory(SearchRequest request);
        List<DonDatHang> LayDonHang(SearchRequest request);
        List<HoadonbanRequest> SearchHDB(SearchRequest request);
        IQueryable<T> GetId(Guid id);
        void Create(T entity);
        void CreateDH(DonDatHang entity);
        void Update(T entity);
        void Delete(T entity);
        //void FindAllSelect(T entity);
        DataContext GetDb();
        void Save();
    }
}
