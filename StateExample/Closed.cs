using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateExample
{
    public class Closed : IAccountState
    {
        public IAccountState Close() => this

        public IAccountState Deposite() => this;
        public IAccountState Freez() => this;
        
        public IAccountState HolderVerified() => this;

        public IAccountState WithDraw() => this;
    }
}
