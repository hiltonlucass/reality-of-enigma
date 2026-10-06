using Godot;
public partial class TentacleButton:Button
{
    private float time;
    public override void _Process(double delta){time+=(float)delta;QueueRedraw();}
    public override void _Draw(){
        if(!IsHovered()&&!HasFocus())return;
        DrawSetTransform(new Vector2(21,Size.Y/2),-Mathf.Pi/2);
        EnigmaIdentity.Icon(this,0,new Rect2(-28,-28,56,56));DrawSetTransform(Vector2.Zero);
    }
}
