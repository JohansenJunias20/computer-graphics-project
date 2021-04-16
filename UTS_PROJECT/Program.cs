using System;
using OpenTK;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
namespace UTS_PROJECT
{
    class Program
    {
        static void Main(string[] args)
        {
            //pengaturan window
            var ourWindow = new NativeWindowSettings()
            {
                Size = new Vector2i(1080, 1080),
                Title = "Johansen Junias - C14190114"
            };

            //gameWindowSetting mengatur hz/frekuensi layar
            //.Default untuk memberi nilai default.
            //using disini seperti nge bundle agar mengoptimasi penggunakan memory.
            //agar apapun yang ada di dalam scope akan terdestroy bila sudah tidak digunakan
            using (var win = new Window(GameWindowSettings.Default, ourWindow))
            {
                win.Run();
            }
            Console.WriteLine("Hello World!");
        }
    }
}
