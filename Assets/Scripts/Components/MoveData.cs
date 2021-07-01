using Unity.Entities;
using Unity.Mathematics;


[GenerateAuthoringComponent]
public struct MoveData : IComponentData
{
    
    public float speed;
    

    public bool rightKey;
    public bool leftKey;
    public bool upKey;
    public bool backKey;
}
