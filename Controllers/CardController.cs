using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Data;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class CardController : ControllerBase
{
    private FlashcardAppDbContext context;
    public CardController(FlashcardAppDbContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public IEnumerable<Card> Get()
    {
        return context.Cards.ToArray();
    }
}
