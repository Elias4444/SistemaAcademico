namespace SistemaAcademico_V2.AccesoAdatos
{
    public interface IAccesoDatos <T>
    {
        List<T> Leer();
        void Guardar(List<T> lista);
    }
}
