﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PortalListing.Contracts;
using PortalListing.Data;
using PortalListing.Models;

namespace PortalListing.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly PortalListingDbContext _context;
        private readonly IMapper _mapper;

        public GenericRepository(PortalListingDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            // "Set" keyword: refer to DbContext
            return await _context.Set<T>().ToListAsync();
        }

        // paging
        public async Task<PagedResult<TResult>> GetAllAsync<TResult>(QueryParameters queryParameters)
        {
            var totalSize = await _context.Set<T>().CountAsync();
            var items = await _context.Set<T>()
                .Skip(queryParameters.StartIndex)
                .Take(queryParameters.PageSize)
                .ProjectTo<TResult>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new PagedResult<TResult>
            {
                Items = items,
                PageNumber = queryParameters.StartIndex,
                RecordNumber = queryParameters.PageSize,
                TotalCount = totalSize
            };
        }

        public async Task<T> GetAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }

            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
