using Common.Enums;
using Common.Models;

namespace AsyncCalcCore.Services
{
    public class MathOperationService
    {
        public IntBasicMathEventModel DoOperation(IntBasicMathEventModel model)
        {
            if (model.Code == EventCodeEnum.IncorrectInput)
                return model;

            switch (model.Operation)
            {
                case MathOperationsEnum.Sum:
                    model.Result = model.IntVal1 + model.IntVal2;
                    break;
                case MathOperationsEnum.Diff:
                    model.Result = model.IntVal1 - model.IntVal2;
                    break;
                default:
                    return model;
            }
            model.Code = EventCodeEnum.Success;
            return model;
        }
    }
}
