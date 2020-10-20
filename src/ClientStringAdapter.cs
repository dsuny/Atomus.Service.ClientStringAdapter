using Atomus.Diagnostics;
using System;
using System.Threading.Tasks;

namespace Atomus.Service
{
    public class ClientStringAdapter : IServiceString, IServiceStringAsync
    {
        public ClientStringAdapter() { }

        string IServiceString.Request(string data)
        {
            try
            {
                //return (new WcfServiceClientString() as IServiceString).Request(data);
                return (this.CreateInstance("Service") as IServiceString).Request(data);
            }
            catch (AtomusException exception)
            {
                DiagnosticsTool.MyTrace(exception);
                return exception.ToString();
            }
            catch (Exception exception)
            {
                DiagnosticsTool.MyTrace(exception);
                return exception.ToString();
            }
        }

        async Task<string> IServiceStringAsync.RequestAsync(string data)
        {
            try
            {
                //return await ((dynamic)new WcfServiceClientString()).RequestAsync(data);
                return await ((dynamic)this.CreateInstance("Service")).RequestAsync(data);
            }
            catch (AtomusException exception)
            {
                DiagnosticsTool.MyTrace(exception);
                return exception.ToString();
            }
            catch (Exception exception)
            {
                DiagnosticsTool.MyTrace(exception);
                return exception.ToString();
            }
        }
    }
}
