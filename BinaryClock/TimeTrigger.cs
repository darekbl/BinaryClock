using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryClock
{
    class TimeTrigger
    {

        readonly TimeSpan triggerHour;

        public TimeTrigger(int second, int minute = 0, int hour = 0)
        {
            triggerHour = new TimeSpan(second, minute, hour);
            InitiateAsync();
        }

        async void InitiateAsync()
        {
            while (true)
            {
                var triggerTime = DateTime.Today + triggerHour - DateTime.Now;
                if (triggerTime < TimeSpan.Zero)
                    triggerTime = triggerTime.Add(new TimeSpan(0, 0, 100));
                //await Task.Delay(triggerTime);
                await Task.Delay(1000);
                OnTimeTriggered?.Invoke();
            }
        }

        public event Action OnTimeTriggered;
        
    }
}
