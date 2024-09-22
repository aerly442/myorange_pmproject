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


    public class ProjectService
    {
        private readonly MyOrangePMPProjectContext _context;
        private readonly ILogger<ProjectService> _logger;
        private readonly CurrentUserService _currentUserService;
        public ProjectService(MyOrangePMPProjectContext context, ILogger<ProjectService> logger,
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
        public async Task<bool> Save(ProjectDTO p){

            var project      = p.Id == 0? new Project(): await _context.Project.FirstOrDefaultAsync(m => m.Id == p.Id); ;
            p.Createtime     = DateTime.Now;
            p.Managerid      = await _currentUserService.GetCurrentUserIdAsync();

            _context.Entry(project).CurrentValues.SetValues(p);

            if (p.Id == 0) {  _context.Project.Add(project);}

            await _context.SaveChangesAsync();
            return  true;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public async Task<bool> Delete(ProjectDTO p)
        {

            var project = await _context.Project.FindAsync(p.Id);

            if (project != null)
            {
                _context.Project.Remove(project);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;

        }

        public async Task<List<ProjectDTO>> GetList()
        {

            var query = this.GetProjectQuery();
            var p = await query.ToListAsync<ProjectDTO>();

            return p;
        }

        /// <summary>
        /// 获取单个对象
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public async Task<ProjectDTO> GetSinger(int projectId)
        {

            var query = this.GetProjectQuery();
            var p     = await query.Where(x=>x.Id==projectId).FirstOrDefaultAsync();

            return p;
        }

        private IQueryable<ProjectDTO> GetProjectQuery()
        {
             
           return _context.Project.Select(
                    x => new ProjectDTO
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Intro = x.Intro,
                        Createtime = x.Createtime,
                        Starttime = x.Starttime,
                        Endtime = x.Endtime,
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
        public async Task<SearchResultDTO<List<ProjectDTO>>> GetList(SearchDTO searchDTO,int pageNumber)
        {
            IQueryable<ProjectDTO> query = this.GetProjectQuery();

            string where    = string.IsNullOrEmpty(searchDTO.SearchValue) ? "Id>0" : searchDTO.FieldName + ".contains(\"" + searchDTO.SearchValue + "\")";
            var q           = query.Where(where);
            int totalCount  = await q.CountAsync();
            int skip        = MyPage.GetSkip(pageNumber, MyPage.PageSize);
            var lst         = await q.OrderByDescending(x => x.Id).Skip(skip).Take(MyPage.PageSize).ToListAsync();
            var pageHtml    = MyPage.GetSplitPageHtml(totalCount, pageNumber, MyPage.PageSize);

            var searchResultDTO = new SearchResultDTO<List<ProjectDTO>>(lst, pageHtml, totalCount);

            this._logger.LogInformation("This is Test");

            return searchResultDTO;

 
        }

        /// <summary>
        /// 根据名称获取数据
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<SearchResultDTO<List<ProjectDTO>>> GetList(String name)
        {

            return await this.GetList(new SearchDTO(){ FieldName = "name" ,SearchValue=name},1);

        }
        

    
    }
}