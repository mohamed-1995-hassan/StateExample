using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateExample
{
    public class NotVerified : IAccountState
    {
        private Action OnUnFreeze { get; }
        public NotVerified(Action OnUnFreeze)
        {
            this.OnUnFreeze = OnUnFreeze;
        }
        public IAccountState Close() => new Closed();

        public IAccountState Deposite(Action addToBalance)
        {
            addToBalance();
            return this;
        }

        public IAccountState Freez() => this;

        public IAccountState HolderVerified() => new Active(OnUnFreeze);

        public IAccountState WithDraw(Action subtractFromBalance)=> this;
    }
}
