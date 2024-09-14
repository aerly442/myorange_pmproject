 
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace myorange_pmproject.DTO;
public class Project_tagDTO { 
private int _Id = 0;
 [Display(Name = "Id")]
public int Id
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
private int _Projectid = 0;
 [Display(Name = "Projectid")]
public int Projectid
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
private int _Managerid = 0;
 [Display(Name = "Managerid")]
public int Managerid
{
get { return this._Managerid; }
set { this._Managerid = value; }
}
}
