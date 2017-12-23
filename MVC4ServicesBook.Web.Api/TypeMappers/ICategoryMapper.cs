﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC4ServicesBook.Web.Api.Models;

namespace MVC4ServicesBook.Web.Api.TypeMappers
{
    public interface ICategoryMapper
    {
        Category CreateCategory(Data.Model.Category modelCategory);
    }
}
