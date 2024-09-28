using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using myorange_pmproject.Data;
using myorange_pmproject.DTO;
using myorange_pmproject.Models;
using Microsoft.Extensions.Logging;
using System.Linq.Dynamic.Core;
using myorange_pmproject.Service;

namespace myorange_pmproject.Service
{
    public class ProjectFileService
    {


        private readonly MyOrangePMPProjectContext _context;
        private readonly ILogger<ProjectFileService> _logger;
        private readonly CurrentUserService _currentUserService;
        public ProjectFileService(MyOrangePMPProjectContext context, ILogger<ProjectFileService> logger,
            CurrentUserService currentUserService)
        {

            _context = context;
            _logger = logger;
            _currentUserService = currentUserService;
        }

        public async Task<bool> Save(List<FileDTO> lstFile, 
            int sourceId, FileSource fileSource)
        {

            if (lstFile!=null && lstFile.Count > 0)
            {
                //001 先删除记录
                /*  先不删除吧
                var files = await _context.ProjectFile.Where(x => x.SourceId == sourceId && x.SourceType == ((int)fileSource).ToString()).ToListAsync();

                if (files != null)
                {
                    _context.ProjectFile.RemoveRange(files);
                    await _context.SaveChangesAsync();
                    //return true;
                }
                */

                //002 再保存
                foreach(var fileDTO in lstFile)
                {

                    await this.Save(

                              new Project_fileDTO()
                              {
                                  Id = 0,
                                  SourceType = ((int)fileSource).ToString(),
                                  Filename = fileDTO.Filename,
                                  FileUrl = fileDTO.FileUrl,
                                  SourceId = sourceId
                              }

                             );

                }

            }

            return true ;


        }
        /// <summary>
        /// 保存数据，如果id为0则新增，不为0则更新
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public async Task<bool> Save(Project_fileDTO p)
        {

            var project = p.Id == 0 ? new Project_file() : await _context.ProjectFile.FirstOrDefaultAsync(m => m.Id == p.Id); ;
            p.Createtime = DateTime.Now;
            //p.Managerid = await _currentUserService.GetCurrentUserIdAsync();
            _context.Entry(project).CurrentValues.SetValues(p);

            if (p.Id == 0) { _context.ProjectFile.Add(project); }

            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public async Task<bool> Delete(Project_fileDTO p)
        {

            var project = await _context.ProjectFile.FindAsync(p.Id);

            if (project != null)
            {
                _context.ProjectFile.Remove(project);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;

        }

        public async Task<List<Project_fileDTO>> GetList()
        {

            var query = this.GetProjectQuery();
            var p = await query.ToListAsync<Project_fileDTO>();

            return p;
        }

        /// <summary>
        /// 获取单个对象
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public async Task<Project_fileDTO> GetSinger(int mId)
        {

            var query = this.GetProjectQuery();
            var p = await query.Where(x => x.Id == mId).FirstOrDefaultAsync();

            return p;
        }

        private IQueryable<Project_fileDTO> GetProjectQuery()
        {

            return _context.ProjectFile.Select(
                     x => new Project_fileDTO
                     {
                         Id         = x.Id,              
                         Createtime = x.Createtime,                      
                         State      = x.State,
                         Filename   = x.Filename,
                         FileUrl    = x.FileUrl
                       

                     }
                     );


        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="searchDTO">查询对象：字段名称和值</param>
        /// <param name="pageNumber">当前页码</param>
        /// <returns></returns>
        public async Task<SearchResultDTO<List<Project_fileDTO>>> GetList(SearchDTO searchDTO, int pageNumber)
        {
            IQueryable<Project_fileDTO> query = this.GetProjectQuery();

            string where = string.IsNullOrEmpty(searchDTO.SearchValue) ? "Id>0" : searchDTO.FieldName + ".contains(\"" + searchDTO.SearchValue + "\")";
            var q = query.Where(where);
            int totalCount = await q.CountAsync();
            int skip = MyPage.GetSkip(pageNumber, MyPage.PageSize);
            var lst = await q.OrderByDescending(x => x.Id).Skip(skip).Take(MyPage.PageSize).ToListAsync();
            var pageHtml = MyPage.GetSplitPageHtml(totalCount, pageNumber, MyPage.PageSize);

            var searchResultDTO = new SearchResultDTO<List<Project_fileDTO>>(lst, pageHtml, totalCount);

            this._logger.LogInformation("This is Test");

            return searchResultDTO;


        }

        /// <summary>
        /// 根据名称获取数据
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<SearchResultDTO<List<Project_fileDTO>>> GetList(String name)
        {

            return await this.GetList(new SearchDTO() { FieldName = "name", SearchValue = name }, 1);

        }



    }
}
