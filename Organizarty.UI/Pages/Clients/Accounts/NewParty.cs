using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizarty.Application.App.Users.UseCases;
using Organizarty.Application.Exceptions;
using Organizarty.UI.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Organizarty.UI.Pages.Clients.Accounts;

[Unauthenticated("/Clients")]
public class NewPartyModel : PageModel
{
    private readonly RegisterUserUseCase _registerParty;
    private readonly ILogger<CreateAccountModel> _logger;

    public NewPartyModel(ILogger<CreateAccountModel> logger, RegisterUserUseCase registerParty)

    {
        _logger = logger;
        _registerParty = registerParty;
    }

    [BindProperty]
    public InputModel Input { get; set; } = default!;

    public class InputModel
    {
        [Required]
        [Display(Name = "Nome da Festa")]
        public string Name { get; set; } = default!;

        [Required]
        [Display(Name = "Descrição")]
        public string Description { get; set; } = default!;

        [Required]
        [Display(Name = "Número de Convidados")]
        public string GuestsNumber { get; set; } = default!;

        [Required]
        [Display(Name = "Id da Localização")]
        public string LocationID { get; set; } = default!;

        [Required]
        [Display(Name = "Data da Festa")]
        public string PartyDate { get; set; } = default!;

        [Display(Name = "Hora de Inicio")]
        public string? StartingHour { get; set; }

        [Required]
        [Display(Name = "Duração da Festa")]
        public string Duration { get; set; } = default!;
    }

    public void OnGet() { }
}