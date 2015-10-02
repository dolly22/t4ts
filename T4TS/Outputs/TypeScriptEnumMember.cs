using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T4TS
{
    public class TypeScriptEnumMember : IDocumentedElement
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public int Value { get; set; }
        public bool Ignore { get; set; }
        public string Comment { get; set; }
        public string DocComment { get; set; }
    }
}
