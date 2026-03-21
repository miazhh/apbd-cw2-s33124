namespace apbd_cw2_s33124.Models;

public class Employee(string firstName, string lastName) : User(firstName, lastName)
{
    public override int GetMaxRentalLimit() => 5;
}