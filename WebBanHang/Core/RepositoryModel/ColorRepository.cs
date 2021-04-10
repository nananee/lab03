﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebBanHang.Models;

namespace WebBanHang.Core.RepositoryModel
{
    public class ColorRepository : RepositoryModel<Color>
    {
        public ColorRepository(DbContext dbContext) : base(dbContext)
        {
            
        }
    }
}