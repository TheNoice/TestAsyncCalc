using Common.Models;
using Disruptor;
using System.Threading;

namespace AsyncCalcTestTask.DisruptorEventsHandlers
{
    public class DMathFirstEventHandler : IWorkHandler<IntBasicMathEventModel>
    {
        public void OnEvent(IntBasicMathEventModel evt)
        {
            Thread.Sleep(2000);
        }
    }
}
