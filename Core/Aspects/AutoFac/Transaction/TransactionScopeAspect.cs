using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Core.Aspects.AutoFac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())//Çalıştırır veri tabanı için
            {
                try//veri tabanına ekler
                {
                    invocation.Proceed();
                    transactionScope.Complete();
                }
                catch (System.Exception e)//hatalıysa işlemi geri alır
                {
                    transactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}
      
