 namespace myorange_pmproject.Models;
public class Project_tag { 
 
private int _Id = 0;
public int Id
{
get { return this._Id; }
set { this._Id = value; }
}
private string _Tag = "";
public string Tag
{
get { return this._Tag; }
set { this._Tag = value; }
}
private int _Projectid = 0;
public int Projectid
{
get { return this._Projectid; }
set { this._Projectid = value; }
}
private string _Createtime = "";
public string Createtime
{
get { return this._Createtime; }
set { this._Createtime = value; }
}
private int _Managerid = 0;
public int Managerid
{
get { return this._Managerid; }
set { this._Managerid = value; }
}
}
