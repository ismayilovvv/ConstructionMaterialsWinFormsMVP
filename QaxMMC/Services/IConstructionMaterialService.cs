using QaxMMC.Models;
using QaxMMC.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaxMMC.Services
{
    public interface IConstructionMaterialService
    {
        ConstructionMaterial CreateConstructionMaterial(CMEventArgs e);
        void DeleteConstructionMaterial(int id);
        void AddConstructionMaterial(ConstructionMaterial constructionMaterial);
        void EditConstructionMaterial(ConstructionMaterial constructionMaterial);
        List<ConstructionMaterial> GetConstructionMaterials();

        Customer CreateCustomer(CEventArgs e);
        void DeleteCustomer(int id);
        void AddCustomer(Customer customer);
        void EditCustomer(Customer customer);
        List<Customer> GetCustomers();

        Sale CreateSale(SEventArgs e);
        void DeleteSale(int id);
        void AddSale(Sale sale);
        void EditSale(Sale sale);
        List<Sale> GetSales();

        Credit CreateCredit(CreEventArgs e);
        void DeleteCredit(int id);
        void AddCredit(Credit credit);
        void EditCredit(Credit credit);
        List<Credit> GetCredits();

        

        void AddDbContext(QaxMMC.EntityFramework.QaxMmcDbContext dbContext);

    }
}
