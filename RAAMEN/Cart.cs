//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RAAMEN
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cart
    {
        public int cartID { get; set; }
        public int headerID { get; set; }
        public string orderStatus { get; set; }
    
        public virtual Header Header { get; set; }
    }
}