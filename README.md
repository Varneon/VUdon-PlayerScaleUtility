> # :no_entry: This package is deprecated! :no_entry:
> ### VRChat now provides official methods and callbacks for avatar scale, use them instead:
> [`GetAvatarEyeHeightAsMeters`](https://creators.vrchat.com/worlds/udon/players/player-avatar-scaling#getavatareyeheightasmeters)
> [`OnAvatarChanged`](https://creators.vrchat.com/worlds/udon/avatar-events#onavatarchanged)
> [`OnAvatarEyeHeightChanged`](https://creators.vrchat.com/worlds/udon/avatar-events#onavatareyeheightchanged)

<div>

# [VUdon](https://github.com/Varneon/VUdon) - Player Scale Utility [![GitHub Repo stars](https://img.shields.io/github/stars/Varneon/VUdon-PlayerScaleUtility?style=flat&label=Stars)](https://github.com/Varneon/VUdon-PlayerScaleUtility/stargazers) [![GitHub all releases](https://img.shields.io/github/downloads/Varneon/VUdon-PlayerScaleUtility/total?color=blue&label=Downloads&style=flat)](https://github.com/Varneon/VUdon-PlayerScaleUtility/releases) [![GitHub tag (latest SemVer)](https://img.shields.io/github/v/tag/Varneon/VUdon-PlayerScaleUtility?color=blue&label=Release&sort=semver&style=flat)](https://github.com/Varneon/VUdon-PlayerScaleUtility/releases/latest)

</div>

Utility for receiving the relative scale of the player for calibrating e.g. IPD, pointers and quick menus

## How to receive scale callbacks in UdonSharp

By inheriting from [`Varneon.VUdon.PlayerScaleUtility.Abstract.PlayerScaleCallbackReceiver`](https://github.com/Varneon/VUdon-PlayerScaleUtility/blob/main/Packages/com.varneon.vudon.player-scale-utility/Runtime/Udon%20Programs/Abstract/PlayerScaleCallbackReceiver.cs) you can receive callbacks from player's scale changes into your UdonSharpBehaviours:

```csharp
using UdonSharp;
using UnityEngine;
using Varneon.VUdon.PlayerScaleUtility.Abstract;

namespace Varneon.VUdon.PlayerScaleUtility.Examples
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class PlayerScaleCallbackReceiverExample : PlayerScaleCallbackReceiver
    {
        // OnPlayerScaleChanged gets called when the player's avatar changes
        public override void OnPlayerScaleChanged(float newPlayerScale)
        {
            // 'newPlayerScale' can be used to linearly scale something based on the player's scale.
            // 'newPlayerScale' is at 1 when the player's avatar's height matches the player's real height.
            // Player's height on desktop is ~1.73 m by default.
        }
    }
}
```

## How to constrain transform's scale to player's scale

By adding [`PlayerScaleConstraint`](https://github.com/Varneon/VUdon-PlayerScaleUtility/blob/main/Packages/com.varneon.vudon.player-scale-utility/Runtime/Scripts/PlayerScaleConstraint.cs) to an object, its transform's scale will be locked to player's scale

![image](https://github.com/Varneon/VUdon-PlayerScaleUtility/assets/26690821/5a5e1b96-7fcc-48b5-a213-b77fab4c3d48)
