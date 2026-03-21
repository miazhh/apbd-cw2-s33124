namespace apbd_cw2_s33124.Models;

public class Rental(Equipment equipment, User user, DateTime rentalDate, DateTime dueDate)
{
    private static int _nextId = 1;
    public int Id { get; } = _nextId++;
    public Equipment Equipment { get; } = equipment;
    public User User { get; } = user;
    public DateTime RentalDate { get; } =  rentalDate;
    public DateTime DueDate { get; } = dueDate;
    public DateTime? ReturnDate { get; private set; }
    
    public bool IsReturned => ReturnDate.HasValue;
    
    public void MarkAsReturned(DateTime returnDate)
    {
        ReturnDate = returnDate;
        Equipment.Status = Enums.EquipmentStatus.Available;
    }
}