//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FlowersCompany
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public int ID_Product { get; set; }
        public string Article { get; set; }
        public string Name_ { get; set; }
        public string UnitOfMeasurement { get; set; }
        public Nullable<int> Cost { get; set; }
        public Nullable<int> MaximumDiscountAmount { get; set; }
        public Nullable<int> Manufacturer { get; set; }
        public Nullable<int> Provider { get; set; }
        public Nullable<int> ProductCategory { get; set; }
        public Nullable<int> DeistSkidka { get; set; }
        public Nullable<int> KolvoNaSklade { get; set; }
        public string Opisanie { get; set; }
        public string Image { get; set; }
    
        public virtual Manufacturer Manufacturer1 { get; set; }
        public virtual ProductCategory ProductCategory1 { get; set; }
        public virtual Provider Provider1 { get; set; }
    }
}