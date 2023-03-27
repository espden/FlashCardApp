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
    public IEnumerable<Card> GetAllCards()
    {
        return context.Cards.ToArray();
    }

    [HttpGet("{id}")]
    public ActionResult<Card> GetCard(Guid id)
    {
        Card? card = context.Cards.Find(id);
        if (card != null)
            return card;
        return NotFound();
    }

    [HttpPost]
    public ActionResult PostCard([FromBody]Card card)
    {
        context.Cards.Add(card);
        context.SaveChanges();
        Card createdCard = context.Cards.Where(i => i.Id == card.Id).First();
        return Created($"{createdCard.Id}", createdCard);
    }

    [HttpPut("{id}")]
    public ActionResult PutCard(Guid id, [FromBody]Card card)
    {
        Card? _card = context.Cards.Find(id);
        if (_card == null)
            return NotFound();
        _card.Answer = card.Answer;
        _card.Question = card.Question;
        context.SaveChanges();
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteCard(Guid id)
    {
        Card? card = context.Cards.Find(id);
        if (card == null)
            return NotFound();
        context.Cards.Remove(card);
        context.SaveChanges();
        return Ok();
    }
}
