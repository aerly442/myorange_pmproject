 
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace myorange_pmproject.DTO;
public class Project_tagDTO { 
private string _Id = "";
 [Display(Name = "Id")]
public string Id
{
get { return this._Id; }
set { this._Id = value; }
}
private string _Tag = "";
 [Display(Name = "Tag")]
public string Tag
{
get { return this._Tag; }
set { this._Tag = value; }
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
private string _Managerid = "";
 [Display(Name = "Managerid")]
public string Managerid
{
get { return this._Managerid; }
set { this._Managerid = value; }
}
}
