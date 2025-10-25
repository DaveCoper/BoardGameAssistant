using BoardGameAssistant.ServiceContracts.Scythe;
using BoardGameAssistant.ServiceContracts.Scythe.Dto;
using BoardGameAssistant.ServiceContracts.Wingspan;
using BoardGameAssistant.ServiceContracts.Wingspan.Dto;
using Microsoft.AspNetCore.Components;

namespace BoardGameAssistant.Client.Components.Wingspan
{
    public partial class NewGameForm
    {
        [Parameter]
        public NewWingspanGame Model { get; set; }

        [Inject]
        public IWingspanGameService GameService { get; set; }

        [Parameter]
        public EventCallback<WingspanGame> OnNewGameCreated { get; set; }

        [Parameter]
        public EventCallback OnError { get; set; }

        public NewGameForm()
        {
            Model = GenerateNewModel();
        }

        private async Task SaveAsync()
        {
            try
            {
                var game = await GameService.CreateGameAsync(this.Model);
                if (this.OnNewGameCreated.HasDelegate)
                {
                    await this.OnNewGameCreated.InvokeAsync(game);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private NewWingspanGame GenerateNewModel()
        {
            return new NewWingspanGame
            {
                Name = $"Wingspan {DateTime.Now:dd/MM/yyyy}",
                Occurrence = DateTime.Now,
                HasOceaniaExpansion = true,
            };
        }
    }
}
