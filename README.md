Обязательные компоненты для запуска:
1. SQL Server Express LocalDB
2. .NET 8.0
3. Microsoft Visual C++ Redistributable

Для SQL Server Express LocalDB после установки в cmd пишите следующие команды:
1. sqllocaldb info - для проверки установки самой LocalDB
2. sqllocaldb info MSSQLLocalDB - для проверки имени экземпляра
3. sqllocaldb create MSSQLLocalDB - в случае если нет имени экземпляра создаёте
4. sqllocaldb start MSSQLLocalDB - запускает экземпляр LocalDB, писать в том случае если после ввода 2 команды в Состоянии написано "остановлено"
5. sqllocaldb delete MSSQLLocalDB - если не получаетя запустить процесс то пересоздаете экземпляр
