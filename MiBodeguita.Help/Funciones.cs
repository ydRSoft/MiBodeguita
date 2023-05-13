using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBodeguita.Help
{
    public class Funciones
    {
        public static bool GuardarArchivo(string PathArch, string Datos)
        {
            try {                
                StreamWriter ArchSave = new StreamWriter(PathArch, true);
                ArchSave.WriteLine(Datos);
                ArchSave.Close();
                return true;
            } catch {
                return false;
            }
        }

        public static int IdArchivo(string PathArch) {
            try {
                if (File.Exists(PathArch)) {
                    StreamReader Arch = new StreamReader(PathArch);
                    string Linea = Arch.ReadLine();
                    if (Linea != null) {
                        Arch.Close();
                        int Cantidad = Convert.ToInt32(Linea);
                        return Cantidad;
                    }

                    Arch.Close();
                }
                return 0;
            } catch {
                return -1;
            }
        }
    }
}
