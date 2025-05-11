using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IUserRepository
    {
        Task<ICollection<User>> Get(Expression<Func<User, bool>> filter = null);
        Task<User> GetById(Guid id);
        Task Create(User entity, string createBody = null);
        Task Update(User entity, string modifieBody = null);
        Task Delete(Guid id);
    }
}
