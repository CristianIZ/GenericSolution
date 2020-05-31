using Repository.Implementation;
using Repository.Interfaces;
using StructureMap;

namespace Repository
{
    public class RepositoryRegestry : Registry
    {
        public RepositoryRegestry()
        {
            For<IUnitOfWork>().Use<UnitOfWork>();
        }
    }
}
