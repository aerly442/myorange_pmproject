using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myorange_pmproject.Models
{
    [Table("Project_request")]
    public class Project_request
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
        private int _State = 0;
        public int State
        {
            get { return this._State; }
            set { this._State = value; }
        }
        private DateTime _Createtime = DateTime.Now;
        public DateTime Createtime
        {
            get { return this._Createtime; }
            set { this._Createtime = value; }
        }

        private DateTime? _Starttime ;
        public DateTime? Starttime
        {
            get { return this._Starttime; }
            set { this._Starttime = value; }
        }
        private DateTime? _Finishtime ;
        public DateTime? Finishtime
        {
            get { return this._Finishtime; }
            set { this._Finishtime = value; }
        }
        private DateTime? _Willfinishtime ;
        public DateTime? Willfinishtime
        {
            get { return this._Willfinishtime; }
            set { this._Willfinishtime = value; }
        }
        private string _Request_type = "";
        public string Request_type
        {
            get { return this._Request_type; }
            set { this._Request_type = value; }
        }
        private int _Managerid = 0;
        public int Managerid
        {
            get { return this._Managerid; }
            set { this._Managerid = value; }
        }
    }
}