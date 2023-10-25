using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public IRefreshToken RefreshTokens { get; }
        public IRolRepository Roles { get; }
        public IUserRepository Users { get; }

        Task<int> SaveAsync();
    }
}