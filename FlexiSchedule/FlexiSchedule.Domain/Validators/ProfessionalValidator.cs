namespace FlexiSchedule.Domain.Validators;
public class ProfessionalValidator(IProfessionalRepository repository)
{
    public async Task ValidateUniqueAsync(Professional professional, CancellationToken cancellationToken)
    {
        if (await repository.GetByDocumentAsync(professional.Document, professional.Id, cancellationToken))
            throw new InvalidProfessionalDocumentException("Professional with the same document already exists.");

        if (await repository.VerifyEmailAsync(professional.Email, cancellationToken))
            throw new InvalidProfessionalDocumentException("Professional with the same email already exists.");
    }
}
