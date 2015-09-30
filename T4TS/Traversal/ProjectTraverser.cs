using EnvDTE;
using System;
using System.IO;
using System.Linq;

namespace T4TS
{
    public class ProjectTraverser
    {
        static readonly Guid SolutionItemKind = Guid.Parse(Constants.vsProjectKindSolutionItems);

        public Action<CodeNamespace> WithNamespace { get; private set; }

        public ProjectTraverser(Project project, Action<CodeNamespace> withNamespace)
        {
            if (project == null)
                throw new ArgumentNullException("project");
            
            if (withNamespace == null)
                throw new ArgumentNullException("withNamespace");

            WithNamespace = withNamespace;

            TraverseProject(project);
        }

        private void TraverseProject(Project project)
        {
            if (project.ProjectItems != null)
            {
                // traverse projects inside solution items
                if (Guid.Parse(project.Kind) == SolutionItemKind)
                {
                    foreach (ProjectItem pi in project.ProjectItems)
                    {
                        if (pi.SubProject != null)
                            TraverseProject(pi.SubProject);
                    }
                }

                // normal projects
                else if (CodeTraverser.Settings.ProjectNamesToProcess == null ||
                         CodeTraverser.Settings.ProjectNamesToProcess.Contains(project.Name))
                {
                    Traverse(project.ProjectItems);
                }
            }
        }

        private void Traverse(ProjectItems items)
        {
            foreach (ProjectItem pi in items)
            {
                if (ShouldProcessItem(pi))
                {
                    if (pi.FileCodeModel != null)
                    {
                        var codeElements = pi.FileCodeModel.CodeElements;

                        foreach (object elem in codeElements)
                        {
                            if (elem is CodeNamespace)
                                WithNamespace((CodeNamespace)elem);
                        }
                    }
                }

                if (pi.ProjectItems != null)
                    Traverse(pi.ProjectItems);
            }
        }

        private bool ShouldProcessItem(ProjectItem pi)
        {
            var fileName = pi.FileNames[0];

            if (System.IO.Path.GetExtension(fileName) == ".cs")
            {
                //support for unit tests
                if (fileName == "sourcefile.cs")
                    return true;

                var content = System.IO.File.ReadAllText(fileName);
                if (content.Contains("TypeScript"))
                    return true;
            }

            return false;
        }
    }
}
