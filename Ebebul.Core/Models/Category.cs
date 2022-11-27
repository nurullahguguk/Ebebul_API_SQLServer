using Ebebul.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebebul.Core.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        //Aşağıdaki tanımlama "Navigation Property" olarak geçmektedir. Categoryiden'dan User'a gidebilirim.
        //Bir Categorinin birden çok userı vardır.
        public ICollection<User> Users { get; set; }
    }
}
