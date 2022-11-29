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
    internal class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = 1,
                    CategoryId = 1,
                    Name = "Nurullah",
                    Surname = "Guguk",
                    UserName = "nurullahggk",
                    Email = "nurullahguguk@gmail.com",
                    IdentityNum = "40282523972",
                    Gender = 2,
                    Birthdate = DateTime.Now,
                    Birthplace = "Ümraniye",
                    Length = 180,
                    Weight = 102,
                    Location = "Beykoz",
                    Password = "1234",
                    CreatDate = DateTime.Now,
                },
                new User
                {
                    Id = 2,
                    CategoryId = 2,
                    Name = "Beyza",
                    Surname = "Yıldırım",
                    UserName = "beyzayldrm",
                    Email = "beyzayldrm@gmail.com",
                    IdentityNum = "10325523928",
                    Gender = 1,
                    Birthdate = DateTime.Now,
                    Birthplace = "Çekmeköy",
                    Length = 163,
                    Weight = 65,
                    Location = "Pendik",
                    Password = "1234",
                    CreatDate = DateTime.Now,
                },
                new User
                {
                    Id = 3,
                    CategoryId = 3,
                    Name = "Sena",
                    Surname = "Can",
                    UserName = "sencan",
                    Email = "sencan@gmail.com",
                    IdentityNum = "10586954732",
                    Gender = 1,
                    Birthdate = DateTime.Now,
                    Birthplace = "Bursa",
                    Length = 155,
                    Weight = 65,
                    Location = "Maltepe",
                    Password = "1234",
                    CreatDate = DateTime.Now,
                }
            );
        }
    }
}
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