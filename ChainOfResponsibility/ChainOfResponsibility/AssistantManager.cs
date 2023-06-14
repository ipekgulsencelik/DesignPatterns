using ChainOfResponsibility.DAL;
using ChainOfResponsibility.Models;

namespace ChainOfResponsibility.ChainOfResponsibility
{
    public class AssistantManager : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context context = new Context();

            if (req.Amount <= 150000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                customerProcess.EmployeeName = "Şube Müdür Yardımcısı - Melike Öztürk";
                customerProcess.EmployeeDescription = "Para çekme işlemi onaylandı, müşteriye talep ettiği tutar şube müdür yardımcısı tarafından ödendi.";

                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                customerProcess.EmployeeName = "Şube Müdür Yardımcısı - Melike Öztürk";
                customerProcess.EmployeeDescription = "Müşterinin talep ettiği para çekme tutarı şube müdür yardımcısının günlük ödeyebileceği limiti aştığı için ödeme yapılamadı. İşlem şube müdürüne yönlendirildi.";

                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();

                NextApprover.ProcessRequest(req);
            }
        }
    }
}