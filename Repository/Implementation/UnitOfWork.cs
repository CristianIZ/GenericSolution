using AutoMapper;
using Context;
using Repository.Interfaces;

namespace Repository.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlDatabaseContext _dbContext;
        private readonly IMapper _mapper;

        public UnitOfWork(SqlDatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int Complete()
        {
            return _dbContext.SaveChanges();
        }

        #region Ejemplo
        //private readonly MessageTranslatorDbContext _dbContext;
        //private readonly IMapper _mapper;
        //private IDataTypeRepository _dataTypeRepository;
        //private IEquivalenceRepository _equivalenceRepository;

        //public INodeRepository NodeRepository
        //{
        //    get
        //    {
        //        if (_nodeRepository == null)
        //        {
        //            _nodeRepository = new NodeRepository(_dbContext, _mapper);
        //        }
        //        return _nodeRepository;
        //    }
        //}

        //public IVerbRepository VerbRepository
        //{
        //    get
        //    {
        //        if (_verbRepository == null)
        //        {
        //            _verbRepository = new VerbRepository(_dbContext, _mapper);
        //        }
        //        return _verbRepository;
        //    }
        //}
        #endregion

    }
}
