using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Dynamic;

namespace SillyStrings
{

    public class StringBuilder : DynamicObject, ICloneable
    {

        protected System.Text.StringBuilder mySB;

        public StringBuilder()
        {

            mySB = new System.Text.StringBuilder();

        }

        public StringBuilder(string TheValue)
        {

            mySB = new System.Text.StringBuilder(TheValue);

        }

        public StringBuilder(System.Text.StringBuilder TheSB)
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

            mySB.Append(binder.Name);

            result = this;

            return true;

        }

        public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
        {

            mySB.Append(args);

            result = this;

            return true;

        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {

            mySB.Append(binder.Name);

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
                        mySB.Append(arg);

                    result = this;

                    return true;
                case ExpressionType.AddAssign:

                    if(arg != null)
                    {

                        mySB.Append(mySB);

                        mySB.Append(arg);

                    }

                    result = this;

                    return true;

            }

            result = null;

            return false;

        }

        protected void Add(object[] TheArgs)
        {

            if(TheArgs.Length > 0)
            {

                mySB.Append(TheArgs[0]);

                if(TheArgs.Length > 1)
                {

                    for(int i = 1; i < TheArgs.Length; ++i)
                    {

                        mySB.Append(TheArgs[i]);

                    }

                }

            }

        }

        public System.Text.StringBuilder Copy()
        {

            return new System.Text.StringBuilder(mySB.ToString());

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
