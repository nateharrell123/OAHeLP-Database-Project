﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubjectData.Models
{
    public class Name: IEquatable<Name>
    {
        public string FirstName { get; }
        public string MiddleNames { get; }
        public string LastName { get; }

        public Name(string f, string m, string l)
        {
            FirstName = f;
            MiddleNames = m;
            LastName = l;
        }

        public bool Equals(Name other)
        {
            return (this.FirstName == other.FirstName
                && this.MiddleNames == other.MiddleNames
                && this.LastName == other.LastName);
        }
    }
}
