using Backend.DB;
using WebApi.DB;

namespace Backend
{
    public interface IUserService
    {
        User GetUserByLogin(string username, string password);
        Role GetRoleByLogin(int idrole);

        List<User> GetAllUser();

        List<Role> GetAllRole();

        List<Product> GetAllProduct();

        List<Provider> GetAllProvider();

        void DeleteUser(int userId);

        void DeleteRole(int roleId);

        void DeleteProduct(int productId);

        void DeleteProvider(int providerId);

        void AddUser(User newUser);
    }
}
