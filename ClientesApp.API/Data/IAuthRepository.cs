using System.Threading.Tasks;
using ClientesApp.API.Models;

namespace ClientesApp.API.Data
{
    public interface IAuthRepository
    {
         Task<Usuario> Registro(Usuario user, string password);
         Task<Usuario> Login(string username, string password);
         Task<bool> ExisteUsuario(string username);
    }
}