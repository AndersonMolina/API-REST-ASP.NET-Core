using Palestras.API.Entities;

namespace Palestras.API.Persistence
{
    public class PalestrasDbContext
    {
        public List<Palestra> Palestras { get; set; }

        public PalestrasDbContext() 
        {
            Palestras = new List<Palestra>();
            
        }

    }
}
