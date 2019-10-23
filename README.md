# TestApp
WebApi for date intervals(GET POST) , ConsoleApp for Api

Документация к тестовым заданиям
Решение состоит из 4 компонентов:

 -  ASP.NET DateMatchAPI сервер
 -  Unit тест к серверу
 -  Клиентское консольное приложение ConsoleWebAPI
 -  БД

 ASP.Net DateMatchAPI

Состоит из 3х проектов:
- Data Access layer(DAL) 
- Buisnes Object layer (BOL)
- сам веб сервер asp.net DateMatchAPI

DAL
Базовый слой содержащий данные с БД и репозитории для прямой работы с этими данными.
Использует EntityFramework,  подход CodeFirst для автоматического создания класов соответствующих таблицам и записям в БД

BOL
Промежуточный слой между DAL и основным приложением, для защиты от прямой работы с данными БД.
Были созданы классы-аналоги data transfer object(*DTO), имеющие теже поля что и классы созданые EntityFramework в DAL. По нужде можно добавлять поля в DTO для работы в приложении.
Созданы репозитории (реализуют интерфейс IService) работающие с DTO класами, и последующими CRUD операциями в нижний слой DAL.
Содержит вспомогательный класс DateRangeUI для вывода данных пользователю только той информации, которая нужна.

DateMatchAPI
 Использует EntityFramework для работы с подключением к SQL Server.
Стандартная  строка подключения прописывается  в файле **Web.config** .
SQL сервер находиться на локальной машине, используется аутентификация Windows для подключения к БД DateMatchDB.
По умолчанию вид строки подключения следующий:

      <connectionStrings>
        <add name="DateMatchDB" connectionString="data source=.\SQLEXPRESS;initial catalog=DateMatch;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework" providerName="System.Data.SqlClient" />  
    </connectionStrings>
Был использован подход CodeFirst, поэтому есть схема БД не совпадает - она будет дропнута и пересоздана.
Обратите внимание, юнит тест требует одинаковую строку подключения для корректных результатов. Изменить его строку подключения можно в файле **App.config**

Был использован Niinject.Web.WebApi для внедрения зависимости. Зависмотси вносятся в файле **App_Start\ Ninject.Web.Common.cs**
Например kernel.Bind<IRepository<Intervals>>().To<IntervalsRepository>(); мы указываем что что если в коде будет запрошен интерфейс IRepository типизированый класом Intervals, то ninject должен подставить туда экземпляр класса IntervalsRepository.

Путь для доступа к API : /api/
По умолчанию возвращает по GET запросу JSON содержащий все записи таблицы Intervals из БД.
Поддерживаются  запросы GET (/api/yyyy-mm-dd/yyyy-mm-dd) возвращающий JSON с интервалами дат которые пересакаются с задаными в запросе (по заданию).
Запрос POST ((/api/yyyy-mm-dd/yyyy-mm-dd) добавляющий запись в БД двух дат заданых в строке запроса.

Реализован механизм логирования в БД DateMatchDB в таблицу LogRecords.
Логируются как запросы пользователя так и ответы сервера.
Структуру БД смотри в разделе БД.

Консольное приложение ConsoleWebAPI

Навигация по меню реализуется ответом в виде цифры.
Реализовано добавление новых дат, в основе POST запрос из asp.net приложения выше DateMatchAPI.
Фильтрация пересечений с существующими интервалами в БД, в основе GET запрос из asp.net приложения выше DateMatchAPI.
У пользователя спрашивают даты, которые принимаются  в формате yyyy-mm-dd  
Адрес по умолчанию следующий: https://localhost:44382/api/. Его можно изменить, изменив константу (uri) в файле Program.cs
Используеться SSL а значит нужно указывать новый адрес только https/

Так же реализован механизм логирования в БД DateMatchDB в таблицу LogRecords.
Логируются как запросы пользователя так и ответы сервера.
Структуру БД смотри в разделе БД.

БД DateMatchDB
Состоит из двух таблиц **Intervals** и **LogRecords** 

[Intervals]
   ID int not null  primary key,
   [Start] Date NOT NULL, начальная дата
   [End] Date NOT NULL, конечная дата

[LogRecords]
ID-int-primary key 
[Time] DateTime NOT NULL, - время запроса\ответа
[Start] Date NOT NULL, начальная дата
[End] Date NOT NULL, конечная дата
isRequest-bit,  1 если это запрос пользователя, 0 если ответ сервера

