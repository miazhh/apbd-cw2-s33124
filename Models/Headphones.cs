namespace apbd_cw2_s33124.Models;

public class Headphones(string name, string connectorType, bool isWireless) : Equipment(name)
{
    public string ConnectorType { get; set; } = connectorType;
    public bool IsWireless { get; set; } = isWireless;
}