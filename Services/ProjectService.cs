using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using myorange_pmproject.Data;
using myorange_pmproject.DTO;
using myorange_pmproject.Models;
using Microsoft.Extensions.Logging;

namespace myorange_pmproject.Service
{


    public class ProjectService
    {
        private readonly MyOrangePMPProjectContext _context;
        private readonly ILogger<ProjectService> _logger;
        public ProjectService(MyOrangePMPProjectContext context, ILogger<ProjectService> logger)
        {

            _context = context;
            _logger = logger;
        }

        public async Task<bool> Save(ProjectDTO p){

            var project      = new Project();
            p.Createtime     = DateTime.Now;
            p.Managerid      = 1 ;
            p.State          = 1 ;
            _context.Entry(project).CurrentValues.SetValues(p);
            _context.Project.Add(project);
            await _context.SaveChangesAsync();
            return  true;
        }

        public async Task<List<ProjectDTO>> GetList(String name)
        {
            var lst = await _context.Project.Select(
                x =>new ProjectDTO
                {
                    Id   = x.Id,
                    Name = x.Name,
                    Intro = x.Intro,
                    Createtime =x.Createtime,
                    Starttime = x.Starttime,
                    Endtime   = x.Endtime,
                    State  = x.State,
                    Managerid = x.Managerid

                }
                ).ToListAsync();
            this._logger.LogInformation("This is Test");
            return lst;


        }
        

    
    }
}