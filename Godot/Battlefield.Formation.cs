using Godot;
using Vaelorn;
using System;
using System.Linq;

public partial class Battlefield
{
    public bool FormationEditing{get;set;}
    public event Action? FormationChanged;
    private Unit? draggedUnit,clickSelection;
    private Vector2 dragStart;
    public Vector2 CellFoot(bool friendly,int column,int layer)=>new(85+(Size.X-170)*(friendly?.295f-layer*.105f:.705f+layer*.105f),Size.Y*(.43f+column*.125f));
    private Rect2 FormationRect(int cell){var foot=CellFoot(true,cell%3,cell/3);return new Rect2(foot-new Vector2(Size.X*.06f,Size.Y*.19f),new Vector2(Size.X*.12f,Size.Y*.22f));}
    private int FormationCellAt(Vector2 point){for(int cell=0;cell<9;cell++)if(FormationRect(cell).HasPoint(point))return cell;return -1;}
    private bool FormationInput(InputEvent e)
    {
        if(EntranceActive)return true;
        if(!FormationEditing||Battle==null)return false;
        if(e is InputEventMouseButton m&&m.ButtonIndex==MouseButton.Left){
            int cell=FormationCellAt(m.Position);
            if(m.Pressed){
                dragStart=m.Position;clickSelection=Selected!=null&&Battle.Allies.Contains(Selected)?Selected:null;
                draggedUnit=Battle.Allies.FirstOrDefault(u=>u.Layer*3+u.Column==cell);
                if(clickSelection==null&&draggedUnit!=null)SelectUnit(draggedUnit);
            }else{
                var moving=m.Position.DistanceTo(dragStart)>6?draggedUnit:clickSelection;
                if(moving!=null&&cell>=0&&Battle.TryMoveAlly(moving,cell)){SelectUnit(moving);FormationChanged?.Invoke();}
                else if(draggedUnit!=null)SelectUnit(draggedUnit);
                draggedUnit=null;clickSelection=null;
            }
        }
        return true;
    }
    private void DrawFormationGrid()
    {
        if(!FormationEditing||EntranceActive)return;
        for(int cell=0;cell<9;cell++){
            var r=FormationRect(cell);bool selected=Selected!=null&&Battle!.Allies.Contains(Selected)&&Selected.Layer*3+Selected.Column==cell;
            bool hover=r.HasPoint(GetLocalMousePosition());
            var center=CellFoot(true,cell%3,cell/3);var color=selected?gold:blue;
            DrawEllipse(center,new Vector2(44,13),new Color(color,hover?.24f:.10f));
            DrawPolyline(System.Linq.Enumerable.Range(0,49).Select(n=>center+new Vector2(Mathf.Cos(n*Mathf.Tau/48)*45,Mathf.Sin(n*Mathf.Tau/48)*14)).ToArray(),new Color(color,selected?1:.65f),selected?3:2,true);
            DrawPolyline(System.Linq.Enumerable.Range(0,49).Select(n=>center+new Vector2(Mathf.Cos(n*Mathf.Tau/48)*38,Mathf.Sin(n*Mathf.Tau/48)*10)).ToArray(),new Color(color,.3f),1,true);
            Text((cell+1).ToString(),center+new Vector2(-4,29),color,11);
        }
        Text("Arraste ou selecione um aliado e clique na casa • Casas ocupadas trocam de lugar",new Vector2(22,Size.Y-12),new Color("dbe8ee"),12);
    }
}
