using GhostProject.App.Core.Tests.Common;
using GhostProject.App.Core.Tests.Data;
using Xunit;

namespace GhostProject.App.Core.Tests.Recruiters.Queries
{
    [Collection("DataCollection")]
    public class GetRecruiterTests: CommandTestBase
    {
        public GetRecruiterTests(DataFixture dataFixture) : base(dataFixture)
        {
        }
    }
}
