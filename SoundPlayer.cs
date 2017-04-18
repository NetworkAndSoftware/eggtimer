using System;
using System.Threading;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;

namespace eggtimer
{
  /// <summary>
  /// Plays a .wav file asynchronously
  /// </summary>
  public class FileSoundPlayer
  {
    string sound;

    public FileSoundPlayer(string newsound)
    {
      sound = newsound;
    }

    public void play()
    {
      Thread playthread = new Thread(new ThreadStart(player));
      playthread.Start();
      
    }

    [DllImport("winmm.dll")]
    private static extern long PlaySound(string sName, uint hModule, uint dwFlags);

    private void player()
    {
      PlaySound(sound, 0, 0);
    }
  }

  /// <summary>
  /// Plays a .wav file from an embedded resource asynchronously
  /// </summary>
  public class ResourceSoundPlayer
  {
    byte[] soundbytes;
    
    public ResourceSoundPlayer(string sound)
    {
      Stream s=Assembly.GetExecutingAssembly().GetManifestResourceStream(sound);
      soundbytes = new Byte[s.Length]; 
      s.Read(soundbytes, 0, (int) s.Length);
    }

    public ResourceSoundPlayer(System.Type type, string sound)
    {
      Stream s=Assembly.GetExecutingAssembly().GetManifestResourceStream(type, sound);
      soundbytes = new Byte[s.Length]; 
      s.Read(soundbytes, 0, (int) s.Length);
    }

    public void play_async()
    {
      Thread playthread = new Thread(new ThreadStart(player));
      playthread.Start();
    }

    public void play_sync()
    {
      player();
    }

    [DllImport("winmm.dll")]
    public static extern bool sndPlaySound(byte[] soundbytes, int param);

    [DllImport("winmm.dll")]
    private static extern long PlaySound(string sName, uint hModule, uint dwFlags);

    private void player()
    {
      const int SND_SYNC      = 0;    // Play synchronously (default).
      //const int SND_ASYNC     = 0x1;  // Play asynchronously (see note below).
      const int SND_NODEFAULT = 0x2;  // Do not use default sound.
      const int SND_MEMORY    = 0x4;  // lpszSoundName points to a memory file.
      //const int SND_LOOP      = 0x8;  // Loop the sound until next sndPlaySound.
      //const int SND_NOSTOP    = 0x10; // Do not stop any currently playing sound.

      sndPlaySound(soundbytes, SND_SYNC | SND_MEMORY | SND_NODEFAULT);
    }
  }

}

