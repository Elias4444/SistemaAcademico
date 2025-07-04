using SistemaAcademico_V2.Models;

namespace SistemaAcademico_V2.Servicios
{
    public class ServicioAlumno
    {
        private readonly RepositorioCrudJson<Alumno> crud;
        public ServicioAlumno()
        {
            crud = new RepositorioCrudJson<Alumno>("alumnos");
        }
        public List<Alumno> ObtenerTodos()
        {
            return crud.ObtenerTodos();
        }
        public Alumno? BuscarPorId(int id)
        {
            return crud.BuscarPorId(id);
        }
        public void Agregar(Alumno alumno)
        {
            crud.Agregar(alumno);
        }
        public void Editar(Alumno alumno)
        {
            crud.Editar(alumno);
        }
        public void EliminarPorId(int id)
        {
            crud.EliminarPorId(id);
        }
    }
}
