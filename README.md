> # :warning: VRChat's official avatar scaling is in beta and this package will be deprecated after it goes live! Please see: https://creators.vrchat.com/worlds/udon/players/player-avatar-scaling and https://creators.vrchat.com/worlds/udon/avatar-events

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

# Installation

<details><summary>

### Import with [VRChat Creator Companion](https://vcc.docs.vrchat.com/vpm/packages#user-packages):</summary>

> 1. Download `com.varneon.vudon.player-scale-utility.zip` from [here](https://github.com/Varneon/VUdon-PlayerScaleUtility/releases/latest)
> 2. Unpack the .zip somewhere
> 3. In VRChat Creator Companion, navigate to `Settings` > `User Packages` > `Add`
> 4. Navigate to the unpacked folder, `com.varneon.vudon.player-scale-utility` and click `Select Folder`
> 5. `VUdon - Player Scale Utility` should now be visible under `Local User Packages` in the project view in VRChat Creator Companion
> 6. Click `Add`

</details><details><summary>

### Import with [Unity Package Manager (git)](https://docs.unity3d.com/2019.4/Documentation/Manual/upm-ui-giturl.html):</summary>

> 1. In the Unity toolbar, select `Window` > `Package Manager` > `[+]` > `Add package from git URL...` 
> 2. Copy and paste the following link into the URL input field: <pre lang="md">https://github.com/Varneon/VUdon-PlayerScaleUtility.git?path=/Packages/com.varneon.vudon.player-scale-utility</pre>

</details><details><summary>

### Import from [Unitypackage](https://docs.unity3d.com/2019.4/Documentation/Manual/AssetPackagesImport.html):</summary>

> 1. Download latest `com.varneon.vudon.player-scale-utility.unitypackage` from [here](https://github.com/Varneon/VUdon-PlayerScaleUtility/releases/latest)
> 2. Import the downloaded .unitypackage into your Unity project

</details>

<div align="center">

## Developed by Varneon with :hearts:

![Twitter Follow](https://img.shields.io/twitter/follow/Varneon?color=%231c9cea&label=%40Varneon&logo=Twitter&style=for-the-badge)
![YouTube Channel Subscribers](https://img.shields.io/youtube/channel/subscribers/UCKTxeXy7gyaxr-YA9qGWOYg?color=%23FF0000&label=Varneon&logo=YouTube&style=for-the-badge)
![GitHub followers](https://img.shields.io/github/followers/Varneon?color=%23303030&label=Varneon&logo=GitHub&style=for-the-badge)

</div>
