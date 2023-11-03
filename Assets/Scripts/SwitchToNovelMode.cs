using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Naninovel;

[CommandAlias("novel")]
public class SwitchToNovelMode : Command
{
    public StringParameter ScriptName;
    public StringParameter Label;

    public override async UniTask ExecuteAsync(AsyncToken asyncToken)
    {
        // Disable minigame
        GameManager.Instance.StopMiniGame();

        // Load and play specified script
        var scriptPlayer = Engine.GetService<IScriptPlayer>();
        await scriptPlayer.PreloadAndPlayAsync("Street");

        // Enable Naninovel input.
        var inputManager = Engine.GetService<IInputManager>();
        inputManager.ProcessInput = true;
    }
}