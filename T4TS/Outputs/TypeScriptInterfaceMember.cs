using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T4TS
{
    public class TypeScriptInterfaceMember : IDocumentedElement
    {
        public string Name { get; set; }

        public string Comment { get; set; }
        public string DocComment { get; set; }
        public TypescriptType Type { get; set; }
        public bool Optional { get; set; }
        public bool Ignore { get; set; }
    }
}
