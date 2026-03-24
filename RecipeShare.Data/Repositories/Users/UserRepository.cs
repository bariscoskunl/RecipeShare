using Microsoft.EntityFrameworkCore;
using RecipeShare.Data.Entities;

namespace RecipeShare.Data.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _dbContext;

        public UserRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _dbContext.Set<User>().ToListAsync();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _dbContext.Set<User>().FindAsync(id);
        }

        public async Task CreateUser(User user)
        {
            _dbContext.Set<User>().Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            _dbContext.Entry(user).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var user = await _dbContext.Set<User>().FindAsync(id);
            if (user == null)
            {
                throw new InvalidOperationException($"Id'si {id} olan kullanıcı bulunamadı.");
            }
            _dbContext.Set<User>().Remove(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}