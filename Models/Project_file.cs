using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace myorange_pmproject.Models
{

    [Table("Project_file")]
    public class Project_file
     {
            public int Id { get; set; } // SQLite中的INTEGER PRIMARY KEY AUTOINCREMENT  
            public string Filename { get; set; } // SQLite中的TEXT NOT NULL  
            public string FileUrl { get; set; } // SQLite中的TEXT NOT NULL  
            public int? SourceId { get; set; } // SQLite中的INTEGER，可空  
            public string SourceType { get; set; } // SQLite中的TEXT，可空  
            public DateTime Createtime { get; set; } // SQLite中的TIMESTAMP DEFAULT CURRENT_TIMESTAMP，在C#中通常使用DateTime  
            public int State { get; set; } // SQLite中的TEXT CHECK(state IN ('active', 'inactive', 'deleted')) NOT NULL  

          // 可选的构造函数，用于初始化CreateTime  
         
       }
}
