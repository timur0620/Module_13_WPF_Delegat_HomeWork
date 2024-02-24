using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_13_WPF_Delegat_HomeWork.BackEnd
{
    class DepositAccount : StandartAccount
    {  
        public DepositAccount() : this(0, 0, 0, 0)
        {

        }
        public List<DepositAccount> depositList { get; set; }
        public DepositAccount(uint id, long accountNumber, int totalSum, uint idClient)
        {
            this.Id = id;
            this.AccountNumber = accountNumber;
            this.TotalSum = totalSum;
            this.IdClient = idClient;
        }
        public string GetPathDeposit()
        {
            return "C:\\Users\\User\\source\\repos\\Module_13_WPF_Delegat_HomeWork\\DB\\deposit.csv";
        }
        public override string ToString()
        {
            return $"{Id} {AccountNumber} {TotalSum} {IdClient}";
        }
    }
}

