namespace PruebaTecnica_DVP_FMGS.API.InfraEstructura.General
{
    public static class Encriptacion
    {
        public static string Encriptar(string Cadena)
        {
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(Cadena);
            var result = Convert.ToBase64String(encryted);
            return result;
        }

        public static string Desencriptar(string Cadena)
        {
            byte[] decryted = Convert.FromBase64String(Cadena);
            var result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }

    }
}
