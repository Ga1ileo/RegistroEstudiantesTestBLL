using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroEF2.BLL
{
    public static class Validar
    {
        public static int ValidarEntero(String idTextBox)
        {
            int Id = 0;
            if(idTextBox.Length > 0)
            {
                bool result = Int32.TryParse(idTextBox, out Id);
            }
            else
            {
                return 0;
            }
            return Id;
        }
    }
}
