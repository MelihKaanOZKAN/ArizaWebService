//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WEBApiDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tokens
    {
        public int TokenId { get; set; }
        public int KullaniciNo { get; set; }
        public string Token { get; set; }
    
        public virtual Kullanicilar Kullanicilar { get; set; }
    }
}
