using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4TS
{
    public class EnumMemberOutputAppender : DocumentedOutputAppender<TypeScriptEnumMember>
    {
        public EnumMemberOutputAppender(StringBuilder output, int baseIndentation, Settings settings)
            : base(output, baseIndentation, settings)
        {
        }

        public override void AppendOutput(TypeScriptEnumMember member)
        {
            AppendDocumentation(member);
            AppendIndendation();
            
            Output.AppendFormat("{0} = {1}",
                member.Name,
                member.Value
            );
            
            Output.AppendLine(",");
        }
    }
}
