//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SoulMelody
{
    using System;
    using System.Collections.Generic;
    
    public partial class RGE
    {
        public int Id { get; set; }
        public Nullable<int> GenreID { get; set; }
        public Nullable<int> EmotionID { get; set; }
    
        public virtual Emotion Emotion { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
