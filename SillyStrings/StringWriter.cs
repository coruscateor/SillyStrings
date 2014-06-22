using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Dynamic;

namespace SillyStrings
{
    
    public class StringWriter : DynamicObject, ICloneable
    {

        protected System.Text.StringBuilder mySB;

        public StringWriter()
        {

            mySB = new System.Text.StringBuilder();

        }

        public StringWriter(string TheValue)
        {

            mySB = new System.Text.StringBuilder(TheValue);

        }

        public StringWriter(System.Text.StringBuilder TheSB)
        {

            mySB = TheSB;

        }

        public int Length
        {

            get
            {

                return mySB.Length;

            }

        }

        public void Clear()
        {

            mySB.Clear();

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
                    {

                        Add(mySB);

                        Add(arg);

                    }

                    result = this;

                    return true;

            }

            result = null;

            return false;

        }

        protected void Add(object TheItem)
        {

            mySB.Append(TheItem);

            mySB.Append(' ');

        }

        protected void Add(string TheItem)
        {

            mySB.Append(TheItem);

            mySB.Append(' ');

        }

        protected void Add(object[] TheArgs)
        {

            if(TheArgs.Length > 0)
            {

                mySB.Append(TheArgs[0]);

                mySB.Append(' ');

                if(TheArgs.Length > 1)
                {

                    for(int i = 1; i < TheArgs.Length; ++i)
                    {

                        mySB.Append(TheArgs[i]);

                        mySB.Append(' ');

                    }

                }

            }

        }

        public StringBuilder Copy()
        {

            return new StringBuilder(mySB.ToString());

        }

        public StringWriter Clone()
        {

            return new StringWriter(mySB.ToString());

        }

        object ICloneable.Clone()
        {

            return Clone();

        }

        public override string ToString()
        {

            return mySB.ToString();

        }

    }

}
