using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EnvDTE;
using Moq;
using T4TS.Tests.Utils;

namespace T4TS.Tests.Mocks
{
    class MockCodeTypes : CodeElemens<CodeElement>
    {
        public MockCodeTypes(params Type[] types)
        {
            foreach (var type in types)
            {
                if (type.IsEnum)
                    Add((CodeElement)new MockCodeEnum(type).Object);
                else
                    Add((CodeElement)new MockCodeClass(type).Object);
            }
        }
    }

    class MockCodeClass : Mock<CodeClass>
    {
        public MockCodeClass(Type type) : base(MockBehavior.Strict)
        {
            var fullName = DTETransformer.GetTypeFullname(type.FullName);

            var el = As<CodeElement>();
            el.Setup(x => x.Name).Returns(type.Name.Split('`')[0]);
            el.Setup(x => x.FullName).Returns(fullName);            
            Setup(x => x.Attributes).Returns(new MockAttributes(type.GetCustomAttributes(false).OfType<Attribute>()));
            Setup(x => x.Name).Returns(type.Name.Split('`')[0]);
            Setup(x => x.FullName).Returns(fullName);
            Setup(x => x.Members).Returns(new MockCodeProperties(type));
            Setup(x => x.Access).Returns(vsCMAccess.vsCMAccessPublic);
            Setup(x => x.Comment).Returns(string.Empty);
            Setup(x => x.DocComment).Returns(string.Empty);
           
            var bases = new CodeElemens<CodeElement>();
            if (type.BaseType != null && type.BaseType != typeof(object))
            {
                bases.Add((CodeElement)new MockCodeClass(type.BaseType).Object);
            }
            Setup(x => x.Bases).Returns(bases);
        }
    }

    class MockCodeEnum : Mock<CodeEnum>
    {
        public MockCodeEnum(Type type) : base(MockBehavior.Strict)
        {
            As<CodeElement>();
            Setup(x => x.Attributes).Returns(new MockAttributes(type.GetCustomAttributes(false).OfType<Attribute>()));
            Setup(x => x.Name).Returns(type.Name);
            Setup(x => x.FullName).Returns(type.FullName);
            Setup(x => x.Bases).Returns(new CodeElemens<CodeElement>());
            Setup(x => x.Members).Returns(new MockCodeVariables(type));
            Setup(x => x.Access).Returns(vsCMAccess.vsCMAccessPublic);
            Setup(x => x.Comment).Returns(string.Empty);
            Setup(x => x.DocComment).Returns(string.Empty);
        }
    }

    class MockAttributes : CodeElemens<CodeAttribute>
    {
        public MockAttributes(IEnumerable<Attribute> attributes)
        {
            foreach (var attr in attributes)
            {
                Add(new MockCodeAttribute(attr).Object);
            }
        }
    }
    class MockCodeAttribute : Mock<CodeAttribute>
    {
        public MockCodeAttribute(Attribute attr) : base(MockBehavior.Strict)
        {
            Setup(x => x.FullName).Returns(attr.GetType().FullName);
            Setup(x => x.Children).Returns(new MockAttributeProperties(attr));
        }
    }

    class MockAttributeProperties : CodeElemens<EnvDTE80.CodeAttributeArgument>
    {
        public MockAttributeProperties(Attribute attr)
        {
            foreach (var pi in attr.GetType().GetProperties())
            {
                var value = pi.GetValue(attr);
                if (value != null)
                    Add(new MockCodeAttributeArgument(pi.Name, value).Object);
            }
        }
    }

    class MockCodeAttributeArgument : Mock<EnvDTE80.CodeAttributeArgument>
    {
        public MockCodeAttributeArgument(string name, object value) : base(MockBehavior.Strict)
        {
            As<CodeElement>();
            Setup(x => x.Name).Returns(name);
            Setup(x => x.Value).Returns(value.ToString());
        }
    }


    class MockCodeProperties : CodeElemens<CodeElement>
    {
        public MockCodeProperties(Type type)
        {
            foreach (PropertyInfo pi in type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly))
            {
                if (pi.DeclaringType == type)
                Add((CodeElement) new MockCodeProperty(pi).Object);
            }

