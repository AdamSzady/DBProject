//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orders
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public string WorkerId { get; set; }
        public string GivingAddress { get; set; }
        public Nullable<System.DateTime> GivingDate { get; set; }
        public string ReceiveAddress { get; set; }
        public Nullable<System.DateTime> ReceiveDate { get; set; }
        public Nullable<double> Price { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual AspNetUsers AspNetUsers1 { get; set; }
        public virtual OrderParts OrderParts { get; set; }
    }
}