using AsyncCalcTestTask.DisruptorEventsHandlers;
using AsyncCalcTestTask.Helpers;
using Common.Models;
using Disruptor.Dsl;
using System;
using System.Diagnostics;

namespace AsyncCalcTestTask
{
    internal class Application
    {
        private static int operaionId = 0;
        private readonly InputBasicValidator validator = new(); //будет несколько - надо через интерфейс и без инициализации здесь

        public void Run() //IDecisionManager decisionManager, IComparerPreparator preparator)
        {
            //RingBufferSize (1024) следовало бы вынести в конфиг, но тогда нужен nuget-пакет для адеватной расшифровки JSON-файла. В костылях не вижу смысла.
            //и после расшифровки конфига еще и проверку типа *if ((Math.Log(RingBufferSize, 2) % 1) != 0)*
            var disruptor = new Disruptor<IntBasicMathEventModel>(() => new IntBasicMathEventModel(++operaionId, new Stopwatch()), 1024);

            disruptor.HandleEventsWithWorkerPool(new
            DMathFirstEventHandler()).ThenHandleEventsWithWorkerPool(new
            DMathSecondEventHandler());

            disruptor.Start();

            Console.WriteLine(validator.WelcomeMessage);

            bool isRunning = true;
            while (isRunning)
            {
                var input = Console.ReadLine().Trim().ToLower();

                using (var scope = disruptor.PublishEvent())
                {
                    var data = scope.Event();
                    data.DiagnosticTimer?.Start();
                    validator.Validate(input, ref data, ref isRunning);
                }
            }
        }
    }
}
