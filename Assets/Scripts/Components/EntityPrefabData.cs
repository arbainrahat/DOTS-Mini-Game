using Unity.Entities;
using UnityEngine;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public struct EntityPrefabData : IComponentData
{
    public Entity prefabEntity; 
    
}
