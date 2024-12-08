using System;

namespace Facade.SimpleExample
{
    class MainApp
    {
        static void Main()
        {
            // Створюємо фасад для керування розумним будинком
            SmartHomeFacade smartHome = new SmartHomeFacade();

            // Легко вмикаємо всі системи одним викликом
            smartHome.LeaveHome();

            // Повертаємось додому – вмикаємо світло, тепло та вимикаємо сигналізацію
            smartHome.ComeBackHome();

            Console.ReadKey();
        }
    }

    // Підсистема: Освітлення
    class LightSystem
    {
        public void TurnOn()
        {
            Console.WriteLine("Освітлення увімкнено.");
        }

        public void TurnOff()
        {
            Console.WriteLine("Освітлення вимкнено.");
        }
    }

    // Підсистема: Система опалення
    class HeatingSystem
    {
        public void TurnOnHeating()
        {
            Console.WriteLine("Опалення увімкнено.");
        }

        public void TurnOffHeating()
        {
            Console.WriteLine("Опалення вимкнено.");
        }
    }

    // Підсистема: Сигналізація
    class AlarmSystem
    {
        public void ActivateAlarm()
        {
            Console.WriteLine("Сигналізація активована.");
        }

        public void DeactivateAlarm()
        {
            Console.WriteLine("Сигналізація деактивована.");
        }
    }

    // Фасад: Інтерфейс для керування всіма системами розумного будинку
    class SmartHomeFacade
    {
        private LightSystem light;
        private HeatingSystem heating;
        private AlarmSystem alarm;

        public SmartHomeFacade()
        {
            light = new LightSystem();
            heating = new HeatingSystem();
            alarm = new AlarmSystem();
        }

        // Метод для сценарію "Виходимо з дому"
        public void LeaveHome()
        {
            Console.WriteLine("\n-- Виходимо з дому --");
            // Вимикаємо світло, опалення та вмикаємо сигналізацію
            light.TurnOff();
            heating.TurnOffHeating();
            alarm.ActivateAlarm();
        }

        // Метод для сценарію "Повертаємось додому"
        public void ComeBackHome()
        {
            Console.WriteLine("\n-- Повертаємось додому --");
            // Вимикаємо сигналізацію, вмикаємо світло та опалення
            alarm.DeactivateAlarm();
            light.TurnOn();
            heating.TurnOnHeating();
        }
    }
}

