namespace apbd_cw2_s33124.Models;

public class Tablet(string name, double inchSize, int ramGb) : Equipment(name)
{
    public double inchSize {get; set;} = inchSize;
    public double ramGb {get; set;} = ramGb;
}