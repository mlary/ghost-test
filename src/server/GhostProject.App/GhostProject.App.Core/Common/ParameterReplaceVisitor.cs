using System.Linq.Expressions;

namespace GhostProject.App.Core.Common;

internal class ParameterReplaceVisitor:ExpressionVisitor
{
    public ParameterExpression Target { get; set; }
    public ParameterExpression Replacement { get; set; }

    protected override Expression VisitParameter(ParameterExpression node)
    {
        return node == Target ? Replacement : base.VisitParameter(node);
    }
}
