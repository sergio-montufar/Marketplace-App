using marketplaceapp.Models;

namespace marketplaceapp.Data {

  public interface IUserRepository {
    User Create(User user);
  }
}