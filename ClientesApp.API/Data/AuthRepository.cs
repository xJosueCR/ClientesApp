using System;
using System.Threading.Tasks;
using ClientesApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientesApp.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            this._context = context;

        }
        public async Task<Usuario> Registro(Usuario user, string password)
        {
          byte[] passwordHash, passwordSalt;
          CrearPasswordHash(password, out passwordHash, out passwordSalt);

          user.HashPassword = passwordHash;
          user.SaltPassword = passwordSalt;
          //agregar y guardar cambios
          await _context.Usuarios.AddAsync(user);
          await _context.SaveChangesAsync();
          return user;
        }

        public async Task<Usuario> Login(string username, string password)
        {
            var user = await _context.Usuarios
                        .FirstOrDefaultAsync(u => u.Username == username);
            if(user == null)
                return null;
            if(!VerificarPassword(password, user.HashPassword, user.SaltPassword))
                return null;
            return user;

        }
        public async Task<bool> ExisteUsuario(string username)
        {
            if( await _context.Usuarios.AnyAsync(u => u.Username == username))
                return true;
            return false;

        }
        private void CrearPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
           using (var codigoMAC = new System.Security.Cryptography.HMACSHA512()){
                passwordSalt = codigoMAC.Key;
                passwordHash = codigoMAC.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
           }
           
        }
        private bool VerificarPassword(string password, byte[] hashPassword, byte[] saltPassword)
        {
            using (var codigoMAC = new System.Security.Cryptography.HMACSHA512(saltPassword))
            {
                var hash = codigoMAC.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i = 0; i<hash.Length; i++){
                    if(hash[i] != hashPassword[i])
                        return false;
                }
            }
            return true;
        }
    }
}