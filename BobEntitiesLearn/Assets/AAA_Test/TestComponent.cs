using Unity.Entities;

public struct Test_AA : IComponentData
{
    public float Value;
    public int dir;
}

[InternalBufferCapacity(8)]
public struct Test_BB : IBufferElementData
{
    public int Value;
}


public struct Test_CC : IComponentData
{
    public float Value;
    public int dir;
}

public struct Test_CubePrefab : IComponentData, IEnableableComponent
{
    public Entity CubePrefab;
}

public struct Test_CubeSpawner : IComponentData, IEnableableComponent
{

}