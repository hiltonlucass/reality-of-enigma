using Godot;
using System.Linq;

// One shallow semicircle; labels and targeting actions stay outside this container.
public partial class SkillWheel:Container
{
    public override Vector2 _GetMinimumSize()=>new(560,102);
    public override void _Notification(int what){
        if(what!=NotificationSortChildren)return;
        var children=GetChildren().OfType<Control>().Where(c=>c.Visible).ToArray();
        float spacing=Mathf.Min(88,(Size.X-88)/Mathf.Max(1,children.Length-1));
        for(int i=0;i<children.Length;i++){
            float x=(i-(children.Length-1)/2f)*spacing;
            float y=children.Length<2?0:16*Mathf.Pow(x/Mathf.Max(1,spacing*(children.Length-1)/2),2);
            FitChildInRect(children[i],new Rect2(Size.X/2+x-42,y,84,86));
        }
    }
}
