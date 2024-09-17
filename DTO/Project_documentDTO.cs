 
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace myorange_pmproject.DTO
{
    public class Project_documentDTO
    {
        private int _Id = 0;
        [Display(Name = "Id")]
        public int Id
        {
            get { return this._Id; }
            set { this._Id = value; }
        }
        private string _Title = "";
        [Display(Name = "Title")]
        [Required(ErrorMessage = "请输入标题")]
        [StringLength(100, ErrorMessage = "标题长度不能超过100个字符")]
        public string Title
        {
            get { return this._Title; }
            set { this._Title = value; }
        }
        private string _Content = "";
        [Display(Name = "Content")]
        [Required(ErrorMessage = "请输入内容")]
        public string Content
        {
            get { return this._Content; }
            set { this._Content = value; }
        }
        private DateTime _Createtime = DateTime.Now;
        [Display(Name = "Createtime")]
        public DateTime Createtime
        {
            get { return this._Createtime; }
            set { this._Createtime = value; }
        }
        private int _State = 0;
        [Display(Name = "State")]
        public int State
        {
            get { return this._State; }
            set { this._State = value; }
        }
        private int _Managerid = 0;
        [Display(Name = "Managerid")]
        public int Managerid
        {
            get { return this._Managerid; }
            set { this._Managerid = value; }
        }
    }
}