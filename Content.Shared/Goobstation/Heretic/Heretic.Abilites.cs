using Content.Shared.Actions;
using Content.Shared.DoAfter;
using Content.Shared.Inventory;
using Robust.Shared.GameStates;
using Robust.Shared.Map;
using Robust.Shared.Serialization;

namespace Content.Shared.Heretic;

[RegisterComponent, NetworkedComponent]
public sealed partial class HereticActionComponent : Component
{
    /// <summary>
    ///     Indicates that a user should wear a heretic amulet, a hood or something else.
    /// </summary>
    [DataField] public bool RequireMagicItem = true;

    [DataField] public string? MessageLoc = null;
}

#region DoAfters

[Serializable, NetSerializable] public sealed partial class EldritchInfluenceDoAfterEvent : SimpleDoAfterEvent { }
[Serializable, NetSerializable] public sealed partial class DrawRitualRuneDoAfterEvent : SimpleDoAfterEvent
{
    [NonSerialized] public EntityCoordinates Coords;
    [NonSerialized] public EntityUid RitualRune;

    public DrawRitualRuneDoAfterEvent(EntityUid ritualRune, EntityCoordinates coords)
    {
        RitualRune = ritualRune;
        Coords = coords;
    }
}

#endregion

#region Abilities

/// <summary>
///     Raised whenever we need to check for a magic item before casting a spell that requires one to be worn.
/// </summary>
public sealed partial class CheckMagicItemEvent : HandledEntityEventArgs, IInventoryRelayEvent
{
    public SlotFlags TargetSlots => SlotFlags.WITHOUT_POCKET;
}

public sealed partial class EventHereticOpenStore : InstantActionEvent { }
public sealed partial class EventHereticMansusGrasp : InstantActionEvent { }

// ash
public sealed partial class EventHereticAshenShift : InstantActionEvent { }
public sealed partial class EventHereticVolcanoBlast : InstantActionEvent { }
public sealed partial class EventHereticNightwatcherRebirth : InstantActionEvent { }
public sealed partial class EventHereticFlames : InstantActionEvent { }
public sealed partial class EventHereticCascade : InstantActionEvent { }


// flesh
public sealed partial class EventHereticFleshAscend : InstantActionEvent { }
#endregion
