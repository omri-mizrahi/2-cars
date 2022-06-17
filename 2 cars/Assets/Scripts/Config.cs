using System.Collections.Generic;
using Settings = Consts.Settings;

public class Config {
    public static Dictionary<string, float> TwoCarsDefaults = new Dictionary<string, float>() {
        {Settings.StartSpawnRate, 1f},
        {Settings.SpawnAcceleration, 0.01f},
        {Settings.MinSpawnRate, 0.6f},
        {Settings.StartingSpeed, 4f},
        {Settings.GameAcceleration, 0.08f}
    };

    public static Dictionary<string, float> ThreeCarsDefaults = new Dictionary<string, float>() {
        {Settings.StartSpawnRate, 1.5f},
        {Settings.SpawnAcceleration, 0.01f},
        {Settings.MinSpawnRate, 0.6f},
        {Settings.StartingSpeed, 2f},
        {Settings.GameAcceleration, 0.08f}
    };

    public static Dictionary<string, Dictionary<string, float>> DefaultSettings = new Dictionary<string, Dictionary<string, float>>() {
        {Consts.GameModes.TwoCars, TwoCarsDefaults},
        {Consts.GameModes.ThreeCars, ThreeCarsDefaults}
    };
}