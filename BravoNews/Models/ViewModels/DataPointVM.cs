﻿using System;
using System.Runtime.Serialization;

namespace BravoNews.Models.ViewModels
{
    [DataContract]
    public class DataPointVM
    {
        public DataPointVM(string label, double y)
        {
            this.Label = label;
            this.Y = y;
        }
        [DataMember(Name = "label")]
        public string Label = "";
        [DataMember(Name = "y")]
        public Nullable<double> Y = null;
    }
}
