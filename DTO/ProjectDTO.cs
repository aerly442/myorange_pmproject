using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
 
namespace myorange_pmproject.DTO;
public class Project { 
private string _Id = "";
 [Display(Name = "Id")]
public string Id
{
get { return this._Id; }
set { this._Id = value; }
}
private string _Name = "";
 [Display(Name = "Name")]
public string Name
{
get { return this._Name; }
set { this._Name = value; }
}
private string _Intro = "";
 [Display(Name = "Intro")]
public string Intro
{
get { return this._Intro; }
set { this._Intro = value; }
}
private DateTime _Createtime = DateTime.Now;
 [Display(Name = "Createtime")]
public DateTime Createtime
{
get { return this._Createtime; }
set { this._Createtime = value; }
}
private DateTime _Starttime = DateTime.Now;
 [Display(Name = "Starttime")]
public DateTime Starttime
{
get { return this._Starttime; }
set { this._Starttime = value; }
}
private DateTime _Endtime = DateTime.Now;
 [Display(Name = "Endtime")]
public DateTime Endtime
{
get { return this._Endtime; }
set { this._Endtime = value; }
}
private string _State = "";
 [Display(Name = "State")]
public string State
{
get { return this._State; }
set { this._State = value; }
}
private string _Managerid = "";
 [Display(Name = "Managerid")]
public string Managerid
{
get { return this._Managerid; }
set { this._Managerid = value; }
}
}
