﻿/****************************************************************************
  Generated by T4TS.tt - don't make any changes in this file
****************************************************************************/

// -- Begin global interfaces {
    /** Generated from T4TS.Example.Models.Barfoo **/
    interface Barfoo {
        Number: number;
        Complex: T4TS.OverridenName;
        Name: string;
        DateTime: string;
    }
// -- End global interfaces

module Fooz {
    /** Generated from T4TS.Example.Models.Foobar **/
    export interface Foobar {
        OverrideAll?: bool;
        Recursive: Fooz.Foobar;
        NestedObjectArr: Barfoo[];
        NestedObjectList: Barfoo[];
        TwoDimensions: string[][];
        ThreeDimensions: Barfoo[][][];
    }
}

module T4TS {
    /** Generated from T4TS.Example.Models.Inherited **/
    export interface OverridenName {
        OtherName?: string;
        Integers: number[];
        Doubles: number[];
        TwoDimList: number[][];
        [index: number]: Barfoo;
    }
}