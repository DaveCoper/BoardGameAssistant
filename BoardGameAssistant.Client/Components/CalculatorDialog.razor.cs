using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Diagnostics;

namespace BoardGameAssistant.Client.Components
{
    public partial class CalculatorDialog
    {
        [CascadingParameter]
        private IMudDialogInstance MudDialog { get; set; } = null!;

        private const string ErrorMessage = "Err";
        private string calcInput = string.Empty;

        private bool hasError;

        private void AppendBarckets()
        {

        }

        private void AppendCalc(char val)
        {
            calcInput += val;
            StateHasChanged();
        }

        private void ClearCalc()
        {
            hasError = false;
            calcInput = string.Empty;
        }

        private void ClearLast()
        {
            if (calcInput.Length <= 1 || calcInput == ErrorMessage)
            {
                ClearCalc();
            }
            else
            {
                calcInput = calcInput.Substring(0, calcInput.Length - 1);
            }
        }

        private void Submit()
        {
            var result = EvaluateCalc();
            if (result.HasValue)
            {
                var rusult = DialogResult.Ok(result.Value, typeof(CalculatorDialog));
                MudDialog.Close(rusult);
            }
        }

        private void Cancel() => MudDialog.Cancel();

        private double? EvaluateCalc()
        {
            try
            {
                var calcResult = ComputeResult();
                calcInput = calcResult.ToString();
                hasError = false;
                return calcResult;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                calcInput = ErrorMessage;
                hasError = true;
                return null;
            }
        }

        private double ComputeResult()
        {
            var input = calcInput;
            if (string.IsNullOrWhiteSpace(input))
                return 0.0;

            var result = new System.Data.DataTable().Compute(input, null);
            if (result is null)
                return 0.0;

            var resultDouble = Convert.ToDouble(result);
            return resultDouble;
        }
    }
}
