namespace myorange_pmproject.Models;
public class Project_request_list { 



    private int _Id = 0;
    public int Id
    {
    get { return this._Id; }
    set { this._Id = value; }
    }
    private int _Projectid = 0;
    public int Projectid
    {
    get { return this._Projectid; }
    set { this._Projectid = value; }
    }
    private int _Projectid_project_requestid = 0;
    public int Projectid_project_requestid
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
