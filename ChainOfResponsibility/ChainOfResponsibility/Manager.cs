using ChainOfResponsibility.DAL;
using ChainOfResponsibility.Models;

namespace ChainOfResponsibility.ChainOfResponsibility
{
    public class Manager : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context context = new Context();

            if (req.Amount <= 250000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                customerProcess.EmployeeName = "Şube Müdürü - Hatice Sarı";
                customerProcess.EmployeeDescription = "Para çekme işlemi onaylandı, müşteriye talep ettiği tutar şube müdürü tarafından ödendi.";

                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                customerProcess.EmployeeName = "Şube Müdürü - Hatice Sarı";
                customerProcess.EmployeeDescription = "Müşterinin talep ettiği para çekme tutarı şube müdürünün günlük ödeyebileceği limiti aştığı için ödeme yapılamadı. İşlem bölge müdürüne yönlendirildi.";

                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();

                NextApprover.ProcessRequest(req);
            }
        }
    }
}
