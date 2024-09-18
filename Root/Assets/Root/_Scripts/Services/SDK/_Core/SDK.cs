using System.Collections;

namespace Root.Services.SDK
{
    public class SDK
    {
        public IStrategy Strategy { get; private set; }

        public IEnumerator Init()
        {
            var strategy = new UnityStrategy();

            yield return strategy.Init();

            Strategy = strategy;
        }
    }
}
