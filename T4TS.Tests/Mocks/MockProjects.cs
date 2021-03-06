using System;
using EnvDTE;
using Moq;

namespace T4TS.Tests.Mocks
{
    class MockProjects : BaseList<Project>, Projects
    {
        #region - Not Implemented Members -

        public Properties Properties { get { throw new NotImplementedException(); } }
        public new DTE Parent { get { throw new NotImplementedException(); } }

        #endregion

        public MockProjects(params Type[] types)
        {
            var project = new Mock<Project>(MockBehavior.Strict);
            project.Setup(x => x.ProjectItems).Returns(new MockProjectItems(types));
            project.Setup(x => x.Kind).Returns(Constants.vsProjectKindMisc);
            Add(project.Object);
        }
    }
}