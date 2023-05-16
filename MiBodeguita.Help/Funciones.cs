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
        public static bool GuardarArchivo(string PathArch, string Datos,bool Tipo)
        {
            try {                
                StreamWriter ArchSave = new StreamWriter(PathArch, Tipo);
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

        public static int ValidaId(string PathArch,int ID)
        {
            try {
                if (File.Exists(PathArch)) {
                    StreamReader Arch = new StreamReader(PathArch);
                    string Linea = Arch.ReadLine();
                    while (Linea != null) {
                        string[] Arreglo;
                        Arreglo = Linea.Split(',');
                        int IdLocal = Convert.ToInt32(Arreglo[0]);
                        if (IdLocal == ID) {
                            Arch.Close();
                            return 0;
                        }
                        Linea = Arch.ReadLine();
                    }
                    Arch.Close();
                }
                return ID;
            } catch {
                return -1;
            }
        }

    }
}
