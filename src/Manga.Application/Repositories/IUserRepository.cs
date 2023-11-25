using Manga.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga.Application.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByUserName(string username);
        void Update(User entity);
    }
}
