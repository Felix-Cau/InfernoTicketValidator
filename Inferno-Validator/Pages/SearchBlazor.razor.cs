using Inferno_Validator.Firebase.Models;
using Inferno_Validator.Models;
using Microsoft.AspNetCore.Components;

namespace Inferno_Validator.Pages
{
    public partial class SearchBlazor
    {
        public string searchText = "";

        public List<Ticket> FilteredTickets { get; set; } = new();
        public List<Game> Games { get; set; } = new();

        public static string SelectedGame = "";

        [Inject]
        public ITicketRepository? TicketRepository { get; set; }
        [Inject]
        public IGameRepository? GameRepository { get; set; }

        private async Task Search()
        {
            var tickets = await TicketRepository.GetTicketsAsync();
            FilteredTickets.Clear();
            if (TicketRepository is not null)
            {
                if (searchText.Length >= 3)
                    FilteredTickets = tickets.Where(t => t.Id.Contains(searchText, StringComparison.InvariantCultureIgnoreCase) ||
                                                t.FirstName.Contains(searchText, StringComparison.InvariantCultureIgnoreCase) ||
                                                t.LastName.Contains(searchText, StringComparison.InvariantCultureIgnoreCase) ||
                                                t.DateOfBirth.Contains(searchText, StringComparison.InvariantCultureIgnoreCase)).ToList();
            }
        }

        protected override async Task OnInitializedAsync()
        {
            var authenticationStateAsync = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            if (!authenticationStateAsync.User.Identity.IsAuthenticated)
            {
                NavigationManager.NavigateTo("login");
                return;
            }
            var initializedGames = await GameRepository.GetGamesAsync();
            if (GameRepository is not null)
            {
                Games = initializedGames.ToList();
            }
        }
    }
}
