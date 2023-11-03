using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Naninovel;

[CommandAlias("minigame")]
public class SwitchToMiniGameMode : Command
{

        public override async UniTask ExecuteAsync(AsyncToken asyncToken)
        {
            // 1. Disable Naninovel input.
            var inputManager = Engine.GetService<IInputManager>();
            inputManager.ProcessInput = false;

            
        
            // 2. Stop script player.
            var scriptPlayer = Engine.GetService<IScriptPlayer>();
            scriptPlayer.Stop();

        
            // 3. Reset state.
            var stateManager = Engine.GetService<IStateManager>();
            await stateManager.SaveGlobalAsync();
        

        // 4. Start game
            GameManager.Instance.StartMiniGame();



    }
}