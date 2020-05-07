using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Api.Search.Interfaces;
using Ecommerce.Api.Search.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Search.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchSevice _searchSevice;
        public SearchController(ISearchSevice searchSevice)
        {
            _searchSevice = searchSevice;
        }

        [HttpPost]
        public async Task<IActionResult> SearchAsync(SearchItem item)
        {
            var (IsSuccess, SearchResults) = await _searchSevice.SearchAsync(item.CustomerId);

            if (IsSuccess)
            {
                return Ok(SearchResults);
            }

            return NotFound();

        }
    }
}