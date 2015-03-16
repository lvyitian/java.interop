using System;
using System.Collections.Generic;
using System.Linq;

using Java.Interop;

using NUnit.Framework;

namespace Java.InteropTests
{
	[TestFixture]
	public class JavaBooleanArrayContractTests : JavaPrimitiveArrayContract<JavaBooleanArray, bool>
	{
		protected override bool CreateValueA ()
		{
			return true;
		}

		protected override bool CreateValueB ()
		{
			return false;
		}
	}
}

