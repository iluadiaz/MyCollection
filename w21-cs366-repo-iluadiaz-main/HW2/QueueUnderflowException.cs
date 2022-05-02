using System;
using QueuedInterface;
using Node;


namespace QueueUnderflowException
{
    class QueueUnderflowException : SystemException
    {
    public virtual void QueueUnderflow(string message){} 
    }
    class exception : QueueUnderflowException
    {
        public override void QueueUnderflow(string message)
        {
            base.QueueUnderflow(message);

        }
    }
}
