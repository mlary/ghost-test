using MediatR;

namespace GhostProject.App.Core.Business.Companies.Commands.Delete;

public class DeleteCompanyCommand : IRequest<Unit>
{
    public int Id { get; }

    public DeleteCompanyCommand(int id)
    {
        Id = id;
    }
}
