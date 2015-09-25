﻿using System;
using System.Collections.Generic;
using System.Linq;
using T4TS.Tests.Mocks;

namespace T4TS.Tests
{
    partial class MemberOutputAppenderTests
    {
        #region - Test Data -

        private List<TypeScriptModule> GetDataToRender(Settings settings)
        {
            var generator = new CodeTraverser(
                new MockSolution(
                    typeof(TestClass),
                    typeof(TestBaseClass),
                    typeof(TestEnum)
                    ).Object, settings);
            return generator.GetAllInterfaces().ToList();
        }

        private const string OutputHeader =
            @"/****************************************************************************
  Generated by T4TS.tt - don't make any changes in this file
****************************************************************************/
";

        private const string ExpectedResult = OutputHeader + @"
declare module External1 {
    /** Generated from T4TS.Tests.MemberOutputAppenderTests+TestClass **/
    export interface TestClass {
        Id: number;
        Name: string;
        Date: Date;
        DatesList: Date[];
        DatesArray: Date[];
        RefObject: any;
        IntArray: number[];
        SelfArray: External1.TestClass[];
        IsVisible: boolean;
        IsOptional?: boolean;
        IntOptional?: number;
        Self: External1.TestClass;
        EnumProp: External2.TestEnum;
        EnumPropNull?: External2.TestEnum;
        EnumArray: External2.TestEnum[];
    }
}

declare module External2 {
    /** Generated from T4TS.Tests.MemberOutputAppenderTests+TestEnum **/
    enum TestEnum {
        TheItem1 = 1,
        Item2 = 2,
        Item21 = 3,
        Item22 = 4,
        Item23 = 5,
        Item3 = 5,
        Item4 = 6,
    }
}
";
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

        public class TestBaseClass
        {
            public string BaseProperty { get; set; }
        }


        [TypeScriptInterface(Module = "External1")]

        public class TestClass : TestBaseClass
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public DateTime Date { get; set; }

            public List<DateTime> DatesList { get; set; }
            public DateTime[] DatesArray { get; set; }

            public WeakReference RefObject { get; set; }

            public int[] IntArray { get; set; }

            public TestClass[] SelfArray { get; set; }

            public bool IsVisible { get; set; }
            public bool? IsOptional { get; set; }
            public int? IntOptional { get; set; }

            public TestClass Self { get; set; }
            public TestEnum EnumProp { get; set; }
            public TestEnum? EnumPropNull { get; set; }

            public TestEnum[] EnumArray { get; set; }
        }

        #endregion
    }
}