namespace apbd_cw2_s33124.Models;
using apbd_cw2_s33124.Enums;

public abstract class Equipment(string name)
{
    private static int _nextId = 1;
    public int Id { get; } = _nextId++;
    public string Name { get; set; } = name;
    public EquipmentStatus Status { get; set; } = EquipmentStatus.Available;
    
    public bool IsAvailable => Status == EquipmentStatus.Available;
    public override string ToString() => $"[{Id}] {Name} - {Status}";
}