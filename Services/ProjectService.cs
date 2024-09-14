using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using myorange_pmproject.Data;
using myorange_pmproject.DTO;
using myorange_pmproject.Models;

namespace myorange_pmproject.Service
{


    public class ProjectService
    {
        private readonly MyOrangePMPProjectContext _context;

        public ProjectService(MyOrangePMPProjectContext context)
        {

            _context = context;
        }

        public async Task<bool> Save(ProjectDTO p){

            var project      = new Project();
            p.Createtime     = DateTime.Now;
            p.Managerid      = "1" ;
            p.State          = "1" ;
            _context.Entry(project).CurrentValues.SetValues(p);
            _context.Project.Add(project);
            await _context.SaveChangesAsync();
            return  true;
        }
        

    
    }
}