using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Alliance_Air_Desk.Models.Model
{
    public class KnowledgeMgntModel
    {
        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Upload File")]

        public string FileImg { get; set; }
        public HttpPostedFileBase file { get; set; }

        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }


        public string BriefingText { get; set; }
        public string BriefingDate { get; set; }
        public string searchType { get; set; }
    }
}