using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;

namespace DragonAid.Lib.Util
{
    public class EquationPrettyTextWriter
    {
        private readonly Stack<ExpressionType> operatorStack = new Stack<ExpressionType>();
        public string Write(Expression toWrite)
        {
            return this.Visit(toWrite);
        }

        private string Visit(Expression expression)
        {
            switch (expression.NodeType)
            {
                case ExpressionType.Lambda:
                    return this.VisitLambda((LambdaExpression) expression);

                case ExpressionType.Call:
                    return this.MethodMethodCall((MethodCallExpression) expression);

                case ExpressionType.MemberAccess:
                    return this.VisitMember((MemberExpression) expression);

                case ExpressionType.Constant:
                    return this.VisitConstant((ConstantExpression) expression);

                case ExpressionType.Multiply:
                case ExpressionType.Subtract:
                case ExpressionType.Add:
                    return this.VisitBinary((BinaryExpression) expression);
            }

            throw new NotImplementedException(expression.GetType().FullName);
        }

        private string MethodMethodCall(MethodCallExpression expression)
        {
            if (expression.Method.Name == "get_Item")
            {
                return this.Visit(expression.Object);
            }

            throw new NotImplementedException(expression.GetType().FullName);
        }

        private string VisitBinary(BinaryExpression expression)
        {
            Contract.Requires(expression != null);

            string operatorText;
            switch (expression.NodeType)
            {
                case ExpressionType.Multiply:
                    operatorText = "*";
                    break;

                case ExpressionType.Add:
                    operatorText = "+";
                    break;

                case ExpressionType.Subtract:
                    operatorText = "-";
                    break;

                default:
                    throw new NotImplementedException(expression.GetType().FullName);
            }

            var wrapWithParens = this.operatorStack.Count > 0 && this.operatorStack.Peek() != expression.NodeType;
            string format = wrapWithParens ? "({0} {1} {2})" : "{0} {1} {2}";
            try
            {
                this.operatorStack.Push(expression.NodeType);
                return string.Format(format, Visit(expression.Left), operatorText, Visit(expression.Right));
            }
            finally
            {
                this.operatorStack.Pop();
            }
        }

        private string VisitLambda(LambdaExpression expression)
        {
            Contract.Requires(expression != null);
            return this.Visit(expression.Body);
        }

        private string VisitMember(MemberExpression expression)
        {
            Contract.Requires(expression != null);
            if (expression.Member.Name == "MagicalAptitude")
            {
                return "MA";
            }

            if (expression.Member.Name == "SpellRanks")
            {
                return "Rank";
            }

            if (expression.Member.Name == "BaseChance")
            {
                return "BaseChance";
            }

            throw new NotImplementedException(expression.GetType().FullName);
        }

        private string VisitConstant(ConstantExpression expression)
        {
            Contract.Requires(expression != null);
            return expression.Value.ToString();
        }
    }
}