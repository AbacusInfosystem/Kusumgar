//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KusumgarDatabaseEntities
{
    using System;
    using System.Collections.Generic;
    
    public partial class M_Defect
    {
        public int Defect_Id { get; set; }
        public int Process_Id { get; set; }
        public string Defect_Major { get; set; }
        public string Defect_Minor { get; set; }
        public string Defect_Name { get; set; }
        public bool Status { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }
    }
}
