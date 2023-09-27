using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateExample
{
    public class Frozen : IAccountState
    {
        private Action OnUnFreeze { get; }
        public Frozen(Action OnUnFreeze)
        {
            this.OnUnFreeze = OnUnFreeze;    
        }

        public IAccountState Freez() => this;

        public IAccountState WithDraw()
        {
            this.OnUnFreeze();
            return new Active(OnUnFreeze);
        }

        public IAccountState Deposite(Action addToBalance)
        {
            this.OnUnFreeze();
            addToBalance();
            return new Active(OnUnFreeze);
        }

        public IAccountState WithDraw(Action subtractFromBalance)
        {
            this.OnUnFreeze();
            subtractFromBalance();
            return new Active(OnUnFreeze);
        }

        public IAccountState HolderVerified()
        {
            throw new NotImplementedException();
        }

        public IAccountState Close()
        {
            throw new NotImplementedException();
        }
    }
}
