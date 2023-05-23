using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBodeguita.Model
{
    public class TipoModel
    {
        public int ID { set; get; }             //01 
        public string Codigo { set; get; }      //ENE
        public string Nombre { set; get; }      //ENERO

        public TipoModel(int ID, string Nombre) {
            this.ID = ID;
            this.Nombre = Nombre;
        }
    }
}
