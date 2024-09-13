using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using myorange_pmproject.Data;
using myorange_pmproject.DTO;

namespace myorange_pmproject.Service
{


    public class ShowInfoService
    {
        private readonly MyOrangePMPProjectContext _context;

        public ShowInfoService(MyOrangePMPProjectContext context)
        {

            _context = context;
        }



        public static string Show(bool blnSuccess,string errorInfo)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            string  style = blnSuccess?"success":"danger";
            sb.AppendFormat("<div class=\"alert alert-{0} \" id=\"divHidden\" >",style);
            sb.Append(errorInfo);
            sb.Append("</div>");
            return sb.ToString();
            
        }

    
    }
}