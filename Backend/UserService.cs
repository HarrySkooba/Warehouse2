using Backend;
using Backend.DB;
using Microsoft.EntityFrameworkCore;
using WebApi.DB;

public class UserService : IUserService
{
    private readonly PostgresContext _context;
    public UserService(PostgresContext context)
    {
        _context = context;
    }
    public User GetUserByLogin(string username, string password)
    {
        return _context.Users.FirstOrDefault(u => u.Name == username && u.Password == password);
    }
    public Role GetRoleByLogin(int idrole)
    {
        return _context.Roles.FirstOrDefault(r => r.Id == idrole);
    }
    public List<User> GetAllUser()
    {
        return _context.Users.Include(u => u.Role).ToList();
    }
    public List<Role> GetAllRole()
    {
        return _context.Roles.ToList();
    }
    public List<Product> GetAllProduct()
    {
        return _context.Products.Include(u => u.Provider).ToList();
    }
    public List<Provider> GetAllProvider()
    {
        return _context.Providers.ToList();
    }
    public void DeleteUser(int userId)
    {
        var userToDelete = _context.Users.FirstOrDefault(u => u.Id == userId);

        if (userToDelete != null)
        {
            _context.Users.Remove(userToDelete);
            _context.SaveChanges();
            Console.WriteLine("Пользователь успешно удален.");
        }
        else
        {
            Console.WriteLine("Пользователь с указанным Id не найден.");
        }
    }

    public void DeleteRole(int roleId)
    {
        var roleToDelete = _context.Roles.FirstOrDefault(u => u.Id == roleId);

        if (roleToDelete != null)
        {
            _context.Roles.Remove(roleToDelete);
            _context.SaveChanges();
            Console.WriteLine("Роль успешно удалена.");
        }
        else
        {
            Console.WriteLine("Роль с указанным Id не найден.");
        }
    }

    public void DeleteProduct(int productId)
    {
        var productToDelete = _context.Products.FirstOrDefault(u => u.Id == productId);

        if (productToDelete != null)
        {
            _context.Products.Remove(productToDelete);
            _context.SaveChanges();
            Console.WriteLine("Продукт успешно удален.");
        }
        else
        {
            Console.WriteLine("Продукт с указанным Id не найден.");
        }
    }
    public void DeleteProvider(int providerId)
    {
        var providerToDelete = _context.Providers.FirstOrDefault(u => u.Id == providerId);

        if (providerToDelete != null)
        {
            _context.Providers.Remove(providerToDelete);
            _context.SaveChanges();
            Console.WriteLine("Поставщик успешно удален.");
        }
        else
        {
            Console.WriteLine("Поставщик с указанным Id не найден.");
        }
    }

    public void AddUser(User newUser)
    {
        using (var context = new PostgresContext()) 
        {
            context.Users.Add(newUser);
            context.SaveChangesAsync();
        }
    }
}