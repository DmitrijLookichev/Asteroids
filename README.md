Референс: https://en.wikipedia.org/wiki/Asteroids_(video_game)
Устройство:
1. Scripts/Common - сборка общего кода, связанная с движком, включает настройки сцены, конфиги (пресеты) и Unity-сущности
1.1. Actors - Unity-компоненты, используемые для настройки визуала
1.2. Presentation - контроллеры, для взаимодействия с UI
1.3. Presets - скриптаблы, для конфигурации параметров объектов
1.4. Stores - Pure-C# объекты, используемые как хранилища
1.5. Systems - Pure-C# объекты, передающие и принимающие данные из Core сборки проекта

2. Scripts/Core - сборка без UnityEngine доступа, содержащая всю игровую логику проекта
2.1. Aspects - классы, выступающие в качестве представления данных игровых объектов
2.2. Datas - структуры, группирующие асоциативные данные аспектов
2.3. Primitives - прочие перечисления и структуры
2.4. Systems - системы игровой логики

В Core сборке доступна библиотека Unity.Mathematics, для упрощения математических расчетов

Все пресеты располагаются в Presets
InputActionAsset и SceneSettings располагаются в Settings

Управление:
W - ускорение
A & D - вращение против/по часовой стрелке
Space - выстрел из орудия
Q - выстрел лазера

Цели: 
- Уклоняться от вращеских снарядов, астеройдов и кораблей;
- Поражать прочие объекты из орудия и лазером;
- Набрать максимальное количество очков (панель сверху)
