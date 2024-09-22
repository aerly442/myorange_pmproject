using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
 
namespace myorange_pmproject.DTO;
public class ProjectDTO {
    private int _Id = 0;
    public int Id
    {
        get { return this._Id; }
        set { this._Id = value; }
    }
    private string _Name = "";
    [Display(Name = "Name")]
    [Required(ErrorMessage = "请输入项目名称")]
    [StringLength(100, ErrorMessage = "项目名称长度不能超过100个字符")]
    public string Name
    {
    get { return this._Name; }
    set { this._Name = value; }
    }
    private string _Intro = "";
    [Display(Name = "Intro")]
    [Required(ErrorMessage = "请输入项目简介")]
    [StringLength(100, ErrorMessage = "项目名称长度不能超过100个字符")]
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
    private int _State = 0;
    [Display(Name = "State")]
    public int State
    {
    get { return this._State; }
    set { this._State = value; }
    }
    private int _Managerid = 0;
    [Display(Name = "Managerid")]
    public int Managerid
    {
    get { return this._Managerid; }
    set { this._Managerid = value; }
    }
}
