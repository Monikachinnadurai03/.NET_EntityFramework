using IMS_DBFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace IMS_DBFirst
{
    public class ClientInvestmentDAO
    {
        public void ClientWithClientInvetsment(Client client, ClientInvestment clientInvestment)
        {
            Console.WriteLine($"Adding Client Id {client} with ClientInvestment {clientInvestment}");
            using(var scope = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted}))
            {
                try
                {
                    using (var dbcontext = new EfRefContext())
                    {
                        dbcontext.Clients.Add(client);
                        dbcontext.SaveChanges();

                        clientInvestment.ClientId = client.ClientId;
                        dbcontext.ClientInvestments.Add(clientInvestment);
                        dbcontext.SaveChanges();

                        scope.Complete();
                        Console.WriteLine("Entities are saved....");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error :{ex.Message}");
                }
            }
        }

        public void AddClient()
        {
            Console.WriteLine("Client record is adding......");
            using (var dbcontext = new EfRefContext())
            {
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
                dbcontext.Clients.Add(clientObj);
                dbcontext.SaveChanges();
            }
            Console.WriteLine("Client record is inserted...");

        }

        public void AddClientInvetsment()
        {
            Console.WriteLine("ClientInvestment record is adding......");
            using (var dbcontext = new EfRefContext())
            {
                var clientInvestmentObj = new ClientInvestment()
                {
                    ClientInvestmentId = 10007,
                    ClientId = 7,
                    InvestmentId = 1007,
                    InvestmentAmount = 3400.00m,
                    InvestmentDate = new DateOnly(2023, 05, 30),
                    Quantity = 6,
                    TransactionId = 8007
                };
                dbcontext.Add(clientInvestmentObj);
                dbcontext.SaveChanges();
            }
            Console.WriteLine("Client record is inserted...");

        }


    }
}
