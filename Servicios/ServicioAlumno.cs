using SistemaAcademico_V2.Models;
using System.Text.Json;

namespace SistemaAcademico_V2.Servicios
{
    public class ServicioAlumno
    {
        private static string ruta = "Data/alumnos.json";
        public static string LeerTextoDelArchivo()
        {
            if (File.Exists(ruta))
            {
                return File.ReadAllText(ruta);
            }
            return "[]";
        }
        public static List<Alumno> ObtenerAlumnos()
        {
            string json = LeerTextoDelArchivo();
            var lista = JsonSerializer.Deserialize<List<Alumno>>(json);
            return lista ?? new List<Alumno>();
        }
        public static void AgregarAlumno(Alumno nuevoAlumno)
        {
            var alumno = ObtenerAlumnos();
            nuevoAlumno.Id = ObtenerNuevoId(alumno);
            alumno.Add(nuevoAlumno);
            GuardarAlumnos(alumno);
        }
        public static int ObtenerNuevoId(List<Alumno> alumnos)
        {
            int maxId = 0;
            foreach (var alumno in alumnos)
            {
                if (alumno.Id == maxId)
                {
                    maxId = alumno.Id;
                }
            }
            return maxId + 1;
        }
        public static void GuardarAlumnos(List<Alumno> alumnos)
        {
            string textoJson = JsonSerializer.Serialize(alumnos);
            File.WriteAllText(ruta, textoJson);
        }
    }
}
