using InsuranceCardWriter;
using Scryber.Components;

//create our sample model data.

//Load your template from a 
var path = System.Environment.CurrentDirectory;
path = System.IO.Path.Combine(path, "../../templates/InsuranceCardTemplate.html");

var inputs = InsuranceCardModel.ReadInsuranceCardDataFromStdin();

var model = new
{
    state = inputs.State,
    primaryNamedInsured = inputs.PrimaryNamedInsured,
    secondaryNamedInsured = inputs.SecondaryNamedInsured,
    policyNumber = inputs.PolicyNumber,
    policyStartDate = inputs.PolicyStartDate,
    policyEndDate = inputs.PolicyEndDate,
    vehicleYear = inputs.VehicleYear,
    vehicleMake = inputs.VehicleMake,
    vehicleVin = inputs.VehicleVin
};

using (var doc = Document.ParseDocument(path))
{
    doc.Params["model"] = model;

    //And save it to a file or a stream
    using (var stream = new System.IO.FileStream("InsuranceCard.pdf", System.IO.FileMode.Create))
    {
        doc.SaveAsPDF(stream);
    }

}