 
 namespace myorange_pmproject.Models;
public class Project_document { 
private string _Id = "";
public string Id
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
private string _State = "";
public string State
{
get { return this._State; }
set { this._State = value; }
}
private string _Managerid = "";
public string Managerid
{
get { return this._Managerid; }
set { this._Managerid = value; }
}
}
