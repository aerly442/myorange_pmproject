using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using myorange_pmproject.Data;
using myorange_pmproject.DTO;
using System.Text.RegularExpressions;  

namespace myorange_pmproject.Service
{


    public class NewsService
    {
        private readonly MyOrangePMPProjectContext _context;

        public NewsService(MyOrangePMPProjectContext context)
        {

            _context = context;
        }

     
                /// <summary>
        /// 返回用户类型
        /// </summary>
        /// <returns></returns>
        public async Task<List<SelectListItem>> GetListMenu()
        {
            var lst = await _context.Menu.Where(x => x.Parentid==0).Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToListAsync();

            lst.Insert(0,
                 new SelectListItem(){
                     Text = " ",
                     Value = "0"
                 }

            );

            return lst;



        }

        /// <summary>
        /// 返回用户类型
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> GetNewsState()
        {
            return new List<SelectListItem>
            {

                 new SelectListItem("是","1"),
                 new SelectListItem("否","0")
            };

        }

        /// <summary>
        /// 收费模式
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> GetNewsChargeType()
        {
            return new List<SelectListItem>
            {

                 new SelectListItem("资源","1"),
                 new SelectListItem("内容","0")
            };

        }

                /// <summary>
        /// 返回用户类型
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> GetSex()
        {
            return new List<SelectListItem>
            {

                 new SelectListItem("男","1"),
                 new SelectListItem("女","0")
            };

        }
        private List<String> GetDataBaseTables(){

            List<String> lst = new List<String>();
            var con = this._context.Database.GetDbConnection();
            if (con.State != System.Data.ConnectionState.Open){
                con.Open();
            }
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT name FROM sqlite_master WHERE type='table'"  ;  //"show tables;";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lst.Add(reader.GetString(0));
                        //Console.WriteLine(reader.GetString(1) + " " + reader.GetDouble(3));
                    }

                }
            }

            return lst;

        }

    public List<TableDescDTO> GetTableInfo(string tableName){

            List<TableDescDTO> lst = new List<TableDescDTO>();
            var con = this._context.Database.GetDbConnection();
            if (con.State != System.Data.ConnectionState.Open){
                con.Open();
            }
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "PRAGMA table_info('"+tableName+"')";  //"desc "+tableName+";";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var d   = new TableDescDTO();
                        /*
                        d.Field         = reader.IsDBNull(0)==false?reader.GetString(0):"";
                        d.Type          = reader.IsDBNull(1)==false?reader.GetString(1):"varchar";                    
                        d.NullValue     = reader.IsDBNull(2)==false?reader.GetString(2):"YES";
                        */

                        d.Field         = reader.IsDBNull(1)==false?reader.GetString(1):"";
                        d.Type          = reader.IsDBNull(2)==false?reader.GetString(2):"varchar";                    
                        d.NullValue     = reader.IsDBNull(3)==false?reader.GetString(3):"YES";
                    
                        lst.Add(d);
                       
                    }

                }
            }

            return lst;

        }
        public  List<SelectListItem> GetTable()
        {

            List<String> lst = this.GetDataBaseTables();

            var lstItems =  new List<SelectListItem>();
            foreach(var t in lst){
                lstItems.Add(

                     new SelectListItem(t,t)

                );
            }
            /*
            {

                 new SelectListItem("User","User"),
                 new SelectListItem("Manager","Manager")
            };
            */

            return lstItems;

        }

        public static string ClearHtml(string content){

             if (string.IsNullOrEmpty(content) ==false){

                content            = content.Replace("#","");
                content            = content.Replace("&","");
                content            = content.Replace("--","");
                string pattern     = "<[^>]+?>"; // 此正则表达式匹配任何被尖括号包围的字符，并且尖括号内的字符不包含尖括号。  
                string replacement = ""; // 将所有匹配的HTML标签替换为空字符串。  
  
                content     = Regex.Replace(content, pattern, replacement); 

             }

             return content ;


        }
    }
}
