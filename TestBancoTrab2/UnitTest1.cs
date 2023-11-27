using Course.Services;

namespace Course.Tests
{
    [TestClass]
    public class ContractServiceTests
    {
        [TestMethod]
        public void ProcessContract_ShouldAddInstallmentsCorrectly()
        {
            // Arrange
            var contract = new Entities.Contract(1, DateTime.Now, 1000);
            var paymentService = new FakeOnlinePaymentService(); 
            var contractService = new ContractService(paymentService);

            // Act
            contractService.ProcessContract(contract, 3);

            // Assert
            Assert.AreEqual(3, contract.Installments.Count);
            
        }
    }

    public class FakeOnlinePaymentService : IOnlinePaymentService
    {
        public double Interest(double amount, int months)
        {
            return 0;
        }

        public double PaymentFee(double amount)
        {
            return 0; 
        }
    }

    [TestClass]
    public class PaypalServiceTests
    {
        [TestMethod]
        public void Interest_ShouldCalculateInterestCorrectly()
        {
            // Arrange
            var paypalService = new PaypalService();

            // Act
            var interest = paypalService.Interest(1000, 3);

            // Assert
            Assert.AreEqual(30, interest); 
        }

        [TestMethod]
        public void PaymentFee_ShouldCalculatePaymentFeeCorrectly()
        {
            // Arrange
            var paypalService = new PaypalService();

            // Act
            var fee = paypalService.PaymentFee(1000);

            // Assert
            Assert.AreEqual(20, fee); 
        }
    }
}
