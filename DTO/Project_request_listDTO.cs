using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace myorange_pmproject.DTO;
public class Project_request_listDTO { 


    private int _Id = 0;
    [Display(Name = "Id")]
    public int Id
    {
    get { return this._Id; }
    set { this._Id = value; }
    }
    private int _Projectid = 0;
    [Display(Name = "Projectid")]
    public int Projectid
    {
    get { return this._Projectid; }
    set { this._Projectid = value; }
    }
    private int _Projectid_project_requestid = 0;
    [Display(Name = "Projectid_project_requestid")]
    public int Projectid_project_requestid
    {
    get { return this._Projectid_project_requestid; }
    set { this._Projectid_project_requestid = value; }
    }
    private DateTime _Createtime = DateTime.Now;
    [Display(Name = "Createtime")]
    public DateTime Createtime
    {
    get { return this._Createtime; }
    set { this._Createtime = value; }
    }



}
