using Quartz;

namespace UpdateScheduler
{
    public class UpdateCurrencyDBJob : IJob
    {
        Task IJob.Execute(IJobExecutionContext context)
        {
            using (CurrencyDBService.CurrencyDBServiceClient serviceClient = new CurrencyDBService.CurrencyDBServiceClient())
            {
                string msg = serviceClient.updateDBAsync().Result;
                return Task.FromResult(msg);
            }
        }
    }
}
