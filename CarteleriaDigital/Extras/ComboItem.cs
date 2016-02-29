using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteleriaDigital.Extras
{
    public class ComboItem
    {
        string iTexto;
        object iObjeto;

        public ComboItem(string pTexto, object pObjeto)
        {
            iTexto = pTexto;
            iObjeto = pObjeto;
        }

        public string Texto
        {
            get { return iTexto; }
            set { iTexto = value; }
        }

        public object Objeto
        {
            get { return iObjeto; }
            set { iObjeto = value; }
        }

        public override string ToString()
        {
            return iTexto;
        }
    }
}
