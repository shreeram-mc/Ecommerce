﻿using Ecommerce.Api.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Search.Interfaces
{
   public interface IOrderService
    {
       Task<(bool IsSuccess, IEnumerable<Order> orders, string ErrorMessage )> GetOrderAsync(int customerId);
    }
}
