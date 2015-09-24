﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using T4TS.Example.Models;
using T4TS.Tests.Fixtures.Basic;
using T4TS.Tests.Utils;

namespace T4TS.Tests.Fixtures.Inheritance
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void InheritanceModelHasExpectedOutput()
        {
            // Expect
            new OutputFor(
                typeof(InheritanceModel),
                typeof(OtherInheritanceModel),
                typeof(ModelFromDifferentProject),
                typeof(BasicModel)
            ).ToEqual(ExpectedOutput);
        }

const string ExpectedOutput = @"
/****************************************************************************
  Generated by T4TS.tt - don't make any changes in this file
****************************************************************************/

declare module External1 {
    /** Generated from T4TS.Example.Models.ModelFromDifferentProject **/
    export interface ModelFromDifferentProject {
        Id: number;
        Name: string;
        Date: string;
        DatesList: string[];
        DatesArray: string[];
        RefObject: any;
        IntArray: number[];
        SelfArray: External1.ModelFromDifferentProject[];
        IsVisible: boolean;
        IsOptional: boolean;
        IntOptional: number;
        Self: External1.ModelFromDifferentProject;
        EnumProp: any;
        EnumPropNull: any;
        EnumArray: any[];
    }
}

declare module T4TS {
    /** Generated from T4TS.Tests.Fixtures.Inheritance.InheritanceModel **/
    export interface InheritanceModel extends T4TS.OtherInheritanceModel {
        OnInheritanceModel: T4TS.BasicModel;
    }
    /** Generated from T4TS.Tests.Fixtures.Inheritance.OtherInheritanceModel **/
    export interface OtherInheritanceModel extends External1.ModelFromDifferentProject {
        OnOtherInheritanceModel: T4TS.BasicModel;
    }
    /** Generated from T4TS.Tests.Fixtures.Basic.BasicModel **/
    export interface BasicModel {
        MyProperty: number;
        SomeDateTime: string;
    }
}
";

    }
}
