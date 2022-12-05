using Ebebul.Core.Entity;
using Ebebul.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ebebul.Repository
{
    public class AppDbContext : DbContext
    {
        //Startupta veritabanı yolunu verebilmek için DbContextOptions oluşturuyoruz.
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Tüm Configration dosyalarını nasıl buluyor "ApplyConfigurationsFromAssembly" methodu ile "IEntityTypeConfiguration" miras alan Assemblyleri buluyor.
            //Assembly.GetExecutingAssembly() demek de çalıştığımız klasörde ara demektir. Configurationların yanında Seedlerde "IEntityTypeConfiguration"
            //miras aldığı için ekstra bir işleme gerek yoktur.

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //Aşağıda tek tek yazılabilir ancak configuration dosyasının çok fazla olabileceğini düşündüğümüzde üstteki metot ile tamamını alabiliyoruz.
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());

            base.OnModelCreating(modelBuilder);

        }

        public override int SaveChanges()
        {
            UpdateChangeTracker();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateChangeTracker();
            return base.SaveChangesAsync(cancellationToken);
        }
        
        public void UpdateChangeTracker()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                Entry(entityReference).Property(x => x.UpdateDate).IsModified = false;
                                entityReference.CreatDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                Entry(entityReference).Property(x => x.CreatDate).IsModified = false;
                                entityReference.UpdateDate = DateTime.Now;
                                break;
                            }
                    }
                }
            }
        }

    }
}
