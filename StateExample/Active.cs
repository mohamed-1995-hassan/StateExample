using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateExample
{
    public class Active : IAccountState
    {
        private Action OnUnFreeze { get; }
        public Active(Action OnUnFreeze)
        {
            this.OnUnFreeze = OnUnFreeze;
        }

        public IAccountState Freez() => new Frozen(this.OnUnFreeze);

        public IAccountState Deposite(Action addToBalance)
        {
            addToBalance();
            return this;
        }

        public IAccountState WithDraw(Action subtractFromBalance)
        {
            subtractFromBalance();
            return this;
        }

        public IAccountState HolderVerified() => this;

        public IAccountState Close()
        {
            throw new NotImplementedException();
        }
    }
}
