  namespace myorange_pmproject.Models;
public class Project { 
 
  private string _Id = "";
  public string Id
  {
  get { return this._Id; }
  set { this._Id = value; }
  }
  private string _Name = "";
  public string Name
  {
  get { return this._Name; }
  set { this._Name = value; }
  }
  private string _Intro = "";
  public string Intro
  {
  get { return this._Intro; }
  set { this._Intro = value; }
  }
  private DateTime _Createtime = DateTime.Now;
  public DateTime Createtime
  {
  get { return this._Createtime; }
  set { this._Createtime = value; }
  }
  private DateTime _Starttime = DateTime.Now;
  public DateTime Starttime
  {
  get { return this._Starttime; }
  set { this._Starttime = value; }
  }
  private DateTime _Endtime = DateTime.Now;
  public DateTime Endtime
  {
  get { return this._Endtime; }
  set { this._Endtime = value; }
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
