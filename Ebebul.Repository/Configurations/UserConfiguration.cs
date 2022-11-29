using Ebebul.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebebul.Repository.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(100);
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.IdentityNum).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Gender).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Birthdate).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Birthplace).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Length).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Weight).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Location).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CategoryId).IsRequired().HasMaxLength(100);

            //Çoklu bire ilişki olduğu için HasForeignKey de bu ilişkinin kimde olduğu belirtilmelidir.
            builder.HasOne(x => x.Category).WithMany(x => x.Users).HasForeignKey(x => x.CategoryId);

            //Birebir ilişki olduğu için HasForeignKey de bu ilişkinin kimde olduğu belirtilmelidir.
            //builder.HasOne(x => x.User).WithOne(x => x.UserFeature).HasForeignKey<UserFeature>(x => x.UserId);

            //HasColumnType ile veritabanı tarafında hangi propery ile tutmak istediğimizi söylüyoruz. decimal (18,2) demek=> benim parasal değerim 18 karakter olacak ve virgülden sonra 2 karakter olabilir(virgülden önce 16 ve virgülden sonra 2).

            //EF Core bu ilişkiyi kuruyor ancak örnek olması açısından yazılmıştır.

            //public string Name { get; set; }
            //public string Surname { get; set; }
            //public string UserName { get; set; }
            //public string Email { get; set; }
            //public string IdentityNum { get; set; }
            //public int Gender { get; set; }
            //public DateTime Birthdate { get; set; }
            //public string Birthplace { get; set; }
            //public int Length { get; set; }
            //public int Weight { get; set; }
            //public string Location { get; set; }
            //public string Password { get; set; }
            //public int CategoryId { get; set; }
        }
    }
}
