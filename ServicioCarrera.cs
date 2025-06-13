using System.Text.Json;
using SistemaAcademico_V2.Models;

namespace SistemaAcademico_V2.Servicios
{
    public class ServicioCarrera
    {
        private static string ruta = "Data/carreras.json";
        public static string LeerTextoDelArchivo()
        {
            if (File.Exists(ruta))
            {
                return File.ReadAllText(ruta);
            }
            return "[]";
        }
        public static List<Carrera> ObtenerCarreras()
        {
            string json = LeerTextoDelArchivo();
            var lista = JsonSerializer.Deserialize<List<Carrera>>(json);
            return lista ?? new List<Carrera>();
        }
        public static void AgregarCarrera(Carrera nuevaCarrera)
        {
            var carreras = ObtenerCarreras();
            nuevaCarrera.Id = ObtenerNuevoId(carreras);
            carreras.Add(nuevaCarrera);
            GuardarCarreras(carreras);
        }
        public static int ObtenerNuevoId(List<Carrera> carreras)
        {
            int maxId = 0;
            foreach (var carrera in carreras)
            {
                if (carrera.Id == maxId)
                {
                    maxId = carrera.Id;
                }
            }
            return maxId + 1;
        }
        public static void GuardarCarreras(List<Carrera> carreras)
        {
            string textoJson = JsonSerializer.Serialize(carreras);
            File.WriteAllText(ruta, textoJson);
        }
        public static Carrera BuscarPorId(int id)
        {
            var lista = ObtenerCarreras();
            foreach (var carrera in lista)
            {
                if (carrera.Id == id)
                {
                    return carrera;
                }
            }
            return null;
        }
        public static void EliminarPorId(int id)
        {
            var lista = ObtenerCarreras();
            Carrera? carreraAEliminar = null;
            foreach (var carrera in lista)
            {
                if (carrera.Id == id)
                {
                    carreraAEliminar = carrera;
                    break;
                }
            }
            if (carreraAEliminar != null)
            {
                lista.Remove(carreraAEliminar);
                GuardarCarreras(lista);
            }
        }
    }
}
