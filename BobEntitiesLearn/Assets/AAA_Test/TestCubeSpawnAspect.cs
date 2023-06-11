using Unity.Entities;

public readonly partial struct TestCubeSpawnAspect : IAspect
{
    public readonly EnabledRefRO<Test_CubePrefab> Self;
}