namespace myorange_pmproject.Models;
public class Project_project_document_list { 
 
    private int _Id = 0;
    public int Id
    {
    get { return this._Id; }
    set { this._Id = value; }
    }
    private int _Project_documentid = 0;
    public int Project_documentid
    {
    get { return this._Project_documentid; }
    set { this._Project_documentid = value; }
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
}
