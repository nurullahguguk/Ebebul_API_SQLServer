using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebebul.Core.DTOs
{
    public class UserWithCategoryDto : UserDto
    {
        public CategoryDto Category { get; set; }   
    }
}
