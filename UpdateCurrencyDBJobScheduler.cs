using Quartz;
using Quartz.Impl;

namespace UpdateScheduler
{
    public class UpdateCurrencyDBJobScheduler
    {
        public static void Start()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler().Result;
            scheduler.Start();

            IJobDetail job = JobBuilder.Create<UpdateCurrencyDBJob>().Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithDailyTimeIntervalSchedule
                  (s =>
                     s
                    .OnEveryDay() //hergün çalışacağı bilgisi
                    .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(11,56)) //hergün hangi saatte çalışacağı bilgisi
                  )
                .Build();

            scheduler.ScheduleJob(job, trigger);
        }
    }
}
