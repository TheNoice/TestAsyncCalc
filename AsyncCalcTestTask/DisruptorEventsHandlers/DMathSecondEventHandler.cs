using AsyncCalcCore.Services;
using Common.Models;
using Disruptor;
using System;

namespace AsyncCalcTestTask.DisruptorEventsHandlers
{
    internal class DMathSecondEventHandler : IWorkHandler<IntBasicMathEventModel>
    {
        private readonly MathOperationService _mathOpService = new (); //если будет несколько, то передавать через конструктор (принимать интерфейсом)
        public void OnEvent(IntBasicMathEventModel eventData)
        {
            eventData = _mathOpService.DoOperation(eventData);
            eventData.DiagnosticTimer?.Stop();
            var result = eventData.Result?.ToString() ?? "Invalid operation, try a different one.";
            Console.WriteLine($"Operation Id: {eventData.Id}, Code: {eventData.Code}, Result: {result}");

            if (eventData.DiagnosticTimer != null)
                Console.WriteLine("Time taken: " + eventData.DiagnosticTimer.Elapsed.ToString(@"m\:ss\.fff"));
        }
    }
}
