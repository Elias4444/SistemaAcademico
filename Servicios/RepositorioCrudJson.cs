using System.Text.Json;

namespace SistemaAcademico_V2.Servicios
{
    public class RepositorioCrudJson <T> where T : class
    {
        private string ruta;
        public RepositorioCrudJson(string nombreArchivo)
        {
            ruta = $"Data/{nombreArchivo}.json";
        }

        //Metodos sin reflexion
        public string LeerTextoDelArchivo()
        {
            if (File.Exists(ruta))
            {
                return File.ReadAllText(ruta);
            }
            return "[]";
        }
        public List<T> ObtenerTodos()
        {
            string json = LeerTextoDelArchivo();
            var lista = JsonSerializer.Deserialize<List<T>>(json);
            return lista ?? new List<T>();
        }
        public void Guardar(List<T> lista)
        {
            string json = JsonSerializer.Serialize(lista);
            File.WriteAllText(ruta, json);
        }

        //Metodos con reflexion
        public int ObtenerNuevoId(List<T> lista)
        {
            int maxId = 0;
            foreach (var item in lista)
            {
                var propiedadId = typeof(T).GetProperty("Id");
                int id = (int)propiedadId.GetValue(item);

                if (id > maxId)
                {
                    maxId = id;
                }
            }
            return maxId + 1;
        }

        public void Agregar(T entidad)
        {
            var lista = ObtenerTodos();
            int nuevoId = ObtenerNuevoId(lista);

            var propiedadId = typeof(T).GetProperty("Id");
            propiedadId.SetValue(entidad, nuevoId);

            lista.Add(entidad);
            Guardar(lista);
        }

        private T? BuscarEnListaPorId(List<T> lista, int id)
        {
            var propiedadId = typeof(T).GetProperty("Id");

            foreach (var item in lista)
            {
                int valorId = (int)propiedadId?.GetValue(item);
                if (valorId == id)
                {
                    return item;
                }
            }
            return null;
        }
        public T BuscarPorId(int id)
        {
            var lista = ObtenerTodos();
            return BuscarEnListaPorId(lista, id);
        }
        public void EliminarPorId(int id)
        {
            var lista = ObtenerTodos();
            T? entidad = BuscarEnListaPorId(lista, id);

            if (entidad != null)
            {
                lista.Remove(entidad);
                Guardar(lista);
            }

        }
        public void Editar(T entidadNueva)
        {
            var lista = ObtenerTodos();
            var propiedadId = typeof(T).GetProperty("Id");
            int id = (int)propiedadId.GetValue(entidadNueva);

            var entidadExistente = BuscarEnListaPorId(lista, id);

            if (entidadExistente != null)
            {
                ActualizarPropiedades(entidadExistente, entidadNueva);
                Guardar(lista);
            }
        }
        private void ActualizarPropiedades(T entidadExistente, T entidadNueva)
        {
            var propiedades = typeof(T).GetProperties();

            foreach (var propiedad in propiedades)
            {
                if (propiedad.Name == "Id") continue;

                var nuevoValor = propiedad.GetValue(entidadNueva);
                propiedad.SetValue(entidadExistente, nuevoValor);
            }
        }
    }
}
