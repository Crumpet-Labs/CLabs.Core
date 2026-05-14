using Buttr.Core;

namespace CLabs.Tickets {
    public static class TicketPackage {
        public static IConfigurableCollection UseTicketPackage(this ApplicationBuilder builder) {
            // Core Ticket has no runtime state to register with Buttr — the
            // TicketRuntime facade is populated by engine adapters directly
            // via static function pointers during their own startup. Engine
            // adapters (Unity, Godot) ship their own UseTicket{Engine}Package
            // extensions that perform the registration. Kept as a convention-
            // compliant no-op for consistency with other CLabs packages.
            return new ConfigurableCollection();
        }
    }
}
