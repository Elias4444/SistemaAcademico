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
        public static Alumno? BuscarPorId(int id)
        {
            var lista = ObtenerAlumnos();
            return BuscarAlumnoPorId(lista, id);
        }
        public static void EliminarPorId(int id)
        {
            var lista = ObtenerAlumnos();
            var alumnoAEliminar = BuscarAlumnoPorId(lista, id);
            
            if (alumnoAEliminar  != null)
            {
                lista.Remove(alumnoAEliminar);
                GuardarAlumnos(lista);
            }
        }
        public static void EditarAlumno(Alumno alumnoEditado)
        {
            var lista = ObtenerAlumnos();
            var alumno = BuscarAlumnoPorId(lista, alumnoEditado.Id);
            if (alumno != null)
            {
                alumno.Nombre = alumnoEditado.Nombre;
                alumno.Apellido = alumnoEditado.Apellido;
                alumno.Dni = alumnoEditado.Dni;
                alumno.Email = alumnoEditado.Email;
                alumno.FechaDeNacimiento = alumnoEditado.FechaDeNacimiento;

                GuardarAlumnos(lista);
            }
        }
        public static void GuardarAlumnos(List<Alumno> alumnos)
        {
            string textoJson = JsonSerializer.Serialize(alumnos);
            File.WriteAllText(ruta, textoJson);
        }
        private static Alumno? BuscarAlumnoPorId(List<Alumno> lista, int id)
        {
            foreach (var alumno in lista)
            {
                if (alumno.Id == id)
                {
                    return alumno;
                }
            }
            return null;
        }
    }
}
