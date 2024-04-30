using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAG.Order.Entities;
using TAG.Order.Repositoryy.Interface;

namespace TAG.Order.Repository.Implementation
{
    public class GenericRepository : IRepository<OrderDetails>
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(OrderDetails orderdetails)
        {
            _context.orders.Add(orderdetails);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(OrderDetails orderdetails)
        {
            _context.orders.Remove(orderdetails);
            await _context.SaveChangesAsync();
        }

        public async Task<List<OrderDetails>> GetAll()
        {
            return await _context.orders.ToListAsync();
        }

        public async Task<OrderDetails> GetById(int id)
        {
            var product = await _context.orders.FindAsync(id);
            return product;
        }

        public async Task Update(OrderDetails orderdetails)
        {
            _context.orders.Update(orderdetails);
            await _context.SaveChangesAsync();
        }
    }
}
