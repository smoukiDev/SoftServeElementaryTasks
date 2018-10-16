// <copyright file="UserInstruction.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace FileParser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class UserInstruction
    {
        protected string CompanyName { get; set; }

        protected string ProductName { get; set; }

        protected string ProductVersion { get; set; }

        protected DateTime ReleaseDate { get; set; }

        protected string Copyright { get; set; }

        protected string ProductDescription { get; set; }

        protected string UserManual { get; set; }

        public abstract void Display();
    }
}
