using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SillyStrings
{
    
    public class StringInvocationInfoEventArgs
    {

        protected string myValue;

        protected OperationType myInvocationType;

        protected int myIndex;

        public StringInvocationInfoEventArgs(string TheValue, OperationType TheInvocationType, int TheIndex = -1)
        {

            myValue = TheValue;

            myInvocationType = TheInvocationType;

            myIndex = TheIndex;

        }

        public string Value
        {

            get
            {

                return myValue;

            }

        }

        public OperationType InvocationType
        {

            get
            {

                return myInvocationType;

            }

        }

        public int Index
        {

            get
            {

                return myIndex;

            }

        }

        public bool HasValidIndex
        {

            get
            {

                return myIndex > -1;

            }

        }

    }

}
