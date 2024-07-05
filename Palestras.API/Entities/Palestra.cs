using System.Reflection;

namespace Palestras.API.Entities
{
    public class Palestra
    {
        public Palestra()
        {
            Palestrantes = new List<PalestraPalestrante>();
            IsDeleted = false;
        }

        public Guid Id { get; set; }

        public string Titulo { get; set; }

        public string Descricao {  get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataTermino { get; set; }

        public List<PalestraPalestrante> Palestrantes { get; set; }

        public bool IsDeleted { get; set; }    

        public void Update (string titulo, string descricao, DateTime dataInicio, DateTime dataTermino)
        {
            Titulo = titulo;
            Descricao = descricao;
            DataInicio = dataInicio;
            DataTermino = dataTermino;

        }

        public void Delete() 
        {
            IsDeleted = true;
        }

        

        
    }
}
