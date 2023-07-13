using BackendAPI.Contracts;
using BackendAPI.Entities;
using BackendAPI.Helpers;
using BackendAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;

namespace BackendAPI.Reponsitory
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        //private DataContext _repoContext;
        public DataContext _DataContext { get; set; }

        public RepositoryBase(DataContext dataContext)
        {
            _DataContext = dataContext;
        }
        public IQueryable<T> FindAll()
        {
            return _DataContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _DataContext.Set<T>().Where(expression).AsNoTracking();
        }
        public IQueryable<T> GetId(Guid id)
        {
            return _DataContext.Set<T>().AsNoTracking();
        }
        public T GetById(Guid id)
        {
            return _DataContext.Set<T>().Find(id);
        }
       
        public void Create(T entity)
        {
            _DataContext.Set<T>().Add(entity);
        }
        public void CreateDH(DonDatHang entity)
        {
            _DataContext.Set<DonDatHang>().Add(entity);
        }
        public void Update(T entity)
        {
            _DataContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            _DataContext.Set<T>().Remove(entity);
        }
        public DataContext GetDb()
        {
            return _DataContext;

        }
        public List<ProductRequest> GetProductById(Guid id)
        {
            return _DataContext.Set<ProductRequest>().Where(p => p.IdCategory == id).ToList();
        }
        public List<HoadonbanRequest> GetIdHDB(Guid id)
        {
            return _DataContext.Set<HoadonbanRequest>().ToList();
        }
        
        public List<DonDatHang> LayDonHang(SearchRequest request)
        {
            var query = _DataContext.DonDatHangs.Include("Product").Include("Donhang");
            return query.ToList();
        }

        public List<HoadonbanRequest> SearchHDB(SearchRequest request)
        {
            var query = _DataContext.Hoadonbans.Include("KhachHang").Include("Products");
            return query.ToList();
        }
        public List<ProductRequest> SearchProduct(SearchRequest request)
        {
            var query = _DataContext.Products.Distinct()/*Include("NameProduct")*/;
            if (!request.FilterBy.IsNullOrEmpty())
            {
                request.FilterBy = request.FilterBy.ToUpper();
                query = query.Where(x => x.NameProduct.ToUpper().Contains(request.FilterBy)|| x.Describe.ToUpper().Contains(request.FilterBy));
                    
            }
            return query.ToList();
        }
        public List<CategoryRequest> SearchCategory(SearchRequest request)
        {
            var query = _DataContext.Categories.Distinct()/*Include("NameProduct")*/;
            if (!request.FilterBy.IsNullOrEmpty())
            {
                request.FilterBy = request.FilterBy.ToUpper();
                query = query.Where(x => x.NameCategory.ToUpper().Contains(request.FilterBy));
            }
            return query.ToList();
        }
        public void Save()
        {
            _DataContext.SaveChanges();
        }
       
    }

}
