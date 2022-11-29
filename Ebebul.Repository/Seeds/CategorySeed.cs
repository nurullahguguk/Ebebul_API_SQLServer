using Ebebul.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebebul.Repository.Seeds
{
    //Veritabanına Category veya Product gönderdiğimizde Id'yi veritabanı tanımlar.
    //Ancak Seed data ile uygulama ayağa kalktığında veya migration esnasında default data göndermek istiyorsak Id'yi kendimiz vermemiz gerekmektedir.
    //Seed Data veritabanında ilgili tablolar oluşurken default dataların atılmasıdır.
    //2 farklı yerde gerçekleştirilebilir. 1-Migration yaparken ilgili tablolar oluştuğu esnada veya 2-Migration yapılır tablolar oluşur, uygulama ayağa kalktığında
    //data atabiliriz. (1.Yöntem uygulaması aşağıdadır.)
    internal class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = 1, Name="Manager" },
                new Category { Id = 2, Name = "Midwife" },
                new Category { Id = 3, Name = "User" }
                );
        }
    }
}

