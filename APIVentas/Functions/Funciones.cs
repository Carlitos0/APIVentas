using System;

namespace APIVentas.Functions
{
    public class Funciones
    {
        private const string characters = "abcdefghijklmnopqrstuvwxyz0123456789";
        private static Random random = new Random();

        private static string values(int length)
        {
            return new string(Enumerable.Repeat(characters, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public string GenerarCodigo(string entitieName)
        {
            if (entitieName == null) return "xxxx";
            string code = values(5);
            String newCodigo = string.Concat(entitieName.AsSpan(0,2), code);
            return newCodigo;
        }
    }
}
