namespace myorange_pmproject.Service
{
    public class ProejctSelect{

         public string SelectValue {get;set;}
        public string SelectText {get;set;}

    }
    public class ProjectState
    {
         

        /// <summary>
        /// 返回用户类型
        /// </summary>
        /// <returns></returns>
        public static String GetProjectState(String selectValue)
        {

             List<ProejctSelect> lst = GetProjectState();
             var r = projects.FirstOrDefault(x=>x.SelectValue == selectValue); 
             return r!=null?r.SelectText:"";

            
        }

        public static List<ProejctSelect> GetProjectState()
        {
            return new List<ProejctSelect>
            {

                 new ProejctSelect(){
                     SelectValue = "建设中",
                     SelectText  = "1"
                 },
                                   new ProejctSelect(){
                     SelectValue = "已完成",
                     SelectText  = "2"
                 },
                                  new ProejctSelect(){
                     SelectValue = "在规划",
                     SelectText  = "-1"
                 }
            };
            
        }
    }
}