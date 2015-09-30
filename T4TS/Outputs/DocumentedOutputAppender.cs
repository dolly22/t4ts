using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4TS
{
    public abstract class DocumentedOutputAppender<TSegment> : OutputAppender<TSegment>
        where TSegment : class, IDocumentedElement
    {
        public DocumentedOutputAppender(StringBuilder output, int baseIndentation, Settings settings)
            : base(output, baseIndentation, settings)
        {
        }

        protected void AppendDocumentation(TSegment element)
        {
            var comment = SanitizeComment(element.Comment);
            var docComment = SanitizeComment(element.DocComment);

            if (!string.IsNullOrWhiteSpace(comment))
                AppendIndentedLine(FormatComment(comment));

            if (!string.IsNullOrWhiteSpace(docComment))
                AppendIndentedLine(FormatComment(docComment));
        }

        private string FormatComment(string commentText)
        {
            return string.Concat(
                "/**  ",
                commentText.Replace(Environment.NewLine, Environment.NewLine + new string(' ', BaseIndentation) + "* "),
                " */");
        }

        private string SanitizeComment(string commentText)
        {
            if (string.IsNullOrEmpty(commentText))
                return null;

            return System.Text.RegularExpressions.Regex.Replace(commentText, @"<[^>]+>", "").Trim();
        }
    }
}
