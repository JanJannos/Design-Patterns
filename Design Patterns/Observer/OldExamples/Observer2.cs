using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns.Observer
{

    /**
     *
     * Example for memory leak
     *
     */

    public class Button
    {
        public event EventHandler Clicked;

        public void Fire()
        {
            Clicked?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Window
    {
        public Window(Button button)
        {
            button.Clicked += ButtonOnClicked;
            //WeakEventManager<Button , EventArgs>
            //    .AddHandler(button , "Clicked" , ButtonOnClicked);
        }

        private void ButtonOnClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Button clicked by window handler");
        }

        ~Window()
        {
            Console.WriteLine("Window Finalized");
        }
    }

    public class Observer2
    {
        static void Main1(string[] args)
        {
            var btn = new Button();
            var window = new Window(btn);
            btn.Fire();
            Console.WriteLine("Setting window to null");
            window = null;

            // call GC
            FireGC();
        }

        private static void FireGC()
        {
            Console.WriteLine("Starting GC");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            Console.WriteLine("Ending GC");
        }
    }
}
