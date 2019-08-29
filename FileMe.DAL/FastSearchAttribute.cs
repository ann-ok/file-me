using System;

namespace FileMe.DAL
{
    class FastSearchAttribute: Attribute
    {
        public FiledType FiledType { get; set; }
    }

    public enum FiledType
    {
        String,
        Int,
        ComplexEntity
    }
}
