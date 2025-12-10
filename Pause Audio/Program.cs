using NAudio.CoreAudioApi;
using NAudio.CoreAudioApi.Interfaces;

try
{
    var deviceEnumerator = new MMDeviceEnumerator();
    var device = deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
    var sessionManager = device.AudioSessionManager;

    int mutedCount = 0;

    for (int i = 0; i < sessionManager.Sessions.Count; i++)
    {
        var session = sessionManager.Sessions[i];

        if (session.State == AudioSessionState.AudioSessionStateActive)
        {
            // Mute this audio session
            session.SimpleAudioVolume.Mute = true;
            mutedCount++;

            Console.WriteLine($"Muted session: {session.DisplayName} (PID: {session.GetProcessID})");
        }
    }

    Console.WriteLine($"Muted {mutedCount} currently active audio sessions.");
}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
}


