using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace T4TS.Tests
{
    //[TestClass]
    public partial class MemberOutputAppenderTests
    {
        [TestMethod]
        public void TypescriptVersion083YieldsBool()
        {
            var sb = new StringBuilder();

            var member = new TypeScriptInterfaceMember
            {
                Name = "Foo",
                Type = new BoolType()
            };

            var appender = new MemberOutputAppender(sb, 0, new Settings
            {
                CompatibilityVersion = new Version(0, 8, 3)
            });

            appender.AppendOutput(member);
            Assert.AreEqual("Foo: bool;", sb.ToString().Trim());
        }

        [TestMethod]
        public void TypescriptVersion090YieldsBoolean()
        {
            var sb = new StringBuilder();
            var member = new TypeScriptInterfaceMember
            {
                Name = "Foo",
                Type = new BoolType()
            };

            var appender = new MemberOutputAppender(sb, 0, new Settings
            {
                CompatibilityVersion = new Version(0, 9, 0)
            });

            appender.AppendOutput(member);
            Assert.AreEqual("Foo: boolean;", sb.ToString().Trim());
        }

        [TestMethod]
        public void DefaultTypescriptVersionYieldsBoolean()
        {
            var sb = new StringBuilder();
            var member = new TypeScriptInterfaceMember
            {
                Name = "Foo",
                Type = new BoolType()
            };

            var appender = new MemberOutputAppender(sb, 0, new Settings
            {
                CompatibilityVersion = null
            });

            appender.AppendOutput(member);
            Assert.AreEqual("Foo: boolean;", sb.ToString().Trim());
            Console.WriteLine(sb.ToString());
        }

        [TestMethod]
        public void MemberOutputAppenderTestEnumType()
        {
            var sb = new StringBuilder();

            var member = new TypeScriptInterfaceMember
            {
                Name = "Foo",
                Type = new EnumType("FooEnum")
            };

            var settings = new Settings();
            var appender = new MemberOutputAppender(sb, 0, settings);

            appender.AppendOutput(member);
            Console.WriteLine(sb.ToString());
            Assert.IsTrue(sb.ToString().Contains("FooEnum"));
        }


        [TestMethod]
        public void TestOutput()
        {
            var settings = new Settings { UseNativeDates = true };
            string res = OutputFormatter.GetOutput(GetDataToRender(settings), settings);
            Console.WriteLine(res);
            Assert.AreEqual(ExpectedResult, res);
        }

        [TestMethod]
        public void TestOutputSubClasses()
        {
            var settings = new Settings { UseNativeDates = true };
            string res = OutputFormatter.GetOutput(GetDataToRenderSubClasses(settings), settings);
            Console.WriteLine(res);
            Assert.AreEqual(ExpectedSubClassesResult, res);
        }

        [TestMethod]
        public void TestOutputDataContract()
        {
            var settings = new Settings { UseNativeDates = true };
            var res = OutputFormatter.GetOutput(GetDataToRenderDataContract(settings), settings);
            // Test behaviour by default - no process DataContract classes 
            Assert.AreEqual(OutputHeader, res);
            // Test extended behaviour - process DataContract classes 
            settings.ProcessDataContracts = true;
            res = OutputFormatter.GetOutput(GetDataToRenderDataContract(settings), settings);
            Console.WriteLine(res);
            Assert.AreEqual(ExpectedDataContractResult, res);
        }

        [TestMethod]
        public void TestInheritedGeneric()
        {
            var settings = new Settings { UseNativeDates = true, ProcessDataContracts = true };
            string res = OutputFormatter.GetOutput(GetInheritedGenericDataToRender(settings), settings);
            Console.WriteLine(res);
            Assert.AreEqual(ExpectedInheritedGenericResult, res);
        }

    }
}