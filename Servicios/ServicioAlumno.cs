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
            foreach (var alumno in lista)
            {
                if (alumno.Id == id)
                {
                    return alumno;
                }
            }
            return null;
        }
        public static void EliminarPorId(int id)
        {
            var lista = ObtenerAlumnos();
            Alumno? alumnoAEliminar = null;
            foreach (var alumno in lista)
            {
                if (alumno.Id == id)
                {
                    alumnoAEliminar = alumno;
                    break;
                }
            }
            if (alumnoAEliminar  != null)
            {
                lista.Remove(alumnoAEliminar);
                GuardarAlumnos(lista);
            }
        }
        public static void EditarAlumno(Alumno alumnoEditado)
        {
            var lista = ObtenerAlumnos();

            foreach (var a in lista)
            {
                if (a.Id == alumnoEditado.Id)
                {
                    a.Nombre = alumnoEditado.Nombre;
                    a.Apellido = alumnoEditado.Apellido;
                    a.Dni = alumnoEditado.Dni;
                    a.Email = alumnoEditado.Email;
                    a.FechaDeNacimiento = alumnoEditado.FechaDeNacimiento;
                    break;
                }
            }
            GuardarAlumnos(lista);
        }
        public static void GuardarAlumnos(List<Alumno> alumnos)
        {
            string textoJson = JsonSerializer.Serialize(alumnos);
            File.WriteAllText(ruta, textoJson);
        }
    }
}
