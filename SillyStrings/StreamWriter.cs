using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Dynamic;
using System.IO;

namespace SillyStrings
{
    
    public class StreamWriter : DynamicObject, IDisposable
    {

        protected System.IO.StreamWriter myStreamWriter;

        public StreamWriter(Stream TheStream)
        {

            myStreamWriter = new System.IO.StreamWriter(TheStream);

        }

        public StreamWriter(System.IO.StreamWriter TheStreamWriter)
        {

            myStreamWriter = TheStreamWriter;

        }

        public StreamWriter(string ThePath)
        {

            myStreamWriter = new System.IO.StreamWriter(ThePath);

        }

        public StreamWriter(string ThePath, bool Append)
        {

            myStreamWriter = new System.IO.StreamWriter(ThePath, Append);

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

            myStreamWriter.Write(TheItem);

            myStreamWriter.Write(' ');

        }

        protected void Add(string TheItem)
        {

            myStreamWriter.Write(TheItem);

            myStreamWriter.Write(' ');

        }

        protected void Add(object[] TheArgs)
        {

            if(TheArgs.Length > 0)
            {

                myStreamWriter.Write(TheArgs[0]);

                myStreamWriter.Write(' ');

                if(TheArgs.Length > 1)
                {

                    for(int i = 1; i < TheArgs.Length; ++i)
                    {

                        myStreamWriter.Write(TheArgs[i]);

                        myStreamWriter.Write(' ');

                    }

                }

            }

        }
        
        public void Dispose()
        {

            myStreamWriter.Dispose();

        }

    }

}
