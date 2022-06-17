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
}