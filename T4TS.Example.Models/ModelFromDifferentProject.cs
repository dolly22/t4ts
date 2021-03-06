﻿using System;
using System.Collections.Generic;

namespace T4TS.Example.Models
{
    [TypeScriptInterface(Module="External1")]
    public class ModelFromDifferentProject
    {
        /// <summary>
        /// Comment for enum
        /// </summary>
        public enum TestEnum
        {
            [TypeScriptMember(Name = "TheItem1")]
            Item1 = 1,
            /// <summary>
            /// Comment for enum value
            /// </summary>
            Item2 = 2,
            Item21,
            Item22,
            Item23,
            Item3 = 5,
            Item4,
        }

        [TypeScriptInterface(Name = "TestSubClass")]
        public class SubClass
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public List<DateTime> DatesList { get; set; }
        public DateTime[] DatesArray { get; set; }

        public WeakReference RefObject { get; set; }

        public int[] IntArray { get; set; }

        public ModelFromDifferentProject[] SelfArray { get; set; }

        public bool IsVisible { get; set; }
        public bool? IsOptional { get; set; }
        public int? IntOptional { get; set; }

        public ModelFromDifferentProject Self { get; set; }
        public TestEnum EnumProp { get; set; }
        public TestEnum? EnumPropNull { get; set; }

        public TestEnum[] EnumArray { get; set; }

        public SubClass SubClassRef { get; set; }
    }

/*
    [TypeScriptEnum(Module = "External2")]
    public enum TestEnum
    {
        [TypeScriptMember(Name = "TheItem1")]
        Item1 = 1,
        Item2 = 2,
        Item21,
        Item22,
        Item23,
        Item3 = 5,
        Item4,
    }
*/
}
