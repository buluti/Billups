using System.Reflection;
using System.Reflection.Metadata;

namespace RPSLS.Persistence
{
    public class PersistenceAssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
