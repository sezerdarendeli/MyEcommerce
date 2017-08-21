using MyECommerce.Entities.Concrete;

namespace MyECommerce.Entities.ComlexTypes
{
    public class UserSession
    {
        public int BasketId { get; set; }

        public int SelectedAddresId { get; set; }

        public Users User { get; set; }
    }
}
