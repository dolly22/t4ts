﻿/****************************************************************************
  Generated by T4TS.tt - don't make any changes in this file
****************************************************************************/

declare module External1 {
    /** Generated from T4TS.Example.Models.ModelFromDifferentProject.TestEnum **/
    module ModelFromDifferentProject {
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
    /** Generated from T4TS.Example.Models.ModelFromDifferentProject.SubClass **/
    module ModelFromDifferentProject {
        export interface TestSubClass {
            Id: number;
            Name: string;
        }
    }
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
        IsOptional?: boolean;
        IntOptional?: number;
        Self: External1.ModelFromDifferentProject;
        EnumProp: External1.ModelFromDifferentProject.TestEnum;
        EnumPropNull?: External1.ModelFromDifferentProject.TestEnum;
        EnumArray: External1.ModelFromDifferentProject.TestEnum[];
        SubClassRef: External1.ModelFromDifferentProject.TestSubClass;
    }
}
