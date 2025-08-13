using FlexiSchedule.Domain.Interfaces;

namespace FlexiSchedule.Domain.Validators;
public class ProfessionalValidator(IProfessionalRepository repository)
{
    public async Task ValidateUniqueAsync(Professional professional, CancellationToken cancellationToken)
    {
        if (await repository.GetByDocumentAsync(professional.Document, professional.Id, cancellationToken))
            throw new InvalidOperationException("Professional with the same document already exists.");

        if (await repository.GetByEmailAsync(professional.Email, professional.Id, cancellationToken))
            throw new InvalidOperationException("Professional with the same email already exists.");
    }
}
