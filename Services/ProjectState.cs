namespace myorange_pmproject.Service
{
    public class ProejctSelect{

        public int? SelectValue {get;set;}
        public string? SelectText {get;set;}

    }
    public class ProjectState
    {
         

        /// <summary>
        /// 返回用户类型
        /// </summary>
        /// <returns></returns>
        public static String GetProjectState(int selectValue)
        {

             List<ProejctSelect> lst = GetProjectState();
             var r = lst.FirstOrDefault(x=>x.SelectValue == selectValue); 
             return r!=null?r.SelectText:"";


        }

        //            <option  value="0">请选择</option>
        // <option value = "1" > 新建 </ option >
        // < option value="2">进行中</option>
        //  <option value = "3" > 完成 </ option >
        //   < option value="4">挂起</option>
        //  <option value = "-1" > 取消 </ option >


     public static List<ProejctSelect> GetRequestState()
        {
            return new List<ProejctSelect>
            {
                new ProejctSelect(){
                     SelectValue = 0,
                     SelectText  = "请选择"
                 },
                 new ProejctSelect(){
                     SelectValue = 1,
                     SelectText  = "新建"
                 },
                 new ProejctSelect(){
                     SelectValue = 2,
                     SelectText  = "进行中"
                 },
                 new ProejctSelect(){
                     SelectValue = 3,
                     SelectText  = "完成"
                 },
                  new ProejctSelect(){
                     SelectValue = 4,
                     SelectText  = "挂起"
                 },
                 new ProejctSelect(){
                     SelectValue = -1,
                     SelectText  = "取消"
                 }
            };

        }
   

    public static List<ProejctSelect> GetProjectState()
        {
            return new List<ProejctSelect>
            {
                new ProejctSelect(){
                     SelectValue = 0,
                     SelectText  = "新建"
                 },
                 new ProejctSelect(){
                     SelectValue = 1,
                     SelectText  = "建设中"
                 },
                 new ProejctSelect(){
                     SelectValue = 2,
                     SelectText  = "已完成"
                 },
                 new ProejctSelect(){
                     SelectValue = -1,
                     SelectText  = "在规划"
                 }
            };
            
        }
    }
}