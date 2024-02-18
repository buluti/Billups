using System.Reflection;
using System.Reflection.Metadata;

namespace RPSLS.Application
{
    public class ApplicationAssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
