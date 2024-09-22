  
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace myorange_pmproject.DTO;
public class Project_requestDTO { 
 
    private int _Id = 0;
    [Display(Name = "Id")]
    public int Id
    {
    get { return this._Id; }
    set { this._Id = value; }
    }
    private string _Title = "";
    
    [Display(Name = "名称")]
    [Required(ErrorMessage = "请输入名称")]
    [StringLength(100, ErrorMessage = "名称长度不能超过100个字符")]
    public string Title
    {
    get { return this._Title; }
    set { this._Title = value; }
    }
    private string _Content = "";
   
    [Display(Name = "描述")]
    [Required(ErrorMessage = "请输入描述")]
    public string Content
    {
    get { return this._Content; }
    set { this._Content = value; }
    }
    private int _State = 0;
     [Display(Name = "State")]
    public int State
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


    private DateTime ?_Starttime ;
    [Display(Name = "开始时间")]
    public DateTime ?Starttime
    {
        get { return this._Starttime; }
        set { this._Starttime = value; }
    }

    private DateTime ?_Finishtime  ;
    [Display(Name = "完成时间")]
    public DateTime ?Finishtime
    {
        get { return this._Finishtime; }
        set { this._Finishtime = value; }
    }
    private DateTime ?_Willfinishtime ;
    [Display(Name = "预计完成时间")]
    public DateTime ?Willfinishtime
    {
        get { return this._Willfinishtime; }
        set { this._Willfinishtime = value; }
    }
    private string _Request_type = "0";
    [Display(Name = "Request_type")]
    public string Request_type
    {
    get { return this._Request_type; }
    set { this._Request_type = value; }
    }
    private int _Managerid = 0;
     [Display(Name = "Managerid")]
    public int Managerid
    {
    get { return this._Managerid; }
    set { this._Managerid = value; }
    }

    public int? ProjectId { get; set; }
    public string? ProjectName { get; set; }
}
