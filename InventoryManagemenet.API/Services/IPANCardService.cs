namespace InventoryManagemenet.API.Services
{
    public interface IPANCardService
    {
        string GeneratePAN();

        bool IsValidPAN(string pan);
    }
}
