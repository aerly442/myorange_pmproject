using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using myorange_pmproject.Data;
using myorange_pmproject.DTO;

namespace myorange_pmproject.Service
{


    public class UserService
    {
        private readonly MyOrangePMPProjectContext _context;

        public UserService(MyOrangePMPProjectContext context)
        {

            _context = context;
        }

        public static readonly string FrontUserCookieName = "FrontUser.Cookie.Check";

        public bool CheckExistEmail(int id,string email){

            var data = id<=0? _context.User.FirstOrDefault(m => m.Email == email):
            _context.User.FirstOrDefault(m => m.Id!=id && m.Email == email);
            return data!=null && data.Id>0;

        }
        public bool CheckExistUsername(int id,string userName){

            var data = id<=0? _context.User.FirstOrDefault(m => m.Username == userName):
            _context.User.FirstOrDefault(m => m.Id!=id && m.Username == userName);
            return data!=null && data.Id>0;

        }

        public bool CheckExistMobile(int id,string mobile){

            var data = id<=0? _context.User.FirstOrDefault(m => m.Mobile == mobile):
            _context.User.FirstOrDefault(m => m.Id!=id && m.Mobile == mobile);
            return data!=null && data.Id>0;

        }

    
    }
}