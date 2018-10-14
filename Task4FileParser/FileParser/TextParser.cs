// <copyright file="TextParser.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace FileParser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    abstract class TextParser
    {
        private string searchValue;
        private string replaceValue;

        public string SearchValue { get; set; }

        public string ReplaceValue { get; set; }

        public abstract int CountEnteries();

        public abstract int ReplaceEnteries();
    }
}
