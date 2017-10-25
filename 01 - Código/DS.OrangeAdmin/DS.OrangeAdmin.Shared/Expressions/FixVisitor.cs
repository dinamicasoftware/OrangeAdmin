using System;
using System.Linq.Expressions;

namespace DS.OrangeAdmin.Shared.Expressions
{
    public class FixVisitor : ExpressionVisitor
    {
        bool IsMemeberAccessOfAConstant(Expression exp)
        {
            if (exp.NodeType == ExpressionType.MemberAccess)
            {
                var memberAccess = (MemberExpression)exp;
                if (memberAccess.Expression.NodeType == ExpressionType.Constant)
                    return true;
                return IsMemeberAccessOfAConstant(memberAccess.Expression);
            }

            return false;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (IsMemeberAccessOfAConstant(node) && node.Type == typeof(string))
            {
                var item = Expression.Lambda<Func<string>>(node);
                var value = item.Compile()();
                return Expression.Constant(value, typeof(string));
            }

            return base.VisitMember(node);
        }
    }
}
