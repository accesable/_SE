﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MobilePhoneDistributor_Web.Models
{
    public class ModelDbContext :DbContext
    {
        public ModelDbContext():base("name=MyConn") { }

        public virtual DbSet<Staff> Staffs { get; set;}

        public virtual DbSet<PhoneModel> PhoneModels { get; set;}
        public virtual DbSet<Receipt> Receipts { get; set;}
        public virtual DbSet<ReceiptDetail> ReceiptsDetail { get; set; }
        public virtual DbSet<Agent> Agents { get; set;}

        public virtual DbSet<Order> Orders { get; set;}
        public virtual DbSet<OrderDetail> OrdersDetail { get; set;}
        public virtual DbSet<DeliveryNote> DeliveryNotes { get; set;}
    }
}