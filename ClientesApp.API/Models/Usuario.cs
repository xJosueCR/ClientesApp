namespace ClientesApp.API.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] HashPassword{ get; set; }
        public byte[] SaltPassword{ get; set; }
    }
}