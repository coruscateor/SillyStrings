using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Dynamic;

namespace SillyStrings
{

    public class ConsoleWriter : DynamicObject
    {

        public ConsoleWriter()
        {
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {

            Add(binder.Name);

            result = this;

            return true;

        }

        public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
        {

            Add(args);

            result = this;

            return true;

        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {

            Add(binder.Name);

            Add(args);

            result = this;

            return true;

        }

        public override bool TryBinaryOperation(BinaryOperationBinder binder, object arg, out object result)
        {

            switch(binder.Operation)
            {

                case ExpressionType.Add:

                    if(arg != null)
                        Add(arg);

                    result = this;

                    return true;
                case ExpressionType.AddAssign:

                    if(arg != null)
                        Add(arg);

                    result = this;

                    return true;

            }

            result = null;

            return false;

        }

        protected void Add(object TheItem)
        {

            Console.Write(TheItem);

            Console.Write(' ');

        }

        protected void Add(string TheItem)
        {

            Console.Write(TheItem);

            Console.Write(' ');

        }

        protected void Add(object[] TheArgs)
        {

            if(TheArgs.Length > 0)
            {

                Console.Write(TheArgs[0]);

                Console.Write(' ');

                if(TheArgs.Length > 1)
                {

                    for(int i = 1; i < TheArgs.Length; ++i)
                    {

                        Console.Write(TheArgs[i]);

                        Console.Write(' ');

                    }

                }

            }

        }

    }

}
