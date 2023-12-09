namespace estimatesvc;

public class Estimate
{
    // public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    public int? CreateYear { get; set; }
    public String? Email { get; set; }
    public String? InsuranceType { get; set; }
    public String? ItemDesc { get; set; }
    public String? ItemName { get; set; }
    public String? Name { get; set; }
    public String? PreviousInsurer { get; set; }
    public decimal ItemValue { get; set; }
    public int? MFREF { get; set; }
    public String? Status { get; set; }
    public String? CustRef { get; set; }
    public DateTime? CreateTime { get; set; }
    public DateTime? UpdateTime { get; set; }
    public decimal? PolicyEstimate { get; set; }
    public string? Messages { get; set; }
}