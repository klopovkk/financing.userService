using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository

    {
    private readonly FinancingContext context;

    public UserRepository(FinancingContext context)
    {
        this.context = context;
    }

    public async Task<ICollection<User>> Get(Expression<Func<User, bool>> filter = null)
    {
        IQueryable<User> list = context.Set<User>();
        if (filter != null)
            return await list?.Where(filter).ToListAsync();
        else return await list?.ToListAsync();
    }

    public async Task Create(User entity, string createBody = null)
    {
        context.Set<User>().Add(entity);
        await context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task<User> GetById(Guid id)
    {
        return await context.Set<User>().FindAsync(id);
    }

    public async Task Update(User entity, string updateBody = null)
    {
        context.Set<User>().Attach(entity);
        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task Delete(Guid id)
    {
        User entity = await context.Set<User>().FindAsync(id).ConfigureAwait(false);
        context.Remove(entity);
        await context.SaveChangesAsync();
    }
    }
}
