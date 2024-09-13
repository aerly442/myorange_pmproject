  
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace myorange_pmproject.Models;
public class Project_requestDTO { 
 
private string _Id = "";
 [Display(Name = "Id")]
public string Id
{
get { return this._Id; }
set { this._Id = value; }
}
private string _Title = "";
 [Display(Name = "Title")]
public string Title
{
get { return this._Title; }
set { this._Title = value; }
}
private string _Content = "";
 [Display(Name = "Content")]
public string Content
{
get { return this._Content; }
set { this._Content = value; }
}
private string _State = "";
 [Display(Name = "State")]
public string State
{
get { return this._State; }
set { this._State = value; }
}
private DateTime _Createtime = DateTime.Now;
 [Display(Name = "Createtime")]
public DateTime Createtime
{
get { return this._Createtime; }
set { this._Createtime = value; }
}
private string _Request_type = "";
 [Display(Name = "Request_type")]
public string Request_type
{
get { return this._Request_type; }
set { this._Request_type = value; }
}
private string _Managerid = "";
 [Display(Name = "Managerid")]
public string Managerid
{
get { return this._Managerid; }
set { this._Managerid = value; }
}
}
