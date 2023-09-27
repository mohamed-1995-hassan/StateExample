using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateExample
{
    public interface IAccountState
    {
        IAccountState Deposite(Action addToBalance);
        IAccountState WithDraw(Action subtractFromBalance);
        IAccountState Freez();
        IAccountState HolderVerified();
        IAccountState Close();
    }
}
