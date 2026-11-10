using System;
using System.Collections.Generic;
using System.Text;

namespace BunBun
{
    public class BunBunSettings
    {
        public int StompIntervalMinutes { get; set; } = 4;

        public int StompCount { get; set; } = 1;

        public bool EnableMorningActivation { get; set; }
       
        public TimeOnly MorningStart { get; set; } = new(7, 30);

        public TimeOnly MorningEnd { get; set; } = new(8, 0);

        public bool EnableEveningDeactivation { get; set; }

        public TimeOnly EveningStart { get; set; } = new(16, 30);

        public TimeOnly EveningEnd { get; set; } = new(17, 0);

        public void RecordStomp()
        {
            StompCount++;
        }
    }
}
