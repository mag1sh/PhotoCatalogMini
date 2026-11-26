\# PhotoCatalogMini



Учебен проект по ИП-РПП, 12 клас: каталог на фотографии с ASP.NET Core MVC, EF Core и SQL Server.



\## Реазлизирано

\-Entity Photo: заглавие, фотограф, категория, място на заснемане, описание

\-Entities: Photo, Photographer, Category; Photo-Category е много към много чрез PhotoCategory със съставен ключ

\-PhotoCatalogContext с Fluent API и миграция InitialCreate

\-Примерен запис (DemoData) в Development

\-Сервизен слой: IPhotoService и PhotoService

\-DTO (PhotoListDto) в Services и ViewModel (PhotoIndexViewModel) в Web

\-Страница /Photos показва заглавие, фотограф, категории, място и описание

\-Форма за добавяне на снимка (/Photos/Create) с валидация

\-CreatePhotoViewModel в Web и CreatePhotoDto в Services

\-Фотографите и категориите се намират по име, а ако ги няма, се създават



\## Стартиране

1.Нужни са .NET 8 и SQL Server (.\\SQLEXPRESS).

2.Провери connection string в PhotosCatalogMini.Web/appsettings.json.

3.В Package Manager Console:

Update-Database -Project PhotoCatalogMini.Data -StartupProject PhotoCatalogMini.Web -Context PhotoCatalogDbContext

4.Стартирай PhotoCatalogMini.Web (F5) и отвори /Photos.

