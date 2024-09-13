using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace myorange_pmproject.DTO;
public class Project_request_listDTO { 


    private string _Id = "";
    [Display(Name = "Id")]
    public string Id
    {
    get { return this._Id; }
    set { this._Id = value; }
    }
    private string _Projectid = "";
    [Display(Name = "Projectid")]
    public string Projectid
    {
    get { return this._Projectid; }
    set { this._Projectid = value; }
    }
    private string _Projectid_project_requestid = "";
    [Display(Name = "Projectid_project_requestid")]
    public string Projectid_project_requestid
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
