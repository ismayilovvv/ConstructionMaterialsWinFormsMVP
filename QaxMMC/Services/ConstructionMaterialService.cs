using QaxMMC.EntityFramework;
using QaxMMC.Models;
using QaxMMC.Views;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaxMMC.Services
{
    public class ConstructionMaterialService : IConstructionMaterialService
    {
        private QaxMmcDbContext qaxMmcDbContext;

        public void AddConstructionMaterial(ConstructionMaterial constructionMaterial)
        {
            qaxMmcDbContext.ConstructionMaterials.Add(constructionMaterial);
            qaxMmcDbContext.SaveChanges();
        }

        public void AddCredit(Credit credit)
        {
            qaxMmcDbContext.Sales.Add(credit.sale);
            qaxMmcDbContext.SaveChanges();
            var sale = qaxMmcDbContext.Sales.ToList().Last();
            qaxMmcDbContext.Database.ExecuteSqlCommand($"insert into Credits(customer_Id, sale_Id) values({credit.customer.Id}, {sale.Id})");
            qaxMmcDbContext.SaveChanges();
        }

        public void AddCustomer(Customer customer)
        {
           qaxMmcDbContext.Customers.Add(customer);
            qaxMmcDbContext.SaveChanges();
        }

        public void AddDbContext(QaxMmcDbContext dbContext)
        {
            qaxMmcDbContext = dbContext;
        }

        public void AddSale(Sale sale)
        {
           qaxMmcDbContext.Sales.Add(sale);
            qaxMmcDbContext.SaveChanges();
        }

        public ConstructionMaterial CreateConstructionMaterial( CMEventArgs e )
        {
            ConstructionMaterial constructionMaterial = new ConstructionMaterial();
            constructionMaterial.Id = e.constructionMaterial.Id;
            constructionMaterial.Ad = e.constructionMaterial.Ad;
            constructionMaterial.En = e.constructionMaterial.En;
            constructionMaterial.Uzunluq = e.constructionMaterial.Uzunluq;
            constructionMaterial.Hundurluk = e.constructionMaterial.Hundurluk;
            constructionMaterial.Eded = e.constructionMaterial.Eded;
            constructionMaterial.Kub = e.constructionMaterial.Kub;
            constructionMaterial.Kvadrat = e.constructionMaterial.Kvadrat;
            constructionMaterial.Nomre = e.constructionMaterial.Nomre;
            constructionMaterial.Nov = e.constructionMaterial.Nov;
            constructionMaterial.date = e.constructionMaterial.date;
            constructionMaterial.Mebleg = e.constructionMaterial.Mebleg;
            return constructionMaterial;
        }

        public Credit CreateCredit(CreEventArgs e)
        {
            Credit credit = new Credit();
            credit.Id = e.credit.Id;
            credit.customer = new Customer();
            credit.customer = qaxMmcDbContext.Customers.Find(e.credit.customer.Id);
            credit.sale = new Sale();
            credit.sale.Id = e.credit.sale.Id;
            credit.sale.saleDate = e.credit.sale.saleDate;
            credit.sale.sum = e.credit.sale.sum;
            credit.sale.Ad = e.credit.sale.Ad;
            credit.sale.En = e.credit.sale.En;
            credit.sale.Uzunluq = e.credit.sale.Uzunluq;
            credit.sale.Hundurluk = e.credit.sale.Hundurluk;
            credit.sale.Miqdar = e.credit.sale.Miqdar;
            credit.sale.Kub = e.credit.sale.Kub;
            credit.sale.Kvadrat = e.credit.sale.Kvadrat;
            credit.sale.Nomre = e.credit.sale.Nomre;
            credit.sale.Nov = e.credit.sale.Nov;
            return credit;

        }

        public Customer CreateCustomer(CEventArgs e)
        {
            Customer customer = new Customer();
            customer.Id = e.customer.Id;
            customer.Name = e.customer.Name;
            customer.Surname = e.customer.Surname;
            customer.Lastname = e.customer.Lastname;
            customer.Birthdate = e.customer.Birthdate;
            customer.BornAddress = e.customer.BornAddress;
            customer.PassportSeriaNumber = e.customer.PassportSeriaNumber;
            customer.PassportFIN = e.customer.PassportFIN;
            customer.RegisterAddress = e.customer.RegisterAddress;
            customer.Phone1 = e.customer.Phone1;
            customer.Phone2 = e.customer.Phone2;
            customer.Company = e.customer.Company;
            customer.CompanyAddress = e.customer.CompanyAddress;
            customer.Bank = e.customer.Bank;
            customer.AccountNumber = e.customer.AccountNumber;
            customer.Account = e.customer.Account;
            customer.VOEN = e.customer.VOEN;
            customer.Code = e.customer.Code;
            customer.Swift = e.customer.Swift;
            customer.CreatedDate = e.customer.CreatedDate;
            return customer;
        }

        public Sale CreateSale(SEventArgs e)
        {
            Sale sale = new Sale();
            sale.Id = e.sale.Id;
            sale.saleDate = e.sale.saleDate;
            sale.sum = e.sale.sum;
            sale.Ad = e.sale.Ad;
            sale.Uzunluq = e.sale.Uzunluq;
            sale.Hundurluk = e.sale.Hundurluk;
            sale.En = e.sale.En;
            sale.Miqdar = e.sale.Miqdar;
            sale.Kub = e.sale.Kub;
            sale.Kvadrat = e.sale.Kvadrat;
            sale.Nomre = e.sale.Nomre;
            sale.Nov = e.sale.Nov;
            return sale;
        }

        
        public void DeleteConstructionMaterial(int id)
        {
            var cm = qaxMmcDbContext.ConstructionMaterials.Find(id);
            if(cm != null)
            {
                qaxMmcDbContext.ConstructionMaterials.Attach(cm);
                qaxMmcDbContext.ConstructionMaterials.Remove(cm);
                qaxMmcDbContext.SaveChanges();
            }
            
        }

        public void DeleteCredit(int id)
        {
            var cre = qaxMmcDbContext.Credits.Find(id);
            if (cre != null)
            {
                qaxMmcDbContext.Credits.Attach(cre);
                qaxMmcDbContext.Credits.Remove(cre);
                qaxMmcDbContext.SaveChanges();
            }
        }

        public void DeleteCustomer(int id)
        {
            var cus = qaxMmcDbContext.Customers.Find(id);
            if (cus != null)
            {
                qaxMmcDbContext.Customers.Attach(cus);
                qaxMmcDbContext.Customers.Remove(cus);
                qaxMmcDbContext.SaveChanges();
            }
        }

        public void DeleteSale(int id)
        {
            var sale = qaxMmcDbContext.Sales.Find(id);
            if (sale != null)
            {
                qaxMmcDbContext.Sales.Attach(sale);
                qaxMmcDbContext.Sales.Remove(sale);
                try
                {
                    qaxMmcDbContext.SaveChanges();
                }
                catch (Exception)
                {

                    System.Windows.Forms.MessageBox.Show("Nisyəni silmədən satışı silmək olmaz!", "Xəta!",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    return;
                }
                
            }
        }

        public void EditConstructionMaterial(ConstructionMaterial constructionMaterial)
        {
            var data = qaxMmcDbContext.ConstructionMaterials.Where(c => c.Id == constructionMaterial.Id).FirstOrDefault();
            data.Ad = constructionMaterial.Ad;
            data.En = constructionMaterial.En;
            data.Uzunluq = constructionMaterial.Uzunluq;
            data.Hundurluk = constructionMaterial.Hundurluk;
            data.Eded = constructionMaterial.Eded;
            data.Kub = constructionMaterial.Kub;
            data.Kvadrat = constructionMaterial.Kvadrat;
            data.Nomre = constructionMaterial.Nomre;
            data.Nov = constructionMaterial.Nov;
            data.date = constructionMaterial.date;
            data.Mebleg = constructionMaterial.Mebleg;
            qaxMmcDbContext.SaveChanges();

        }

        public void EditCredit(Credit credit)
        {
            var data = qaxMmcDbContext.Credits.Where(cr => cr.Id == credit.Id).FirstOrDefault();
            data.customer.Id = credit.customer.Id;
            data.sale.Id = credit.sale.Id;
            qaxMmcDbContext.SaveChanges();
        }

        public void EditCustomer(Customer customer)
        {
            var data =qaxMmcDbContext.Customers.Where(cus => cus.Id == customer.Id).FirstOrDefault();
            data.Account = customer.Account;
            data.AccountNumber = customer.AccountNumber;
            data.Bank = data.Bank;
            data.Birthdate = data.Birthdate;
            data.BornAddress = customer.BornAddress;
            data.Code = customer.Code;
            data.Company = customer.Company;
            data.CompanyAddress = customer.CompanyAddress;
            data.Lastname = customer.Lastname;
            data.Name = customer.Name;
            data.PassportFIN = customer.PassportFIN;
            data.PassportSeriaNumber = customer.PassportSeriaNumber;
            data.Phone1 = customer.Phone1;
            data.Phone2 = customer.Phone2;
            data.RegisterAddress = customer.RegisterAddress;
            data.Surname = customer.Surname;
            data.Swift = customer.Swift;
            data.VOEN = customer.VOEN;
            qaxMmcDbContext.SaveChanges();
        }

        public void EditSale(Sale sale)
        {
            var data = qaxMmcDbContext.Sales.Where(s => s.Id == sale.Id).FirstOrDefault();
            data.Ad = sale.Ad;
            data.En = sale.En;
            data.Hundurluk = sale.Hundurluk;
            data.Kub = sale.Kub;
            data.Kvadrat = sale.Kvadrat;
            data.Miqdar = sale.Miqdar;
            data.Nomre = sale.Nomre;
            data.Nov = sale.Nov;
            data.saleDate = sale.saleDate;
            data.sum = sale.sum;
            data.Uzunluq = sale.Uzunluq;
            qaxMmcDbContext.SaveChanges();
        }

        public List<ConstructionMaterial> GetConstructionMaterials()
        {
            List<ConstructionMaterial> constructionMaterials = qaxMmcDbContext.ConstructionMaterials.ToList();
            return constructionMaterials;
        }

        

        public List<Credit> GetCredits()
        {
            List<Credit> credits = new List<Credit>();
            credits = qaxMmcDbContext.Credits.ToList();


            return credits;
        }

        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();
            customers = qaxMmcDbContext.Customers.ToList();

            return customers;
        }

        public List<Sale> GetSales()
        {
            List<Sale> sales = new List<Sale>();
            sales = qaxMmcDbContext.Sales.ToList();

            return sales;
        }

        
    }
}
