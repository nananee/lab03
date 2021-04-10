﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebBanHang.Models;

namespace WebBanHang.Core.RepositoryModel
{
    public class ProvinceRepository : RepositoryModel<Province>
    {
        public ProvinceRepository(DbContext dbContext)
            : base(dbContext)
        {
            
        }
    }
}