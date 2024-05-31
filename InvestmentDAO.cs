using IMS_DBFirst.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS_DBFirst
{
    public class InvestmentDAO
    {
        public void AddInvetsment()
        {
            Console.WriteLine("Investment record is adding......");
            using (var dbcontext = new EfRefContext())
            {
                var investmentObj = new Investment()
                {
                    InvestmentId = 1007,
                    Name = "VTSAX",
                    PurchaseDate = new DateOnly(2024, 3, 7),
                    PurchasePrice = 1000.00m,
                    InvestmentTypeId = 106
                };
                dbcontext.Investments.Add(investmentObj);
                dbcontext.SaveChanges();
            }
            Console.WriteLine("Investment record  is inserted...");
        }

        public void GetInvestmentById(int id)
        {
            Console.WriteLine($"Investment record{id} is fetching.....");
            using (var dbcontext = new EfRefContext())
            {

                var investment = dbcontext.Investments.FirstOrDefault(i => i.InvestmentId == id);
                if (investment != null)
                {
                    // Print the details of the fetched investment record
                    Console.WriteLine($"Investment ID: {investment.InvestmentId}");
                    Console.WriteLine($"Name: {investment.Name}");
                    Console.WriteLine($"Purchase Date: {investment.PurchaseDate}");
                    Console.WriteLine($"Purchase Price: {investment.PurchasePrice}");
                    Console.WriteLine($"Investment Type ID: {investment.InvestmentTypeId}");
                }
                else
                {
                    Console.WriteLine("Investment not found.");
                }
                dbcontext.SaveChanges();


            }
            Console.WriteLine($"Investment record{id} is fetched...");
        }

        public void GetAllInvestments()
        {
            Console.WriteLine("All Investments are fetching.....");
            using (var dbcontext = new EfRefContext())
            {
                //var investments = investmentDAO.GetAllInvestments();
                var investments = dbcontext.Investments.ToList();
                // Print the details of all fetched investment records
                foreach (var investment in investments)
                {
                    Console.WriteLine($"Investment ID:      {investment.InvestmentId}");
                    Console.WriteLine($"Name:               {investment.Name}");
                    Console.WriteLine($"Purchase Date:      {investment.PurchaseDate}");
                    Console.WriteLine($"Purchase Price:     {investment.PurchasePrice}");
                    Console.WriteLine($"Investment Type ID: {investment.InvestmentTypeId}");
                    Console.WriteLine("---------------------------------------------------------------------------");
                }
                dbcontext.SaveChanges();
            }
            Console.WriteLine("All Investments are fetched.....");

        }

        public void RemoveInvestment(int id)
        {
            Console.WriteLine($"Deleting a record {id}....");
            using (var dbcontext = new EfRefContext())
            {
                // Retrieve the investment record to be deleted
                var investment = dbcontext.Investments.FirstOrDefault(i => i.InvestmentId == id);

                if (investment != null)
                {
                    // Remove the investment record from the DbSet
                    dbcontext.Investments.Remove(investment);

                    // Save changes to commit the deletion
                    dbcontext.SaveChanges();

                    Console.WriteLine($"Investment record {id} deleted successfully.");
                }
                else
                {
                    Console.WriteLine($"Investment record {id} not found.");
                }

            }
        }

        public void GetAllInvestmentsWithLazyLoading()
        {
            Console.WriteLine("Fetching all investments with lazy loading-like behavior.....");
            using (var dbcontext = new EfRefContext())
            {
                var investments = dbcontext.Investments.ToList();
                // Explicitly load related entities (InvestmentType) for each investment record
                foreach (var investment in investments)
                {
                    dbcontext.Entry(investment).Reference(i => i.InvestmentType).Load();
                }

                // Print the details of all fetched investment records along with related entities
                foreach (var investment in investments)
                {
                    Console.WriteLine($"Investment ID:      {investment.InvestmentId}");
                    Console.WriteLine($"Name:               {investment.Name}");
                    Console.WriteLine($"Purchase Date:      {investment.PurchaseDate}");
                    Console.WriteLine($"Purchase Price:     {investment.PurchasePrice}");
                    Console.WriteLine($"Investment Type:    {investment.InvestmentType?.Type}");
                    Console.WriteLine("---------------------------------------------------------------------------");

                }

                Console.WriteLine("All investments with lazy loading fetched successfully.");

            }

        }

        public void GetInvestmentsByFilter(decimal minPrice, decimal maxPrice)
        {
            Console.WriteLine($"Fetching investment records with purchase price between {minPrice} and {maxPrice}.....");
            using (var dbcontext = new EfRefContext())
            {
                // Fetch investment records based on the filter criteria
                var investments = dbcontext.Investments
                    .Where(i => i.PurchasePrice >= minPrice && i.PurchasePrice <= maxPrice)
                    .ToList();

                // Print the details of fetched investment records
                foreach (var investment in investments)
                {
                    Console.WriteLine($"Investment ID:      {investment.InvestmentId}");
                    Console.WriteLine($"Name:               {investment.Name}");
                    Console.WriteLine($"Purchase Date:      {investment.PurchaseDate}");
                    Console.WriteLine($"Purchase Price:     {investment.PurchasePrice}");
                    Console.WriteLine($"Investment Type ID: {investment.InvestmentTypeId}");
                    Console.WriteLine("---------------------------------------------------------------------------");
                }

                Console.WriteLine($"Total {investments.Count} investment records fetched based on filter criteria.");
            }
        }

        public void GetAllInvestmentsWithTypes()
        {
            Console.WriteLine("Fetching all investments with corresponding investment types.....");
            using(var dbcontext = new EfRefContext())
            {
                var investmentsWithTypes = from investment in dbcontext.Investments
                                           join investmentType in dbcontext.InvestmentTypes
                                           on investment.InvestmentTypeId equals investmentType.InvestmentTypeId
                                           select new
                                           {
                                               InvestmentId = investment.InvestmentId,
                                               Name = investment.Name,
                                               PurchaseDate = investment.PurchaseDate,
                                               PurchasePrice = investment.PurchasePrice,
                                               InvestmentTypeName = investmentType.Type
                                           };

                // Print the details of fetched investment records with investment types
                foreach (var record in investmentsWithTypes)
                {
                    Console.WriteLine($"Investment ID:      {record.InvestmentId}");
                    Console.WriteLine($"Name:               {record.Name}");
                    Console.WriteLine($"Purchase Date:      {record.PurchaseDate}");
                    Console.WriteLine($"Purchase Price:     {record.PurchasePrice}");
                    Console.WriteLine($"Investment Type:    {record.InvestmentTypeName}");
                    Console.WriteLine("---------------------------------------------------------------------------");
                }

                Console.WriteLine("All investments with corresponding investment types are fetched.");
            }
        }

        public void GetAllInvestmentsWithTypesEagerLoading()
        {
            Console.WriteLine("Fetching all investments with corresponding investment types (Eager Loading).....");

            using( var dbcontext = new EfRefContext())
            {
                var investmentsWithTypes = dbcontext.Investments
        .Include(i => i.InvestmentType)
        .Select(i => new
        {
            InvestmentId = i.InvestmentId,
            Name = i.Name,
            PurchaseDate = i.PurchaseDate,
            PurchasePrice = i.PurchasePrice,
            InvestmentTypeName = i.InvestmentType.Type
        })
        .ToList();

                // Print the details of fetched investment records with investment types
                foreach (var record in investmentsWithTypes)
                {
                    Console.WriteLine($"Investment ID:      {record.InvestmentId}");
                    Console.WriteLine($"Name:               {record.Name}");
                    Console.WriteLine($"Purchase Date:      {record.PurchaseDate}");
                    Console.WriteLine($"Purchase Price:     {record.PurchasePrice}");
                    Console.WriteLine($"Investment Type:    {record.InvestmentTypeName}");
                    Console.WriteLine("---------------------------------------------------------------------------");
                }

                Console.WriteLine("All investments with corresponding investment types are fetched (Eager Loading).");

            }
        }



        }
    }
