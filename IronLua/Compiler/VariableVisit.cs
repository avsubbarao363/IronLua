using System.Linq.Expressions;
using Expr = System.Linq.Expressions.Expression;

namespace IronLua.Compiler
{
    class VariableVisit
    {
        public VariableType Type { get; private set; }
        public Expr Object { get; private set; }
        public string Identifier { get; private set; }
        public Expr Member { get; private set; }

        private VariableVisit()
        {
        }

        public static VariableVisit CreateMemberId(Expr @object, string identifier)
        {
            return new VariableVisit
                       {
                           Type = VariableType.MemberId,
                           Object = @object,
                           Identifier = identifier
                       };
        }

        public static VariableVisit CreateMemberExpr(Expr @object, Expr member)
        {
            return new VariableVisit
                       {
                           Type = VariableType.MemberExpr,
                           Object = @object,
                           Member = member
                       };
        }
    }

    enum VariableType
    {
        MemberId,
        MemberExpr
    }
}