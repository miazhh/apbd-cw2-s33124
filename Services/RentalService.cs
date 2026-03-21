using apbd_cw2_s33124.Enums;
using apbd_cw2_s33124.Exceptions;
using apbd_cw2_s33124.Models;

namespace apbd_cw2_s33124.Services;

public class RentalService: IRentalService
{
    private readonly List<Rental> _rentals = new ();

    public Rental RentEquipment(User user, Equipment equipment)
    {
        if (equipment.Status != EquipmentStatus.Available)
            throw new EquipmentNotAvailableException(
                $"Sprzęt {equipment.Name} jest niedostępny. Status: {equipment.Status}.");

        var activeRentalsCount = _rentals.Count(r => r.User.Id == user.Id && !r.IsReturned);
        if (activeRentalsCount >= user.GetMaxRentalLimit())
            throw new RentalLimitExceededException(
                $"Użytkownik {user.FirstName} przekroczył limit {user.GetMaxRentalLimit()} wypożyczeń");

        var rental = new Rental(equipment, user, DateTime.Now, DateTime.Now.AddDays(7));
        equipment.Status = EquipmentStatus.Rented;
        _rentals.Add(rental);
        return rental;
    }

    public void ReturnEquipment(int rentalId, DateTime returnDate)
    {
        var rental = _rentals.FirstOrDefault(r => r.Id == rentalId);
        if (rental == null)
            throw new RentalNotFoundException($"Nie znaleziono wypożyczenia o ID {rentalId}");
        rental.MarkAsReturned(returnDate);
    }

    public decimal CalculatePenalty(Rental rental)
    {
        if(!rental.IsReturned || rental.ReturnDate <= rental.DueDate)
            return 0;

        var delay = (rental.ReturnDate.Value - rental.DueDate).Days;
        return delay*10.0m;
    }
}