using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace myorange_pmproject.DTO;
public class Project_project_document_listDTO { 
 
    private string _Id = "";
    [Display(Name = "Id")]
    public string Id
    {
    get { return this._Id; }
    set { this._Id = value; }
    }
    private string _Project_documentid = "";
    [Display(Name = "Project_documentid")]
    public string Project_documentid
    {
    get { return this._Project_documentid; }
    set { this._Project_documentid = value; }
    }
    private string _Projectid = "";
    [Display(Name = "Projectid")]
    public string Projectid
    {
    get { return this._Projectid; }
    set { this._Projectid = value; }
    }
    private string _Createtime = "";
    [Display(Name = "Createtime")]
    public string Createtime
    {
    get { return this._Createtime; }
    set { this._Createtime = value; }
    }


}