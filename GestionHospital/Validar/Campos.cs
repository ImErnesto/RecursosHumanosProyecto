using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GestionHospital.Validar
{
    public static class Campos
    {

        public static bool EsSoloLetras(string texto)
        {
            return Regex.IsMatch(texto, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$");
        }

        public static bool EsNumero(string texto)
        {
            return Regex.IsMatch(texto, @"^\d+$");
        }

        public static bool EsDUIValido(string dui)
        {
            return dui.Length == 9 && EsNumero(dui);
        }

        public static bool EsTelefonoValido(string telefono)
        {
            return Regex.IsMatch(telefono, @"^\d{4}-\d{4}$");
        }


        public static bool EsEmailValido(string email)
        {
            return email.Contains("@");
        }

        public static bool EsSalarioValido(string salarioTexto, out decimal salario)
        {
            return decimal.TryParse(salarioTexto, out salario) && salario > 0;
        }
    }
}
