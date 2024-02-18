using System.Reflection;
using System.Reflection.Metadata;

namespace RPSLS.Infrastructure
{
    public class InfrastructureAssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
