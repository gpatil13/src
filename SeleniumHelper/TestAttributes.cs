using CategoryTraits.Xunit2;

namespace SeleniumHelper;

public class SmokeTestAttribute : CategoryTraitAttribute
{
    public SmokeTestAttribute() : base("SmokeTest")
    {
    }
}

