using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MobilePhoneDistributor_Web.Models
{
    public class Order
    {
        [Key]
        public string OrderId { get; set; }

        [Display(Name = "Ordered on")]
        public DateTime OrderDate { get; set; } = DateTime.Now;
        [Required]
        [StringLength(250)]
        public string OrderStatus { get; set; }
        [Required]
        [StringLength(250)]
        public string PaymentMethod { get; set; }
        [Required]
        [StringLength(250)]
        public string PaymentStatus { get; set; }
        [Required]
        [ForeignKey("Agent")]
        public string AgentId { get; set; }
        public Agent Agent { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public static DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Order ID");
            dt.Columns.Add("Order Date");
            dt.Columns.Add("Agent ID");
            dt.Columns.Add("Order Status");
            dt.Columns.Add("Payment Method");
            dt.Columns.Add("Payment Status");
            return dt;
        }
    }
    
    public class DeliveryNote
    {
        [Key]
        public string DeliveryNoteId { get; set; }
        [Required]
        [Display(Name = "Delivery on")]
        public DateTime DeliveryDate { get; set; } = DateTime.Now;
        [Required]
        [Display(Name ="Order ID")]
        [ForeignKey("Order")]
        public string OrderId { get; set; }
        public virtual Order Order { get; set; }
        public static DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Note ID");
            dt.Columns.Add("Delivery Date");
            dt.Columns.Add("Order ID");

            return dt;
        }

    }
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        [Required]
        public string OrderId { get; set; }
        public Order Order { get; set; }

        [Required]
        public int Quantity { get; set; }
        [Required]
        [ForeignKey("PhoneModel")]
        public string PhoneModelId { get; set; }
        public PhoneModel PhoneModel { get; set; }
        public static DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Order Detail ID");
            dt.Columns.Add("Order ID");
            dt.Columns.Add("Phone Model ID");
            dt.Columns.Add("Phone Model");
            dt.Columns.Add("Quantity");

            return dt;
        }
    }
    
    [NotMapped]
    public class OrderDetailCreateViewModel
    {
        [Required]
        public int Quantity { get; set; }

    }
}