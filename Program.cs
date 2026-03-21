using apbd_cw2_s33124.Models;
using apbd_cw2_s33124.Services;
using apbd_cw2_s33124.Exceptions;

var rentalService = new RentalService();

var student = new Student("Hubert", "Miaz");
var laptop = new Laptop("MacBook Air", "M2", 16);
var tablet = new Tablet("iPad Pro", 12.9, 8);
var headphones = new Headphones("Sony XM5", "USB-C", true);

Console.WriteLine($"Użytkownik: {student.FirstName} {student.LastName} Limit: {student.GetMaxRentalLimit()}");

try
{
    Console.WriteLine("Wypożyczenie sprzętu");
    rentalService.RentEquipment(student, laptop);
    Console.WriteLine($"Wypożyczono: {laptop.Name}");

    rentalService.RentEquipment(student, tablet);
    Console.WriteLine($"Wypożyczono: {tablet.Name}");

    Console.WriteLine("Próba 3 wypożyczenia");
    rentalService.RentEquipment(student, headphones);

}
catch (RentalLimitExceededException e)
{
    Console.WriteLine(e.Message);
}catch(Exception e)
{
    Console.WriteLine(e.Message);
}

Console.WriteLine("Test kar");
var lateRental = new Rental(laptop, student, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-3));
lateRental.MarkAsReturned(DateTime.Now);

decimal penalty = rentalService.CalculatePenalty(lateRental);
Console.WriteLine($"Penalty: {penalty}");