using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCardWriter.Components
{
    public interface IInsuranceCardWriterService
    {
        Task<InsuranceCardWriterActionResult> WriteDocument(string templateName, InsuranceCardModel model);
    }
}
