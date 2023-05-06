 using marketplaceapp.Models;

 namespace marketplaceapp.Data {
  public class UserRepository : IUserRepository {
    private readonly UserContext2 _context;
    public UserRepository(UserContext2 context) {
      _context = context;
    }
    public User Create(User user)
    {
      _context.Users.Add(user);
      user.Id = _context.SaveChanges();

      return user;
    }

  }
 }