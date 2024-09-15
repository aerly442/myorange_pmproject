using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using myorange_pmproject.Data;
using myorange_pmproject.DTO;
using myorange_pmproject.Models;
using Microsoft.Extensions.Logging;
using System.Linq.Dynamic.Core;
using myorange_pmproject.Service;
using System.Reflection.Metadata;

namespace myorange_pmproject.Services
{
    public class ParentService<T> where T : class
    {
        private readonly MyOrangePMPProjectContext _context;
        //private readonly ILogger<ProjectService> _logger;
        //private readonly CurrentUserService _currentUserService;
        public ParentService(MyOrangePMPProjectContext context)
        {

            _context = context;
           // _logger = logger;
           //_currentUserService = currentUserService;
            
        }

        

        /// <summary>
        /// 保存数据，如果id为0则新增，不为0则更新
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public async Task<bool> Save(ProjectDTO p)
        {
            var project = _context.GetQueryable<T>().ToList();
            return true;
        }
    }
}
