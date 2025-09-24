namespace FlexiSchedule.Application.Extensions;
public static class ClientExtensions
{
    /// <summary>
    /// Filtra clientes por profissional e aplica AsNoTracking.
    /// </summary>
    public static IQueryable<Client> ByProfessional(this IQueryable<Client> query, Guid professionalId)
    {
        return query
            .Where(c => c.ProfessionalId == professionalId)
            .AsNoTracking();
    }

    /// <summary>
    /// Converte uma consulta de Client para ClientViewModel
    /// </summary>
    public static IQueryable<ClientViewModel> ToClientViewModel(this IQueryable<Client> query)
    {
        return query
            .Include(p => p.Professional)
            .Select(c => new ClientViewModel(
                c.Id,
                c.Name,
                c.Email,
                c.Phone,
                c.ProfessionalId,
                c.Professional != null ? c.Professional.Name : string.Empty
            ));
    }
}
