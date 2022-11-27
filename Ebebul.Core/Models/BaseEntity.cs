﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebebul.Core.Entity
{
    public abstract class BaseEntity
    {
        public int Id { get; set; } 
        public DateTime CreatDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