            foreach (var subType in type.GetNestedTypes())
            {
                if (subType.IsEnum)
                    Add((CodeElement)new MockCodeEnum(subType).Object);
                else if (subType.IsClass)
                    Add((CodeElement)new MockCodeClass(subType).Object);
            }
        }
    }

    class MockCodeProperty : Mock<CodeProperty>
    {
        public MockCodeProperty(PropertyInfo pi) : base(MockBehavior.Strict)
        {
            As<CodeElement>();
            Setup(x => x.FullName).Returns(pi.Name);
            Setup(x => x.Name).Returns(pi.Name);
            Setup(x => x.Attributes).Returns(new MockAttributes(pi.GetCustomAttributes()));
            Setup(x => x.Access).Returns(pi.GetAccessors(false).Length == 0 ? vsCMAccess.vsCMAccessPrivate : vsCMAccess.vsCMAccessPublic);
            if (pi.CanRead)
                Setup(x => x.Getter).Returns(new PropertyGetterMock(pi).Object);
            else
                Setup(x => x.Getter).Returns((CodeFunction) null);

            Setup(x => x.Comment).Returns(string.Empty);
            Setup(x => x.DocComment).Returns(string.Empty);
        }
    }

    class PropertyGetterMock : Mock<CodeFunction>
    {
        public PropertyGetterMock(PropertyInfo pi) : base(MockBehavior.Strict)
        {
            Setup(x => x.Name).Returns(pi.Name);
            Setup(x => x.Type).Returns(new CodeTypeRefMock(pi.PropertyType).Object);
        }
    }

    class FieldGetterMock : Mock<CodeFunction>
    {
        public FieldGetterMock(FieldInfo fi) : base(MockBehavior.Strict)
        {
            Setup(x => x.Name).Returns(fi.Name);
            Setup(x => x.Type).Returns(new CodeTypeRefMock(fi.FieldType).Object);
        }
    }

    class CodeTypeRefMock : Mock<CodeTypeRef>
    {
        public CodeTypeRefMock(Type propertyType): base(MockBehavior.Strict)
        {
            string fullName = DTETransformer.GetTypeFullname(propertyType.FullName);
            Setup(x => x.AsFullName).Returns(fullName);

            if (propertyType.IsArray)
            {
                Setup(x => x.TypeKind).Returns(vsCMTypeRef.vsCMTypeRefArray);
                Setup(x => x.ElementType).Returns(new CodeTypeRefMock(propertyType.GetElementType()).Object);
            }
            else if (propertyType == typeof(string))
            {
                Setup(x => x.TypeKind).Returns(vsCMTypeRef.vsCMTypeRefString);
            }
            else if (propertyType == typeof(char))
            {
                Setup(x => x.TypeKind).Returns(vsCMTypeRef.vsCMTypeRefChar);
            }
            else if (propertyType == typeof(bool))
            {
                Setup(x => x.TypeKind).Returns(vsCMTypeRef.vsCMTypeRefBool);
            }
            else if (propertyType == typeof(int))
            {
                Setup(x => x.TypeKind).Returns(vsCMTypeRef.vsCMTypeRefInt);
            }
            else
            {
                Setup(x => x.TypeKind).Returns(vsCMTypeRef.vsCMTypeRefObject);
            }
        }
    }


    class MockCodeVariables : CodeElemens<CodeVariable>
    {
        public MockCodeVariables(Type type)
        {
            foreach (var name in Enum.GetNames(type))
            {
                var fi = type.GetField(name, BindingFlags.Static | BindingFlags.Public);
                Add(new MockCodeVariable(fi).Object);
            }
        }
    }

    class MockCodeVariable: Mock<CodeVariable>
    {
        public MockCodeVariable(FieldInfo fi) : base(MockBehavior.Strict)
        {
            Setup(x => x.FullName).Returns(fi.Name);
            Setup(x => x.Name).Returns(fi.Name);
            Setup(x => x.Attributes).Returns(new MockAttributes(fi.GetCustomAttributes()));
            Setup(x => x.Access).Returns(vsCMAccess.vsCMAccessPublic);
            Setup(x => x.InitExpression).Returns(((int)fi.GetValue(null)).ToString());
            Setup(x => x.Comment).Returns(string.Empty);
            Setup(x => x.DocComment).Returns(string.Empty);
        }
    }

}