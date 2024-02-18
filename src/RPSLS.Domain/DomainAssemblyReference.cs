using System.Reflection;
using System.Reflection.Metadata;

namespace RPSLS.Domain
{
    public class DomainAssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
