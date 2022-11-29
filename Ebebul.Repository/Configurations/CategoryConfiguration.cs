using Ebebul.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//IEntityTypeConfiguration ile Context de yaptığımız işlemleri burada yapmamız daha uygun bir yaklaşımdır. Fluent Api yöntemiyle burada düzenleyebiliriz.

namespace Ebebul.Repository.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //PrimeryKey olduğunu belirtiyoruz.
            builder.HasKey(x => x.Id); 
            
            //Özellikler belirtiliyor.
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

            //Table ismini değiştirebiliyoruz.
            builder.ToTable("Categories");
        }
    }
}
