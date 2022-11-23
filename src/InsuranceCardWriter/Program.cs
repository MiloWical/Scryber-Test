using InsuranceCardWriter.Components;
using Scryber.Components;

//create our sample model data.

//Load your template from a 
var path = System.Environment.CurrentDirectory;
path = System.IO.Path.Combine(path, "../../templates/InsuranceCardTemplate.html");

var model = InsuranceCardModel.ReadInsuranceCardDataFromStdin();

using (var doc = Document.ParseDocument(path))
{
    doc.Params["model"] = model;

    //And save it to a file or a stream
    using (var stream = new System.IO.FileStream("InsuranceCard.pdf", System.IO.FileMode.Create))
    {
        doc.SaveAsPDF(stream);
    }

}