﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ebebul.Core.Services
{
    public interface IService<T> where T : class
    {
        //IGenericRepository methotları kopyaladık ancak proje ilerlediğinde productService veya categoryService oluşturulduğunda dönüş tipleri farklı olacağı için ayırmak gereklidir. Repositoryler entity yani databasede tablosu bulunan classları geriye dönerken serviceler ise client tarafında çalıştığı için geriye Dto nesneleri dönerler. En büyük farklardan biri budur.

        Task<T> GetByIdAsync(int id);
        //GetAll asenkron yapıp tüm datayı çekmesi için Expression ifadesini kaldırdık.
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        //AddAsync ve AddRangeAsync methodları servis tarafında çalıştığı database'e veri ekleyecek. Bu sebeple eklenen verilerin id'sini görebilmek adına geriye değer döndürüyoruz.

        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        //=>EF Core da Update ve Delete için asenkron olan yapısı yoktur.Entity'i zaten EF Core takip ediyor, Update metoduna geldiğinde State'ini Modify yapıyor. Yani uzun süren bir işlem olmadığı için asenkronu yoktur.

        //Update ve Remove u niye asenkron yaptık veritabanına değişikliklerin yansıması için SaveChangeAsync kullanacağımız için asenkron tanımladık.

        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entities);

    }
}
