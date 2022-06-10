using System.Collections.Generic;

public class Consts {
    public class Tags {
        public const string Collectible = "Collectible";
        public const string Obstacle = "Obstacle";
        public const string GameScore = "GameScore";
        public const string GameMode = "GameMode";
    }

    
    public class GameModes {
        public const string TwoCars = "2CarsGame";
        public const string ThreeCars = "3CarsGame";
    }
    
    public class Scenes {
        public const string StartMenu = "StartMenu";
        // These must stay the same as GameModes:
        public const string TwoCars = GameModes.TwoCars;
        public const string ThreeCars = GameModes.ThreeCars;
        public const string GameOverMenu = "GameOverMenu";
        public const string SettingsMenu = "SettingsMenu";
    }

    public class PlayerPrefs {
        public const string Highscore = "Highscore";
    }

    public class Settings {
        public const string StartSpawnRate = "StartSpawnRate";
        public const string SpawnAcceleration = "SpawnersAcceleration";
        public const string MinSpawnRate = "MinSpawnRate";
        public const string StartingSpeed = "StartingGameSpeed";
        public const string GameAcceleration = "GameSpeedAcceleration";
    }

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
        {GameModes.TwoCars, TwoCarsDefaults},
        {GameModes.ThreeCars, ThreeCarsDefaults}
    };
}