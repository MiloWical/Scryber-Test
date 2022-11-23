namespace InsuranceCardWriter.Components;

public class InsuranceCardModel
{
  public string? State { get; set; }
  public string? PrimaryNamedInsured { get; set; }
  public string? SecondaryNamedInsured { get; set; }
  public string? PolicyNumber { get; set; }
  public string? PolicyStartDate { get; set; }
  public string? PolicyEndDate { get; set; }
  public string? VehicleYear { get; set; }
  public string? VehicleMake { get; set; }
  public string? VehicleVin { get; set; }

  public static InsuranceCardModel ReadInsuranceCardDataFromStdin()
  {
    var model = new InsuranceCardModel();

    Console.Write("State: ");
    model.State = Console.ReadLine()!;

    Console.Write("Primary Named Insured: ");
    model.PrimaryNamedInsured = Console.ReadLine()!;

    Console.Write("Secondary Named Insured (press Enter for none): ");
    model.SecondaryNamedInsured = Console.ReadLine() ?? string.Empty;

    Console.Write("Policy Number: ");
    model.PolicyNumber = Console.ReadLine()!;

    Console.Write("Policy Start Date: ");
    model.PolicyStartDate = Console.ReadLine()!;

    Console.Write("Policy End Date: ");
    model.PolicyEndDate = Console.ReadLine()!;

    Console.Write("Vehicle Year: ");
    model.VehicleYear = Console.ReadLine()!;

    Console.Write("Vehicle Make: ");
    model.VehicleMake = Console.ReadLine()!;

    Console.Write("Vehicle VIN: ");
    model.VehicleVin = Console.ReadLine()!;

    return model;
  }
}