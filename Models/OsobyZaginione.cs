//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rejestr_PawełPieniak.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OsobyZaginione
    {
        public int IdPersons { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public Nullable<System.DateTime> DateOfDisappearance { get; set; }
        public string PictureName { get; set; }
        public string CityOfDisappearance { get; set; }
        public string LocationOfDisappearance { get; set; }
    }
    public enum Gender
    {
        Woman,
        Man
    }
}
