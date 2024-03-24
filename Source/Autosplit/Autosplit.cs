

using Microsoft.Xna.Framework;
using Monocle;

namespace Celeste.Mod.IAmSpeed.Autosplit;

public class Autosplit : Entity {

    public override void Render() {
        if (!IAmSpeedModule.Settings.Autosplitter) {
            return;
        }

        Draw.Rect(300, 300, 300, 300, Color.AliceBlue);
    }


}
