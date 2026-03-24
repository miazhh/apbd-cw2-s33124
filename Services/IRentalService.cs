using apbd_cw2_s33124.Models;

namespace apbd_cw2_s33124.Services;

public interface IRentalService
{
    void AddUser(User user);
    void AddEquipment(Equipment equipment);
    void SetEquipmentStatus(int equipmentId, apbd_cw2_s33124.Enums.EquipmentStatus status);
    
    Rental RentEquipment(User user, Equipment equipment);
    void ReturnEquipment(int rentalId, DateTime returnDate);
    decimal CalculatePenalty(Rental rental);

    List<Equipment> GetAllEquipment();
    List<Equipment> GetAvailableEquipment();
    List<Rental> GetActiveRentalsForUser(int userId);
    List<Rental> GetRentalsForUser(int userId);
    List<Rental> GetOverdueRentals();
    void DisplaySummaryReport();
}