﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMP.BOL.Setting
{
    [Serializable()]
    public class StudentCategoryBOL
    {
        public int Id { get; set; }
        public  string Category { get; set; }
        public string Description { get; set; }

    }
}
