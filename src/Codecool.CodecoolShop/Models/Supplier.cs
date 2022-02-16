namespace Codecool.CodecoolShop.Models
{
    public class Supplier : BaseModel
    {
        public override string ToString()
        {
            return new string($"Id: {Id} Name: {Name} Description: {Description}");
        }
    }
}
