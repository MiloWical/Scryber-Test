using Scryber.Components;

//create our sample model data.

//Load your template from a 
var path = System.Environment.CurrentDirectory;
path = System.IO.Path.Combine(path, "../../templates/SampleTemplate.html");


var model = new
{
    titlestyle = "color:#ff6347",
    title = "Hello from scryber",
    items = new[]
    {
        new { name = "First item" },
        new { name = "Second item" },
        new { name = "Third item" },
    }
};

using (var doc = Document.ParseDocument(path))
{
    //pass values to the document, including css using params

    doc.Params["author"] = "Scryber Engine";
    doc.Params["--head-bg"] = "#333"; //Override for the header background
    doc.Params["--head-txt"] = "#FFF";
    
    //pass data paramters as needed, supporting simple values, arrays or complex classes.

    doc.Params["model"] = model;

    //And save it to a file or a stream
    using (var stream = new System.IO.FileStream("SampleDocument.pdf", System.IO.FileMode.Create))
    {
        doc.SaveAsPDF(stream);
    }

}