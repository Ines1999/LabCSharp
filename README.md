# LabCSharp
Завдання: 5)	Разработать структуру хранения текста, который может состоять из абзацев, предложений, листингов, заголовков, слов и проч. 

Я обрала для цього завдання патерн Composite (Компонувальник).

Мені добре підходить патерн Компонувальник для виконання завданнятак як він добре підходить для моделей, в яких об'єкти об'єднані в групи об'єктів деривовидної структури за принципом "частина-ціле" та цей патерн дозволяє однаково працювати клієнту як з окремими об'єктами, так і з групою об'єктів. Текст складається з абзаців (лістинги та заголовки можно представити як абзац), абзац складається з речень, а речення у свою чергу складається зі слів. Отже, моя модель задовольняє умові деривовидності структури. 

Опис класів програми:

- Component: визначає інтерфейс для всіх компонентів в структурі дерева

- Program: запускає вивід дерева на екран, використовує компоненти. У main виводиться спочатку структура заданого тексту методом Print(), а потім методом Print_Content() виводиться сам зміст(тільки текст)

- Sentence, Paragraph, Text: класи Слова, Речення, Абзацу, Тексту, що представляють компоненти, які можуть містити інші компоненти та реалізують механізм для їх додавання та видалення.

- Word - класс, що представляє окремий компонент, який не може містити інші компоненти.

Наведемо UML-діаграму класів:


![alt text](https://github.com/Ines1999/LabCSharp/blob/Lab1/UML2.PNG)
