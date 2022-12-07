using InsuranceCardWriter.Components;
using InsuranceCardWriter.Scryber;
using Xunit;

namespace InsuranceCardWriterTests
{
    public class InsuranceCardWriterTests
    {
        [Fact]
        public void ScryberGenerate()
        {
            var model = new InsuranceCardWriter.Components.InsuranceCardModel()
            {
                DocumentId = "ABCD1234",
                PolicyStartDate = "2/1/2022",
                PolicyEndDate = "2/1/2023",
                PolicyNumber = "PolicyId12345",
                PrimaryNamedInsured = "Little Bo Peep",
                SecondaryNamedInsured = "Mary Swanson",
                State = "VA",
                VehicleMake = "Toyota",
                VehicleVin = "83874kj3hf8383f3",
                VehicleYear = "2000",
                PaymentHistory = new List<Payment>()
            };

            var startDate = DateTime.Parse("2022/11/11");
            for (var i = 0; i < 24; i++)
            {
                model.PaymentHistory.Add(new Payment()
                {
                    Id = Guid.NewGuid().ToString(),
                    Amount = 133.23M,
                    DueDate = startDate,
                    PaymentDate = startDate
                });

                startDate = startDate.AddMonths(-1);
            }


            var scryberService = new ScryberInsuranceCardWriterService();
            scryberService.WriteDocument("InsuranceCardTemplate", model);
        }
    }
}