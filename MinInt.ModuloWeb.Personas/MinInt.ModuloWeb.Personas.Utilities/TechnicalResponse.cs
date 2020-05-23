using System;

namespace MinInt.ModuloWeb.Personas.Utilities
{
    public static class TechnicalResponse
    {
        [Flags]
        public enum ErrorCode : ushort
        {
            None = 0,
            UsuarioNoResgistrado = 100,
            PasswordIncorrecta = 200
        }
    }
}