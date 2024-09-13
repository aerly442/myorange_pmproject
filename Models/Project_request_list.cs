namespace myorange_pmproject.Models;
public class Project_request_list { 



    private string _Id = "";
    public string Id
    {
    get { return this._Id; }
    set { this._Id = value; }
    }
    private string _Projectid = "";
    public string Projectid
    {
    get { return this._Projectid; }
    set { this._Projectid = value; }
    }
    private string _Projectid_project_requestid = "";
    public string Projectid_project_requestid
    {
    get { return this._Projectid_project_requestid; }
    set { this._Projectid_project_requestid = value; }
    }
    private DateTime _Createtime = DateTime.Now;
    public DateTime Createtime
    {
    get { return this._Createtime; }
    set { this._Createtime = value; }
    }



}
