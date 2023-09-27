using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateExample
{
    class Account
    {
        private decimal Balance { get; set; }
        private IAccountState State { get; set; }
        public Account(Action OnUnFreeze)
        {
            this.State = new NotVerified(OnUnFreeze);
        }

        public void Deposite(decimal amount)
        {
            this.State = this.State.Deposite(()=>this.Balance+=amount);
        }
        public void WithDraw(decimal amount)
        {
            this.State = this.State.Deposite(() => this.Balance -= amount);
        }
        public void HolderVerfied()
        {
            this.State = this.State.HolderVerified();
        }
        public void Close()
        {
            this.State = this.State.Close();
        }
        public void Freeze()
        {
            this.State = this.State.Freez();
        }
        
    }
}
