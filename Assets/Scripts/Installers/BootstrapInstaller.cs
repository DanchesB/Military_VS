using UnityEngine;
using Zenject;

public class BootstrapInstaller : MonoInstaller, ICoroutineRunner
{
    [SerializeField]
    private EnemySpawnManager _spawnManager;
    [SerializeField]
    private int _targetXp = 1000;//move the variable to a more obvious location

    private const string DefPlayerSOPath = "SO/DefaultPlayerSO";
    private const string DefWeaponSOPath = "SO/DefaultWeaponSO";

    public override void InstallBindings()
    {
        this.gameObject.SetActive(true);
        Container.BindInterfacesAndSelfTo<ICoroutineRunner>().FromInstance(this).AsSingle();

        var playerChar = new PlayerCharacteristics(Instantiate(Resources.Load<PlayerSO>(DefPlayerSOPath)));
        Container.Bind<PlayerCharacteristics>().FromInstance(playerChar).AsSingle().NonLazy();

        Container.Bind<WeaponCharacteristics>().FromNew().AsSingle().WithArguments
            (Instantiate(Resources.Load<WeaponSO>(DefWeaponSOPath))).NonLazy();

        Container.Bind<EnemySpawnManager>().FromInstance(_spawnManager).AsSingle().NonLazy();
        _spawnManager.Init(playerChar);

        Container.Bind<XpSystem>().FromNew().AsSingle().WithArguments(_targetXp).NonLazy();
        Container.Bind<MoneySystem>().FromNew().AsSingle().NonLazy();

        Container.Bind<ProgressSystem>().FromNew().AsSingle().NonLazy();
    }
}