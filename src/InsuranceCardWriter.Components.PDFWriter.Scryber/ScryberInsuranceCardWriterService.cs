using InsuranceCardWriter.Components;
using Scryber.Components;
using Path = System.IO.Path;

namespace InsuranceCardWriter.Scryber
{
    public class ScryberInsuranceCardWriterService : IInsuranceCardWriterService
    {
        public Task<InsuranceCardWriterActionResult> WriteDocument(string templateName, InsuranceCardModel model)
        {
            var templatePath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Templates\\Scryber", templateName + ".html");
            
            using (var doc = Document.ParseDocument(templatePath))
            {
                doc.Params["model"] = model;

                var relativeOutputDirectory = "Output";
                if (!Directory.Exists(relativeOutputDirectory))
                {
                    Directory.CreateDirectory(relativeOutputDirectory);
                }

                var relativeDocumentDirectory = $"Output\\{model.DocumentId}";
                if (!Directory.Exists(relativeDocumentDirectory))
                {
                    Directory.CreateDirectory(relativeDocumentDirectory);
                }

                //And save it to a file or a stream
                using (var stream = new System.IO.FileStream($"Output\\{model.DocumentId}\\Scryber.{templateName}_{model.DocumentId}.pdf", System.IO.FileMode.Create))
                {
                    doc.SaveAsPDF(stream);
                }
            }

            var result = new InsuranceCardWriterActionResult();
            result.Success = true;

            return Task.FromResult(result);
        }
    }
}
