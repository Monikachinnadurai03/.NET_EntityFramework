using Microsoft.EntityFrameworkCore;
using IMS_DBFirst.Models;
using IMS_DBFirst.Migrations;

namespace IMS_DBFirst
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            var investmentDAO = new InvestmentDAO();
            //investmentDAO.AddInvestment();
            //investmentDAO.GetInvestmentById(1005);
            //investmentDAO.GetAllInvestments();
            //investmentDAO.RemoveInvestment(1007);
            investmentDAO.GetAllInvestmentsWithLazyLoading();
            //investmentDAO.GetInvestmentsByFilter(50, 3000);
            //investmentDAO.GetAllInvestmentsWithTypes();
            //investmentDAO.GetAllInvestmentsWithTypesEagerLoading();


            // Transaction
            var clientInvestmentDAO = new ClientInvestmentDAO();

            var clientObj = new Client()
            {
                ClientId = 1007,
                FirstName = "Gopi",
                LastName = "Krishna",
                Email = "gopikrishna@gmail.com",
                PhoneNumber = "1234567891",
                BirthDate = new DateOnly(2003, 03, 07),
                RegistrationDate = new DateOnly(2024, 3, 7),
                Occupation = "Software Engineer",
                StreetName = "MGR",
                CityId = 505,
                StateId = 5005,
                Country = "India",
                PanCardNo = "FGHIJ5467U"
            };

            var clientInvestmentObj = new ClientInvestment()
            {
                ClientInvestmentId = 10007,
                ClientId = 7,
                InvestmentId = 1006,
                InvestmentAmount = 50.50m,
                InvestmentDate = new DateOnly(2022, 06, 30),
                Quantity = 6,
                TransactionId = 8006
            };
            //clientInvestmentDAO.ClientWithClientInvetsment(clientObj, clientInvestmentObj);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}