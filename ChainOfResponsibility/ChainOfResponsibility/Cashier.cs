using ChainOfResponsibility.DAL;
using ChainOfResponsibility.Models;

namespace ChainOfResponsibility.ChainOfResponsibility
{
    public class Cashier : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context context = new Context();

            if (req.Amount <= 100000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                customerProcess.EmployeeName = "Veznedar - Ayşe Çınar";
                customerProcess.EmployeeDescription = "Para çekme işlemi onaylandı, müşteriye talep ettiği tutar veznedar tarafından ödendi.";

                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                customerProcess.EmployeeName = "Veznedar - Ayşe Çınar";
                customerProcess.EmployeeDescription = "Müşterinin talep ettiği para çekme tutarı veznedarın günlük ödeyebileceği limiti aştığı için ödeme yapılamadı. İşlem şube müdür yardımcısına yönlendirildi.";

                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();

                NextApprover.ProcessRequest(req);
            }
        }
    }
}