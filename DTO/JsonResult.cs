 using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using AutoMapper;
 using Microsoft.AspNetCore.Authorization;
 using Microsoft.AspNetCore.Mvc;
 using Microsoft.AspNetCore.Mvc.RazorPages;
 using Microsoft.AspNetCore.Mvc.Rendering;
 using Microsoft.EntityFrameworkCore;
 using myorange_pmproject.DTO;
 using myorange_pmproject.Models;
 using myorange_pmproject.Service;
 using myorange_pmproject.Data;

 namespace myorange_pmproject.DTO
 {
      public class JsonResultDTO
     {
        public JsonResultDTO()
        {
             
        }
        public JsonResultDTO(string msg,int result,object data)
        {
            this.Msg = msg;
            this.Result = result ;
            this.Data = data;
             
        }

        public string Msg{get;set;}
        public int    Result{get;set;}

        public object Data{get;set;}
           
      }
 }
