using System;

namespace AdapterSimpleExample
{
    // Лампочка зі старим стандартом (тонкий цоколь)
    class OldLamp
    {
        public string InsertThinBase()
        {
            return "Лампочка зі старим (тонким) цоколем";
        }
    }

    // Інтерфейс для ламп з широким цоколем
    interface INewLamp
    {
        string InsertWideBase();
    }

    // Нова лампочка з широким цоколем
    class NewLamp : INewLamp
    {
        public string InsertWideBase()
        {
            return "Лампочка з новим (широким) цоколем";
        }
    }

    // Адаптер, який дозволить використати стару лампочку (OldLamp) 
    // у патроні, розрахованому під нову (INewLamp)
    class LampAdapter : INewLamp
    {
        private readonly OldLamp _oldLamp;

        public LampAdapter(OldLamp oldLamp)
        {
            _oldLamp = oldLamp;
        }

        public string InsertWideBase()
        {
            // Адаптуємо стару лампочку під новий стандарт
            return _oldLamp.InsertThinBase() + " (через адаптер)";
        }
    }

    class LampSocket
    {
        // Патрон, який приймає тільки лампи нового стандарту
        public static void UseNewLamp(INewLamp lamp)
        {
            Console.WriteLine(lamp.InsertWideBase());
        }
    }

    class Program
    {
        static void Main()
        {
            // Створюємо нову лампочку та використовуємо її без проблем
            var newLamp = new NewLamp();
            LampSocket.UseNewLamp(newLamp);

            // Маємо стару лампочку, яку хочемо використати в новому патроні
            var oldLamp = new OldLamp();
            var adapter = new LampAdapter(oldLamp);

            // Використовуємо адаптер, щоб підключити стару лампочку
            LampSocket.UseNewLamp(adapter);

            Console.ReadKey();
        }
    }
}

