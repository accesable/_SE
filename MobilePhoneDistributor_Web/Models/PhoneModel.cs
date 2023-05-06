using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace MobilePhoneDistributor_Web.Models
{
    public class PhoneModel
    {
        [Key]
        public string PhoneId { get; set; }
        [Required]
        [StringLength(100)]
        public string PhoneName { get; set; }
        [Required]
        [StringLength(100)]
        public string PhoneBrand { get; set; }

        public static DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Model ID");
            dt.Columns.Add("Model Name");
            dt.Columns.Add("Model Brand");
            return dt;
        }
    }
}