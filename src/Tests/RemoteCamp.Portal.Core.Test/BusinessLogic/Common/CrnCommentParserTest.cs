using RemoteCamp.Portal.Core.BusinessLogic.Common;
using RemoteCamp.Portal.Core.Test.Common;
using Shouldly;
using Xunit;

namespace RemoteCamp.Portal.Core.Test.BusinessLogic.Common
{
    public class CrnCommentParserTest : UnitTestBase
    {
        private const string CrnComment1 =
            @":no_entry_sign: **This code uses a method, or constructor, argument without validating whether it is null.**  
  
An important improvement would be to refactor the code so that it validates the parameter and throws an `ArgumentNullException` rather than letting a `NullReferenceException` occur or any unexpected behavior.  
  
This change would provide meaningful information to the caller, since the name of the exception may contain valuable information (e.g., `ArgumentNullException` we easily infer what exceptional case just happened).  
  
>NOTE:  
>- Please validate for any `public` methods, or constructors, since they are open to anyone and input argument(s) cannot be controlled.  
>- Please also consider validating for `protected` and `private` methods, or constructors, if a `NullReferenceException` is prone to occur.  
>- Throwing an `ArgumentNullException` instead of a `NullReferenceException` gives more meaning to the error and should not change existing behavior since `NullReferenceException` and `ArgumentNullException` are not intended to be handled and actually indicate some programming mistake rather than a business rule violation.

**[More details](https://confluence.devfactory.com/x/dg6kEw)**

## The solution in this case

```cs  
if (category == null)
{
    throw new ArgumentNullException(""categor"");
    }
    ``` 
    > NOTE: Consider applying the structure of this solution in other parts of the code, if there is another occurrence. 

    <a id = ""102c8a30-951f-11e9-9cb8-6ddc0289855b"" href= ""none"" codereview-uuid-reserved-tag />";

        [Fact]
        public void GetSummary()
        {
            var summary = CrnCommentParser.GetSummary(CrnComment1);
            summary.ShouldBe("This code uses a method, or constructor, argument without validating whether it is null.");
        }

        [Fact]
        public void GetLink()
        {
            var link = CrnCommentParser.GetLink(CrnComment1);
            link.ShouldBe("https://confluence.devfactory.com/x/dg6kEw");
        }
    }
}
