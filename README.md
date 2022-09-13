C#, WPF, MSSQL, Entity Framework.
Приложение (Shop) для работы с базой данной, есть возможность создание товара, удаление и поиска данных. Есть авторизация и регистрация клиента. В качестве стиля графического интерфейса пользователя использовался Material Design In XAML.

![Окно входа](https://user-images.githubusercontent.com/86247389/189728536-882e3f6e-c0a1-4cf0-8785-f8430088677e.png)

При заходе в приложение пользователь может зарегистрироваться, для этого перейдя в окно регистрации, данные запишутся в базу данных (MSSQL) Shop_Database.

![Окно регистрации](https://user-images.githubusercontent.com/86247389/189729758-84e81968-7e81-4f49-a7ea-cbb3f1386947.png)

Пользователь вводит свои данные, происходит проверка на пустые строки, совпадают ли пароли, и проверяется есть ли в базе данных одинаковый логин. В случае если есть выдаётся исключение в MessageBox.

![Регистрация](https://user-images.githubusercontent.com/86247389/189730100-19fcb724-d547-40dc-88e5-9799c4bc6e05.png)

Если проверки пройдены успешны выдаётся MessageBox, с успешной регистрацией.

![Успешная регистрация](https://user-images.githubusercontent.com/86247389/189730598-ba01b177-7132-4f98-b830-2322f53a2c48.png)

Пользователь вводит логин и пароль. Они сверяются с данными в базе данных, и при успешной проверки происходит вход.

![Вход в приложение](https://user-images.githubusercontent.com/86247389/189731034-91640939-b805-4d28-97b8-395d1f7f252b.png)

Логин пользователя отображается справа вверху, для дальнейшей работы нужно выбрать таблицу из списка в Combobox.

![Окно приложения](https://user-images.githubusercontent.com/86247389/189731415-acbaa3bf-9cb0-4597-b53e-4cc478bb570d.png) 

При нажатие на список, нам на выбор предоставляется две таблицы (Товары, Клиенты).
Таблица "Клиенты" имеет первичный ключ ClientId;
Таблица "Товары" имеет первичный ключ ProductID и вторичный ключ ClientId;
Связь один ко многим.

Клиенты (ClientId INT (PK), ClientFirstName NCHAR(50), ClientLastName NCHAR(50), ClientLogin NCHAR(50), ClientPassword NCHAR(50)),
Товары (ProductID INT (PK), ProductName NCHAR(50), Price INT, Amount INT, ClientId INT (FK).

В случае, если пользователь не выбрал таблицы выдаётся ошибка в MessageBox.

![Combobox](https://user-images.githubusercontent.com/86247389/189731882-e40d969c-b44f-4875-a7c3-1ca15f58a254.png)

После выбора таблице в Combobox (Клиенты) нужно нажать кнопку обновить, DataGrid выведется информация из базы данных.

![Обновить](https://user-images.githubusercontent.com/86247389/189733592-3332ee8f-7c8d-4ecf-bd47-a09fa5767be1.png)

В элементе DataGrid выводится информация ID Клиента, Имя, Фамилия. Пароль и логин хранится в базе данных, но не выводится для безопасности системы.

![Таблица Клиенты](https://user-images.githubusercontent.com/86247389/189733848-aae41bac-9c10-4214-8d23-b48e4a1f4d25.png)

При изменении в Combobox (Товары) нужно нажать кнопку обновить, DataGrid выведется информация из базы данных. В элементе DataGrid выводится информация ID Товара, Название товара, Цена, Количество, Номер клиента.

Внизу можно нажать кнопку создание товара.

![Таблица Товары](https://user-images.githubusercontent.com/86247389/189858897-2ad324fe-59cc-4ceb-a749-580a3db1cf6e.png)

Открывается окно создание товара, нужно ввести входные данные товара.

![Окно создание товара](https://user-images.githubusercontent.com/86247389/189859197-90c2387c-06df-46bc-995f-8013f82fdadc.png)

После нажатие на кнопку "Создать" происходят проверку на правильность ввода данных. 

![Создание товара](https://user-images.githubusercontent.com/86247389/189859350-1fcb9d76-3791-4677-95a9-cd2869a6f0a3.png)

Выдаётся окно о записи данных в базу данных.

![Запись товара в базу данных](https://user-images.githubusercontent.com/86247389/189859565-183f61d6-2a9b-4737-9a70-8c8e3fc04b12.png)

После нажмём кнопку "Обновить" и запись была внесена в базу данных и отображается в таблице.

![Проверка записи](https://user-images.githubusercontent.com/86247389/189859657-26109bef-d8d0-4594-9134-c1716938c482.png)

Выберем строку для удаления, она помечается светло-серым цветом.

![Выбор строки для удаления](https://user-images.githubusercontent.com/86247389/189859779-5878f1e5-1e62-411d-93fa-f4097dfc3ae2.png)

При выборе строки нажимаем кнопку "Удалить", в MessageBox нажимаем кнопку "ОК". 

![Удаление](https://user-images.githubusercontent.com/86247389/189859842-fc048024-d193-4d81-9518-aafbad25f5fa.png)

Запись была удалена это можно увидеть на скриншоте ниже.

![Проверка операции](https://user-images.githubusercontent.com/86247389/189859886-25b22c00-5fe6-4d4a-8655-f936b1da4c11.png)

Для поиска нужно в TextBox поиск, вписать данные, которые хочет найти пользователь.

![Поиск](https://user-images.githubusercontent.com/86247389/189859953-5458447f-0c0a-4a82-9ad3-4d1c8103a991.png)

![Поиск](https://user-images.githubusercontent.com/86247389/189736305-3cd4064e-221c-41dc-b2da-b9fc9349cb96.png)

![Поиск](https://user-images.githubusercontent.com/86247389/189736337-47656c8a-3684-4b06-8bea-b8fb87765918.png)

![Поиск](https://user-images.githubusercontent.com/86247389/189736358-70d830ad-0ed9-4347-8b7a-338cedcb7a2c.png)

Чтобы увидеть, всю таблицу нужно нажать кнопку "Обновить".
![Обновить](https://user-images.githubusercontent.com/86247389/189736486-40367b05-a5eb-4fa1-a87b-5c425b45b7b8.png)

Для выхода из приложения нужно нажать кнопку "Выйти из приложения", в MessageBox нажимаем кнопку "ОК". 
![Выход](https://user-images.githubusercontent.com/86247389/189736532-e516049e-8720-4217-a7d7-ac7fa64e466c.png)



