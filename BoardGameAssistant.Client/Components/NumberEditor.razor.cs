using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Runtime.CompilerServices;

namespace BoardGameAssistant.Client.Components
{
    public partial class NumberEditor
    {
        private int value;

        [Parameter]
        public int Value
        {
            get => value;
            set
            {
                if (this.value == value)
                    return;

                this.value = value;
                this.ValueChanged.InvokeAsync(value);
            }
        }

        [Parameter]
        public EventCallback<int> ValueChanged { get; set; }


        [Parameter]
        public Variant EditorVariant { get; set; } = Variant.Outlined;

        [Parameter]
        public Variant IconButtonVariant { get; set; } = Variant.Text;

        [Parameter]
        public Color IconButtonColor { get; set; } = Color.Default;

        [Inject]
        public IDialogService DialogService { get; set; } = null!;

        private async Task ShowCalculator()
        {
            var dialog = await DialogService.ShowAsync<CalculatorDialog>(
                "Calculator",
                new DialogOptions { });

            var dialogResult = await dialog.Result;
            if (dialogResult is not null && !dialogResult.Canceled)
            {
                if (dialogResult.Data is double result)
                {
                    Value = (int)Math.Round(result, MidpointRounding.AwayFromZero);
                }
            }
        }
    }
}
