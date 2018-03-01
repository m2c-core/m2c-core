using System;
using System.Collections.Generic;
using System.Text;

namespace M2C.Core.Abstractions
{
    public interface IProperty
    {
        string Name { get; set; }

        object Value { get; set; }

        //public override string ToString()
        //{
        //    string valueString = Value != null ? Value.ToString() : "{x:Null}";
        //    string nameString = !String.IsNullOrEmpty(Key) ? Name : "noName";
        //    string valueType = Value != null ? Value.GetType().Name : "noType";
        //    return String.Format("{0}<{1}> : {2}", nameString, valueType, valueString);
        //}
    }
}
