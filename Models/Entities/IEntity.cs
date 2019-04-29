﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public interface IEntity
    {
        long Id { get; set; }
        List<string> GetObjectList();
    }
}
