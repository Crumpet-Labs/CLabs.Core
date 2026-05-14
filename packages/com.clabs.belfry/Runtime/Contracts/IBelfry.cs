using System;
using System.Collections.Generic;

namespace CLabs.Belfry {
    public interface IBelfry {
        IDisposable Subscribe(BellChannel channel, Delegate handler, int priority = 0);
        IDisposable Subscribe(IReadOnlyList<BellBinding> bindings);
        void Publish<T>(BellChannel channel, in T message) where T : struct;
        IReadOnlyList<BellBinding> GetBindings(BellChannel channel);
    }
}
