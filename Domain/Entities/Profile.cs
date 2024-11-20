using Domain.Validators;
using Domain.ValueObject;

namespace Domain.Entities;

public sealed class Profile:BaseEntities<Profile>
{
    public Profile(string externalID, Email? email)
    {
        ExternalId = externalID;
        Email = email;
        
        ValidateEntity(new ProfileValidator());
    }
    public string ExternalId { get; private init; }
    public Email? Email { get; private set; }

    public List<FavoriteDrug> FavoriteDrugs { get; private set; } = [];
}