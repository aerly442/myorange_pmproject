using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using myorange_pmproject.Data;
using myorange_pmproject.DTO;
using myorange_pmproject.Models;
using Microsoft.Extensions.Logging;
using System.Linq.Dynamic.Core;
using myorange_pmproject.Services;

namespace myorange_pmproject.Service
{
    public class DocumentService
    {
        private readonly MyOrangePMPProjectContext _context;
        private readonly ILogger<DocumentService> _logger;
        private readonly CurrentUserService _currentUserService;
        public DocumentService(MyOrangePMPProjectContext context, ILogger<DocumentService> logger,
            CurrentUserService currentUserService)
        {

            _context = context;
            _logger = logger;
            _currentUserService = currentUserService;
        }

        //public async Task<bool> Save123(ProjectDTO p)
        //{

        //    ParentService<Project> p1 = new ParentService<Project>(_context);
        //    await p1.Save(p);
        //    return true;
        //}

        /// <summary>
        /// 保存数据，如果id为0则新增，不为0则更新
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public async Task<bool> Save(Project_documentDTO p)
        {

            var m = p.Id == 0 ? new Project_document() : await _context.ProjectDocument.FirstOrDefaultAsync(m => m.Id == p.Id); ;
            p.Createtime = DateTime.Now;
            p.Managerid = await _currentUserService.GetCurrentUserIdAsync();

            _context.Entry(m).CurrentValues.SetValues(p);

            if (p.Id == 0) { _context.ProjectDocument.Add(m); }

            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public async Task<bool> Delete(Project_documentDTO p)
        {

            var m = await _context.ProjectDocument.FindAsync(p.Id);

            if (m != null)
            {
                _context.ProjectDocument.Remove(m);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;

        }

        /// <summary>
        /// 获取单个对象
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public async Task<Project_documentDTO> GetSinger(int id)
        {

            var query = this.GetModelQuery();
            var p = await query.Where(x => x.Id == id).FirstOrDefaultAsync();

            return p;
        }

        private IQueryable<Project_documentDTO> GetModelQuery()
        {

            return _context.ProjectDocument.Select(
                     x => new Project_documentDTO
                     {
                         Id = x.Id,
                         Title = x.Title,
                         Content = x.Content,
                         Createtime = x.Createtime,
                     

                         State = x.State,
                         Managerid = x.Managerid

                     }
                     );


        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="searchDTO">查询对象：字段名称和值</param>
        /// <param name="pageNumber">当前页码</param>
        /// <returns></returns>
        public async Task<SearchResultDTO<List<Project_documentDTO>>> GetList(SearchDTO searchDTO, int pageNumber)
        {
            IQueryable<Project_documentDTO> query = this.GetModelQuery();

            string where    = string.IsNullOrEmpty(searchDTO.SearchValue) ? "Id>0" : searchDTO.FieldName + ".contains(\"" + searchDTO.SearchValue + "\")";
            var q           = query.Where(where);
            int totalCount  = await q.CountAsync();
            int skip        = MyPage.GetSkip(pageNumber, MyPage.PageSize);
            var lst         = await q.OrderByDescending(x => x.Id).Skip(skip).Take(MyPage.PageSize).ToListAsync();
            var pageHtml    = MyPage.GetSplitPageHtml(totalCount, pageNumber, MyPage.PageSize);

            var searchResultDTO = new SearchResultDTO<List<Project_documentDTO>>(lst, pageHtml, totalCount);

            this._logger.LogInformation("This is Test");

            return searchResultDTO;


        }

        /// <summary>
        /// 根据名称获取数据
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<SearchResultDTO<List<Project_documentDTO>>> GetList(String name)
        {

            return await this.GetList(new SearchDTO() { FieldName = "name", SearchValue = name }, 1);

        }



    }
}

