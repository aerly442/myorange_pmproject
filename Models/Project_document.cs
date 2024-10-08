
using System.ComponentModel.DataAnnotations.Schema;

namespace myorange_pmproject.Models
{
    [Table("Project_document")]
    public class Project_document
    {
        private int _Id = 0;
        public int Id
        {
            get { return this._Id; }
            set { this._Id = value; }
        }
        private string _Title = "";
        public string Title
        {
            get { return this._Title; }
            set { this._Title = value; }
        }
        private string _Content = "";
        public string Content
        {
            get { return this._Content; }
            set { this._Content = value; }
        }
        private DateTime _Createtime = DateTime.Now;
        public DateTime Createtime
        {
            get { return this._Createtime; }
            set { this._Createtime = value; }
        }
        private int _State = 0;
        public int State
        {
            get { return this._State; }
            set { this._State = value; }
        }
        private int _Managerid = 0;
        public int Managerid
        {
            get { return this._Managerid; }
            set { this._Managerid = value; }
        }
    }
}
