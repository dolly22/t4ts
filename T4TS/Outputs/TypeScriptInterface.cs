﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvDTE;

namespace T4TS
{
    public class TypeScriptInterface
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        
        public string Comment { get; set; }

        private string _docComment;
        public string DocComment {
          get { return _docComment; }
          set {
            _docComment = value;
            if(value == null) { return; }
            //strip the '<doc> </doc>' xml tags
            if(value.StartsWith("<doc>") && value.EndsWith("</doc>")) {
              _docComment = value.Substring(5, value.Length - 11).Trim();
            } else { _docComment = value; }
          }
        }

        public List<TypeScriptInterfaceMember> Members { get; set; }
        public TypescriptType IndexedType { get; set; }
        public TypeScriptInterface Parent { get; set; }
        public TypeScriptModule Module { get; set; }
        public TypeScriptInterface Owner { get; set; }


        public List<TypeScriptInterface> SubClasses { get; set; }
        public List<TypeScriptEnum> SubEnums { get; set; }

        public TypeScriptInterface()
        {
            Members = new List<TypeScriptInterfaceMember>();
            SubClasses = new List<TypeScriptInterface>();
            SubEnums = new List<TypeScriptEnum>();
        }
    }
}
