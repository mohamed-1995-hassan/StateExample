using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateExample
{
    class Account
    {
        public bool IsVerified { get; private set; }
        private bool IsClosed { get; set; }
        private bool IsFrozen { get; set; }
        private decimal Balance { get; set; }
        private Action OnUnFreeze { get; }
        public Account(Action OnUnFreeze)
        {
            this.OnUnFreeze = OnUnFreeze;   
           
        }

        public void Deposite(decimal amount)
        {
            if (IsClosed)
                return;
            if (this.IsFrozen)
            {
                this.IsFrozen = false;
                this.OnUnFreeze();
            }
            //Deposite Money
            this.Balance += amount;
        }
        public void WithDraw(decimal amount)
        {
            if (!IsVerified)
                return;//or Do Something Else
            if (IsClosed)
                return;//or Do Something Else
            if (this.IsFrozen)
            {
                this.IsFrozen = false;
                this.OnUnFreeze();
            }
            //WithDraw Money
            this.Balance += amount;
        }
        public void HolderVerfied()
        {
            this.IsVerified = true;
        }
        public void Close()
        {
            this.IsClosed = true;
        }
        public void IsFreeze()
        {
            if(this.IsClosed)
                return;
            if (!this.IsVerified)
                return;
            this.IsFrozen = true;
        }
    }
}
