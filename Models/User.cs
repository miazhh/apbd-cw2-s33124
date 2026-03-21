namespace apbd_cw2_s33124.Models;

public abstract class User(string firstName, string lastName)
{
    private static int _nextId = 1;
    public int Id { get; } = _nextId++;
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;

    public abstract int GetMaxRentalLimit();

}