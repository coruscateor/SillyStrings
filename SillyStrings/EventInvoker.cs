using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Dynamic;

namespace SillyStrings
{

    public class EventInvoker : DynamicObject
    {

        public event EventHandler<StringInvocationInfoEventArgs> Invoked;

        public EventInvoker()
        {
        }

        protected void OnInvoked(string TheString, OperationType TheInvocationType, int TheIndex = -1)
        {

            if(Invoked != null)
                Invoked(this, new StringInvocationInfoEventArgs(TheString, TheInvocationType, TheIndex));

        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {

            OnInvoked(binder.Name, OperationType.MemberAccess);

            result = this;

            return true;

        }

        public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
        {

            Invoke(args, OperationType.Invocation);

            result = this;

            return true;

        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {

            OnInvoked(binder.Name, OperationType.MemberInvocation);

            Invoke(args, OperationType.MemberInvocation);

            result = this;

            return true;

        }

        public override bool TryBinaryOperation(BinaryOperationBinder binder, object arg, out object result)
        {

            switch(binder.Operation)
            {

                case ExpressionType.Add:

                    if(arg != null)
                        OnInvoked(arg.ToString(), OperationType.Addition);

                    result = this;

                    return true;
                case ExpressionType.AddAssign:

                    if(arg != null)
                        OnInvoked(arg.ToString(), OperationType.AdditionAssignment);

                    result = this;

                    return true;

            }

            result = null;

            return false;

        }

        protected void Invoke(object[] TheArgs, OperationType TheInvocationType)
        {

            if(TheArgs.Length > 0)
            {

                OnInvoked(TheArgs[0].ToString(), TheInvocationType, 0);

                if(TheArgs.Length > 1)
                {

                    for(int i = 1; i < TheArgs.Length; ++i)
                    {

                        OnInvoked(TheArgs[i].ToString(), TheInvocationType, i);

                    }

                }

            }

        }

    }

}
