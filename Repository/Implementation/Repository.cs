using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class Repository<TModel, TEntity> : IRepository<TModel, TEntity> where TModel : class where TEntity : class
    {
        protected readonly DbContext _context;
        protected readonly IMapper _mapper;

        public Repository(DbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public TModel Add(TModel model)
        {
            var modelToEntity = _mapper.Map<TEntity>(model);
            var entity = _context.Set<TEntity>().Add(modelToEntity).Entity;
            var entityToModel = _mapper.Map<TModel>(entity);
            return entityToModel;
        }

        public TModel Attach(TModel model)
        {
            var modelToEntity = _mapper.Map<TEntity>(model);
            var entity = _context.Set<TEntity>().Attach(modelToEntity).Entity;
            var entityToModel = _mapper.Map<TModel>(entity);
            return entityToModel;
        }

        public IEnumerable<TModel> List()
        {
            var models = _context.Set<TEntity>().UseAsDataSource(_mapper.ConfigurationProvider).For<TModel>();
            return models;
        }

        public TModel Get(int id)
        {
            var entity = _context.Set<TEntity>().Find(id);
            var model = _mapper.Map<TModel>(entity);
            return model;
        }
        public void Remove(int id)
        {
            var entity = _context.Set<TEntity>().Find(id);
            _context.Set<TEntity>().Remove(entity);
        }

        public TModel Update(TModel dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            var entityToDto = _mapper.Map<TModel>(_context.Set<TEntity>().Update(entity).Entity);
            return entityToDto;
        }
    }
}
