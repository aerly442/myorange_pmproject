﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace myorange_pmproject.DTO
{
    public class Project_fileDTO
    {
        public int Id { get; set; } 
        [Display(Name = "文件名")]
        [Required(ErrorMessage = "请输入标题")]
        public string Filename { get; set; } 
        [Display(Name = "文件地址")]
        [Required(ErrorMessage = "请输入地址")]
        public string FileUrl { get; set; } 
        [Display(Name = "来源ID")]
        public int? SourceId { get; set; } 
        [Display(Name = "来源类型")]
        public string SourceType { get; set; } 
        public DateTime Createtime { get; set; } 
        public int State { get; set; } 


    }
}
