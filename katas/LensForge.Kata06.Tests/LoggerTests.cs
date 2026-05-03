namespace LensForge.Kata06.Tests
{
    public class LoggerTests
    {
        [Fact]
        public void Logger_HasOnlyOneInstance()
        {
            // Egal wie oft wir den Logger anfordern — es muss 
            // immer dieselbe Instanz sein.
            var first = GetLogger();
            var second = GetLogger();

            Assert.Same(first, second);
        }

        [Fact]
        public void Logger_LevelChange_PropagatesEverywhere()
        {
            // Wenn ich an einer Stelle den Level ändere, muss 
            // jede andere Stelle den neuen Level sehen.
            var loggerA = GetLogger();
            loggerA.MinimumLevel = LogLevel.Error;

            var loggerB = GetLogger();

            Assert.Equal(LogLevel.Error, loggerB.MinimumLevel);
        }

        [Fact]
        public void Modules_ShareTheSameLoggerInstance()
        {
            // Die drei Module sollen alle denselben Logger nutzen.
            // Wir testen das indirekt: Wenn wir den Level am 
            // Singleton hochsetzen, müssen alle Module das respektieren.

            var logger = GetLogger();
            logger.MinimumLevel = LogLevel.Error;

            // Wenn die Module ihre eigenen Logger hätten, würde das 
            // Setzen des Levels keinen Effekt auf sie haben.
            var assembly = new AssemblyLine();
            var quality = new QualityGate();

            // Beide Module sollten den geteilten Logger nutzen — 
            // dieser Test stellt sicher, dass kein Modul mehr 
            // einen eigenen Logger erzeugt.
            // (Implementierungsdetail: Wie ihr das prüft, ist eure Sache —
            //  z.B. über Reflection auf das Logger-Feld, oder durch 
            //  Beobachtung des Outputs.)
        }

        // TODO: Diese Methode müsst ihr nach eurem Refactor sinnvoll füllen.
        //       Sie soll auf die geteilte Logger-Instanz zugreifen.
        private ProductionLogger GetLogger()
            => throw new NotImplementedException();
    }
}
