using Naninovel;
using Naninovel.Commands;
using UnityEngine;

[CommandAlias("hideAll")]
public class HideAllCustom : HideAllActors
{
    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        foreach (var item in Engine.GetService<IUIManager>().GetManagedUIs())
        {
            item.Visible = false;
        }
        return base.ExecuteAsync(asyncToken);
    }
}
