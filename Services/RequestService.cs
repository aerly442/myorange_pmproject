using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using myorange_pmproject.Data;
using myorange_pmproject.DTO;
using myorange_pmproject.Models;
using Microsoft.Extensions.Logging;
using System.Linq.Dynamic.Core;
using myorange_pmproject.Services;
using System.Reflection.Metadata;
namespace myorange_pmproject.Service
{
    public class RequestService
    {
        private readonly MyOrangePMPProjectContext _context;
        private readonly ILogger<RequestService> _logger;
        private readonly CurrentUserService _currentUserService;
        public RequestService(MyOrangePMPProjectContext context, ILogger<RequestService> logger,
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
        public async Task<Project_request> Save(Project_requestDTO p)
        {

            var m = p.Id == 0 ? new Project_request() : await _context.ProjectRequest.FirstOrDefaultAsync(m => m.Id == p.Id); ;
            p.Createtime = DateTime.Now;
            p.Managerid = await _currentUserService.GetCurrentUserIdAsync();

            _context.Entry(m).CurrentValues.SetValues(p);

            if (p.Id == 0) { _context.ProjectRequest.Add(m); }

            await _context.SaveChangesAsync();
            return m;
        }

        public async Task<bool> Save(Project_requestDTO p, int projectId, List<String> lstFiles)
        {

            var q = await this.Save(p);

            int reuqestId = q.Id;

            var m = p.Id == 0 ? new Project_request_list() : await _context.ProjectRequestList.FirstOrDefaultAsync(m => m.Id == p.Id); 
            var plist = await _context.ProjectRequestList.FirstOrDefaultAsync(m => m.Projectid_project_requestid == reuqestId);
            if (plist != null && plist.Id > 0)
            {
                plist.Projectid = projectId;
            }
            else
            {

                plist                             = new Project_request_list();
                plist.Projectid                   = projectId;
                plist.Projectid_project_requestid = reuqestId;
                plist.Createtime = DateTime.Now;
                _context.ProjectRequestList.Add(plist);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public async Task<bool> Delete(Project_requestDTO p)
        {

            var m = await _context.ProjectRequest.FindAsync(p.Id);

            if (m != null)
            {
                _context.ProjectRequest.Remove(m);
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
        public async Task<Project_requestDTO> GetSinger(int id)
        {

            var query = this.GetModelQuery();
            var p = await query.Where(x => x.Id == id).FirstOrDefaultAsync();

            return p;
        }

        private IQueryable<Project_requestDTO> GetModelQuery()
        {

            var q = from d in _context.ProjectRequest
                    join list in _context.ProjectRequestList
                    on d.Id equals list.Projectid_project_requestid into docList
                    from list in docList.DefaultIfEmpty()
                    join proj in _context.Project on list.Projectid equals proj.Id into projGroup
                    from proj in projGroup.DefaultIfEmpty()
                    select new Project_requestDTO
                    {
                        Id = d.Id,
                        Title = d.Title,
                        Content = d.Content,
                        Createtime = d.Createtime,
                        Request_type = d.Request_type,

                        State = d.State,
                        Managerid = d.Managerid,
                        Finishtime = d.Finishtime,
                        Willfinishtime = d.Willfinishtime,
                        Starttime = d.Starttime,
                        ProjectId = proj.Id,
                        ProjectName = proj.Name

                    };
            return q;
            /*
                        return _context.ProjectRequest.Select(
                                 x => new Project_requestDTO
                                 {
                                     Id = x.Id,
                                     Title = x.Title,
                                     Content = x.Content,
                                     Createtime = x.Createtime,
                                     Request_type = x.Request_type,

                                     State = x.State,
                                     Managerid = x.Managerid,
                                     Finishtime = x.Finishtime,
                                     Willfinishtime = x.Willfinishtime,
                                     Starttime = x.Starttime

                                 }
                                 );

                        var q = from d in _context.ProjectDocument
                                join list in _context.ProjectDocumentList
                    on d.Id equals list.Project_documentid into docList
                                from list in docList.DefaultIfEmpty()
                                join proj in _context.Project on list.Projectid equals proj.Id into projGroup
                                from proj in projGroup.DefaultIfEmpty()
                                select new Project_documentDTO
                                {
                                    Id = d.Id,
                                    Title = d.Title,
                                    Content = d.Content,
                                    Createtime = d.Createtime,

                                    State = d.State,
                                    Managerid = d.Managerid,
                                    ProjectId = proj.Id,
                                    ProjectName = proj.Name

                                };
                        return q;
            */

        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="searchDTO">查询对象：字段名称和值</param>
        /// <param name="pageNumber">当前页码</param>
        /// <returns></returns>
        public async Task<SearchResultDTO<List<Project_requestDTO>>> GetList(SearchDTO searchDTO, int pageNumber)
        {
            IQueryable<Project_requestDTO> query = this.GetModelQuery();

            string where    = string.IsNullOrEmpty(searchDTO.SearchValue) ? "Id>0" : searchDTO.FieldName + ".contains(\"" + searchDTO.SearchValue + "\")";
            var q           = query.Where(where);
            int totalCount  = await q.CountAsync();
            int skip        = MyPage.GetSkip(pageNumber, MyPage.PageSize);
            var lst         = await q.OrderByDescending(x => x.Id).Skip(skip).Take(MyPage.PageSize).ToListAsync();
            var pageHtml    = MyPage.GetSplitPageHtml(totalCount, pageNumber, MyPage.PageSize);

            var searchResultDTO = new SearchResultDTO<List<Project_requestDTO>>(lst, pageHtml, totalCount);

            this._logger.LogInformation("This is Test");

            return searchResultDTO;


        }

        /// <summary>
        /// 根据名称获取数据
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<SearchResultDTO<List<Project_requestDTO>>> GetList(String name)
        {

            return await this.GetList(new SearchDTO() { FieldName = "name", SearchValue = name }, 1);

        }



    }
}

