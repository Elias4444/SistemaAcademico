using SistemaAcademico_V2.Models;

namespace SistemaAcademico_V2.Servicios
{
    public class ServicioCarrera
    {
        private readonly RepositorioCrudJson<Carrera> crud;
        public ServicioCarrera()
        {
            crud = new RepositorioCrudJson<Carrera>("carreras");
        }
        public List<Carrera> ObtenerTodos()
        {
            return crud.ObtenerTodos();
        }
        public Carrera? BuscarPorId(int id)
        {
            return crud.BuscarPorId(id);
        }
        public void Agregar(Carrera carrera)
        {
            crud.Agregar(carrera);
        }
        public void Editar(Carrera carrera)
        {
            crud.Editar(carrera);
        }
        public void EliminarPorId(int id)
        {
            crud.EliminarPorId(id);
        }
    }
}
