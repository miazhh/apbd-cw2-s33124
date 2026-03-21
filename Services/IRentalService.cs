using apbd_cw2_s33124.Models;

namespace apbd_cw2_s33124.Services;

public interface IRentalService
{
    Rental RentEquipment(User user, Equipment equipment);
    void ReturnEquipment(int rentalId, DateTime returnDate);
    decimal CalculatePenalty(Rental rental);
}