using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class BaseRepositorio<T> : IBaseRepositorio<T> where T : Base
    {
        private readonly AgendaContext _context;

        public BaseRepositorio() { }

        public BaseRepositorio(AgendaContext context)
        {
            _context = context;
        }
        public virtual async Task<T> Criar(T objeto)
        {
            _context.Add(objeto);
            await _context.SaveChangesAsync();

            return objeto;
        }

        public virtual async Task<T> Atualizar(T objeto)
        {
            _context.Entry(objeto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return objeto;

        }

        public virtual async Task<T> Obter(long id)
        {
            var objeto = await _context.Set<T>()
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ToListAsync();

            return objeto.FirstOrDefault();
        }

        public virtual async Task<List<T>> Obter()
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .ToListAsync();
        }

        public virtual async Task Remover(long id)
        {
            var objeto = await Obter(id);
                
            if(objeto != null)
            {
                _context.Remove(objeto);
                await _context.SaveChangesAsync();
                     
            }
        }
    }
}
