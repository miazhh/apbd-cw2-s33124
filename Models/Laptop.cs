namespace apbd_cw2_s33124.Models;

public class Laptop(string name, string cpu, int  ramGb) : Equipment(name)
{
    public string Cpu { get; set; } = cpu;
    public int RamGb { get; set; } = ramGb;
}