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
        public async Task<Project_document> Save(Project_documentDTO p)
        {

            var m = p.Id == 0 ? new Project_document() : await _context.ProjectDocument.FirstOrDefaultAsync(m => m.Id == p.Id); ;
            p.Createtime = DateTime.Now;
            p.Managerid  = await _currentUserService.GetCurrentUserIdAsync();

            _context.Entry(m).CurrentValues.SetValues(p);

            if (p.Id == 0) { _context.ProjectDocument.Add(m); }

            await _context.SaveChangesAsync();
            return m;
        }

        public async Task<bool> Save(Project_documentDTO p,int projectId,List<String> lstFiles)
        {
            //01 保存文档信息
            var d = await this.Save(p);

            int documentId = d.Id ; 

            //02 保存和项目的对应信息
            var plist =  await _context.ProjectDocumentList.FirstOrDefaultAsync(m => m.Project_documentid == documentId) ;
            if (plist!=null && plist.Id>0){
                plist.Projectid = projectId;
            }
            else{

                plist                    = new Project_project_document_list();
                plist.Projectid          = projectId;
                plist.Project_documentid = documentId;
                plist.Createtime         = DateTime.Now.ToString();
                _context.ProjectDocumentList.Add(plist);
            }

            await _context.SaveChangesAsync();

            //03 保存附件
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

            var query  = this.GetModelQuery();
            var p      = await query.Where(x => x.Id == id).FirstOrDefaultAsync();
            //if  (p!=null ){
            //    p.Projects = await _context.Project.Select(x=>new ProjectDTO{
            //        Id =x.Id,
            //        Name = x.Name
            //    }).ToListAsync();
            //}

            return p;
        }


        //private IQueryable<Project_documentDTO> GetSingerModelQuery()
        //{

    
        //    return from   d in  _context.ProjectDocument
        //        select  new Project_documentDTO
        //                    {
        //                        Id = d.Id,
        //                        Title = d.Title,
        //                        Content = d.Content,
        //                        Createtime = d.Createtime,                         

        //                        State = d.State,
        //                        Managerid = d.Managerid
                            

        //            };

        //}


        private IQueryable<Project_documentDTO> GetModelQuery()
        {

            var q = from d in _context.ProjectDocument join list in _context.ProjectDocumentList
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

            //
            /*
             return from plist in _context.ProjectDocumentList 
                  join p in _context.Project on plist.Projectid equals p.Id
                  join d in _context.ProjectDocument  on plist.Project_documentid equals d.Id
                 select  new Project_documentDTO
                             {
                                 Id = d.Id,
                                 Title = d.Title,
                                 Content = d.Content,
                                 Createtime = d.Createtime,                         

                                 State = d.State,
                                 Managerid = d.Managerid,
                                 ProjectId = p.Id,
                                 ProjectName = p.Name

                     };
              */

            /*

                    var leftJoinResult = from doc in documents  
                             join list in documentLists  
                                 on doc.Id equals list.ProjectDocumentId into docLists  
                             from list in docLists.DefaultIfEmpty() // 左外连接  
                             join proj in projects  
                                 on list?.ProjectId equals proj?.Id into projGroup // 注意这里使用了可空传播  
                             from proj in projGroup.DefaultIfEmpty() // 再次左外连接  
                             select new  
                             {  
                                 DocumentTitle = doc.Title,  
                                 DocumentListId = list?.Id,  
                                 ProjectId = list?.ProjectId,  
                                 ProjectName = proj?.Name  
                             };  
                */




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

