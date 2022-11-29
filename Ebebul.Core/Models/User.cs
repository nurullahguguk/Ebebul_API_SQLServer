using Ebebul.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebebul.Core.Models
{
    public class User : BaseEntity
    {
        //Constructor tetiklendiğinde name gelmez ise hata fırlatması için aşağıdaki fonksiyon yazılabilir.Name alanının null gelmemesi için oluşturulmuştur.
        //public Product(string name)
        //{
        //    Name = name ?? throw new ArgumentNullException(nameof(name));
        //}

        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string IdentityNum { get; set; }
        public int Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public string Birthplace { get; set; }
        public int Length { get; set; }
        public int Weight { get; set; }
        public string Location { get; set; }
        public string Password { get; set; }
        public int CategoryId { get; set; }

        //[ForeignKey("CategoryId")] EF Core direkt görüyor eğer görmeseydi Attribute tanımlayacaktık.
        //Bir tane categorysi olduğunu belli ederiz.
        public Category Category { get; set; }

    }
}
