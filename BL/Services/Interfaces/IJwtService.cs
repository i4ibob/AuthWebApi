﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BL.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(UserLogin account);
    }
}
