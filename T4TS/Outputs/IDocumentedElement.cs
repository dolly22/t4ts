﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4TS
{
    public interface IDocumentedElement
    {
        string Comment { get; }

        string DocComment { get; }
    }
}
