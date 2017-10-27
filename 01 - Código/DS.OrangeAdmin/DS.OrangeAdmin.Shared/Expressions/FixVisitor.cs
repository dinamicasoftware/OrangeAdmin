using System;
using System.Linq.Expressions;

namespace DS.OrangeAdmin.Shared.Expressions
{
    public class FixVisitor : ExpressionVisitor
    {
        public T Visit<T>(T expression) where T : Expression
        {
            return base.Visit(expression) as T;
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (node.Right.Type == typeof(Guid))
            {
                var item = Expression.Lambda<Func<Guid>>(node.Right);
                var value = item.Compile()();
                var constant = Expression.Constant(value);
                return node.Update(node.Left, node.Conversion, constant);
            }
            else
            {
                bool evalueteExpression;
                if (node.Right is ConstantExpression)
                {
                    evalueteExpression = false;
                }
                else
                {
                    if (node.Right is MemberExpression)
                    {
                        evalueteExpression = (node.Left as MemberExpression)?.Expression != (node.Right as MemberExpression)?.Expression;
                    }
                    else
                    {
                        evalueteExpression = true;
                    }
                }

                if (evalueteExpression)
                {
                    var item = Expression.Lambda<Func<object>>(node.Right);
                    var value = item.Compile()();
                    var constant = Expression.Constant(value);
                    return node.Update(node.Left, node.Conversion, constant);
                }
                else
                {
                    return base.VisitBinary(node);
                }
            }
        }
    }
}
