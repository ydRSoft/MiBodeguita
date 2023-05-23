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
        // PathArch -> Ubicacion del archivo
        // Datos -> parte linea del objeto separado por comas
        // Tipo -> true para agregar false es para crear
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

        // captura el 1er dato del linea del archivo
        public static int ValidaId(string PathArch, int ID)
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

        public static bool EliminaTemporal(string PathOriginal, string PathTemporal) {
            try {
                if (!File.Exists(PathTemporal))
                {
                    StreamWriter ArchTemp = new StreamWriter(PathTemporal);
                    ArchTemp.Close();
                }

                if (File.Exists(PathOriginal))
                {
                    File.Delete(PathOriginal);
                }

                File.Move(PathTemporal, PathOriginal);

                return true;
            } catch {
                return false;
            }
            
        }

    
    }
}
