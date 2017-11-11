using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DS.OrangeAdmin.Shared.Expressions
{
    public class FixVisitor : ExpressionVisitor
    {
        public T Visit<T>(T expression) where T : Expression
        {
            return base.Visit(expression) as T;
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            return node.Update(node.Object, fixParameters(node.Arguments));;
        }

        private IEnumerable<Expression> fixParameters(ICollection<Expression> parameters)
        {
            if (parameters == null)
            {
                yield return null;
            }
            else
            {
                foreach (var parameter in parameters)
                {
                    if (parameter is MemberExpression)
                    {
                        if ((parameter as MemberExpression).Expression is ConstantExpression)
                        {
                            var item = Expression.Lambda<Func<object>>(parameter);
                            var value = item.Compile()();
                            yield return Expression.Constant(value);
                        }
                        else
                        {
                            yield return this.Visit(parameter);
                        }
                    }
                    else
                    {
                        yield return this.Visit(parameter);
                    }
                }
            }
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
