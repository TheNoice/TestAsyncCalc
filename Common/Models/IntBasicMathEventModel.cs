using Common.Enums;
using System.Diagnostics;

namespace Common.Models
{
    public class IntBasicMathEventModel
    {
        public int Id { get; set; }
        public EventCodeEnum Code { get; set; }
        public MathOperationsEnum Operation { get; set; }
        public int IntVal1 { get; set; }
        public int IntVal2 { get; set; }
        public int? Result { get; set; }
        public Stopwatch? DiagnosticTimer { get; set; }

        public IntBasicMathEventModel(int id, Stopwatch? diagnosticTimer = null)
        {
            Id = id;
            Code = EventCodeEnum.InProgress;
            DiagnosticTimer = diagnosticTimer;
        }
    }
}
